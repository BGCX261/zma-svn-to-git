using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Zicore.MinecraftAdmin;
using Zicore.MinecraftAdmin.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Zicore.MinecraftAdmin.Admins;
using MinecraftWrapper.ExternalComponents;

namespace MinecraftWrapper.WebInterface
{
    public class ZmaSQLConnection
    {
        MySqlConnection connection;
        string conString = "";

        public ZmaSQLConnection()
        {            
            try
            {
                string MyConString = "SERVER=217.160.16.235;" +
                    "DATABASE=zma_tool;" +
                    "UID=zma_app;" +
                    "PASSWORD=hldcoxra;";
                conString = MyConString;
                
                //MySqlDataReader Reader;
                //command.CommandText = "select * from mycustomers";

                //Reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Log.Append(this, "MySQL Connect " + ex.Message, Log.ExceptionsLog);
            }
        }

        ~ZmaSQLConnection()
        {
            try
            {
                connection.Close();
            }
            catch ( Exception ex)
            {
                Log.Append(this, "MySQL Close " + ex.Message, Log.ExceptionsLog);
            }
        }

        public void Open()
        {
            try
            {
                connection = new MySqlConnection(conString);
                connection.Open();
            }
            catch (Exception ex)
            {
                Log.Append(this, "MySQL Open" + ex.Message, Log.ExceptionsLog);
            }
        }

        public void Close()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {
                Log.Append(this, "MySQL Close " + ex.Message, Log.ExceptionsLog);
            }
        }

        public void AddChatMessage(String message, String user, MinecraftHandler mc)
        {
            try
            {
                if (mc.Config.StreamEnabled)
                {
                    String guid = mc.Config.GuidString;
                    int id = GetServerId(guid);

                    String query = String.Format("INSERT INTO zma_chat " +
                         "(message, username, date, fk_server_id) " +
                         "VALUES ('{0}','{1}',{2},{3});",
                         message,
                        user,
                        "NOW()",
                        id
                         );
                    ExecuteSQL(query);
                }
            }
            catch (Exception ex)
            {
                Log.Append(this, ex.Message +  " Add Chat message", Log.ExceptionsLog);
                connection.Close();
            }
        }

        public void GetCommands(MinecraftHandler mc, LockFreeQueue<WebActionCommand> webCommands)
        {
            try
            {
                if (mc.Started && mc.Config.StreamEnabled)
                {
                    String guid = mc.Config.GuidString;

                    MySqlCommand command = connection.CreateCommand();
                    String sql = String.Format(
                        "SELECT * FROM zma_app.zma_web_queue w WHERE w.server_guid = '{0}';"
                        , guid);
                    command.CommandText = sql;
                    MySqlDataReader reader = command.ExecuteReader();
                    List<int> ids = new List<int>();

                    int id = -1;

                    while (reader.Read())
                    {
                        id = reader.GetInt32("id");
                        WebActionType type = WebActionType.None;
                        type = (WebActionType)reader.GetInt32("type");
                        string message = "";
                        message = reader.GetString("message");
                        UserCollectionSingletone users = UserCollectionSingletone.GetInstance();

                        String userName = "";
                        try
                        {
                            userName = reader.GetString("name");
                        }
                        catch
                        {

                        }

                        if (id >= 0)
                        {
                            ids.Add(id);
                        }

                        User user = users.GetUserByName(userName);
                        if (type == WebActionType.Chat && id >= 0 && !user.Generated)
                        {
                            WebActionCommand cmd = new WebActionCommand(id, type, message, user, this);
                            webCommands.Enqueue(cmd);
                        }

                        
                    }

                    reader.Close();

                    foreach (int i in ids)
                    {
                        command.CommandText = String.Format("DELETE FROM zma_app.zma_web_queue WHERE id = {0};", i);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch ( Exception ex)
            {
                Log.Append(this,"GetCommands "+  ex.Message, Log.ExceptionsLog);
            }
        }

        //id, name, is_online, seconds_online, players_max, players_online, date_time, ip, port,guid, country, version
        public void UpdateServer(MinecraftHandler mc,int isOnline)
        {
            if (mc.Config.StreamEnabled)
            {
                try
                {
                    string name = mc.Config.ServerName;
                    int online = mc.Started ? 1 : 0;
                    int secondsOnline = mc.SecondsOnline;
                    int playersMax = 100;
                    int playersOnline = mc.Player.Count;
                    string ip = mc.Config.ExternalIp;
                    int port = mc.Config.ExternalPort;


                    DateTime dt = DateTime.Now;
                    String guid = mc.Config.GuidString;

                    if (!IsInTable("zma_server", "guid", mc.Config.GuidString))
                    {
                        String query = String.Format("INSERT INTO zma_server " +
                             "(name,is_online,seconds_online,players_max,players_online,date_last_online, ip, port, guid, country, version) " +
                             "VALUES ('{0}',{1},{2},{3},{4},{5}, '{6}',{7},'{8}', '{9}' , '{10}');",
                             name,
                             online,
                             secondsOnline,
                             playersMax,
                             playersOnline,
                             "NOW()",
                             ip,
                             port,
                             guid,
                             Culture,
                             mc.Version
                             );
                        ExecuteSQL(query);
                    }
                    else
                    {
                        String query = String.Format("UPDATE zma_server SET " +
                            "name = '{0}' ," +
                            "is_online = {1} ," +
                             "seconds_online = {2} ," +
                              "players_max = {3} ," +
                               "players_online = {4}, " +
                               "date_last_online = {5}, " +
                               "ip = '{6}', " +
                               "port = {7}, " +
                               "country = '{8}', " +
                               "version = '{9}' " +
                               "WHERE guid = '{10}';",
                               name, online, secondsOnline, playersMax, playersOnline, "NOW()", ip, port, Culture, mc.Version, guid
                            );
                        ExecuteSQL(query);
                    }
                }
                catch (Exception ex)
                {
                    Log.Append(this, ex.Message, Log.ExceptionsLog);
                }
            }
        }

        public string Culture
        {
            get
            {
                try
                {
                    String pattern = @"\((?<country>[{a-z]+)\)";
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    Match m = regex.Match(System.Globalization.CultureInfo.CurrentCulture.EnglishName);
                    if (m.Groups["country"].Success)
                    {
                        return m.Groups["country"].Value;
                    }
                }
                catch
                {
                    return System.Globalization.CultureInfo.CurrentCulture.EnglishName;
                } 
                return string.Empty;
            }
        }

        public void UpdatePlayer(MinecraftHandler mc, String playerName, int isOnline)
        {
            if (mc.Config.StreamEnabled)
            {
                try
                {
                    string name = mc.Config.ServerName;
                    String guid = mc.Config.GuidString;
                    int id = GetServerId(guid);
                    int online = isOnline;
                    int secondsOnline = mc.SecondsOnline;
                    //int playersMax = 100;
                    int playersOnline = mc.Player.Count;
                    string ip = mc.Config.ExternalIp;
                    int port = mc.Config.ExternalPort;
                    DateTime dt = DateTime.Now;

                    UserCollectionSingletone users = UserCollectionSingletone.GetInstance();
                    User u = users.GetUserByName(playerName);
                    int hasWebAccess = u.HasWebAccess ? 1 : 0;
                    if(u.Generated)
                    {
                        hasWebAccess = 0;
                    }

                    if (!IsInTable("zma_players", "name", playerName))
                    {
                        String query = String.Format("INSERT INTO zma_players " +
                             "(is_online,name,seconds_online,date_last_online, fk_server_id, web_login, web_password, has_web_access,fk_web_server_guid) " +
                             "VALUES ({0},'{1}',{2}, {3},{4},'{5}',MD5('{6}'),{7},{8});",
                             online,
                             playerName,
                             secondsOnline,
                            "NOW()",
                             id,
                             u.WebUsername,
                             u.PasswordHash,
                             hasWebAccess,
                             id
                             );
                        ExecuteSQL(query);
                    }
                    else
                    {
                        String query = String.Format("UPDATE zma_players SET " +
                             "seconds_online = {0} ," +
                               "date_last_online = {1}, " +
                               "is_online = {2}, " +
                               "fk_server_id = {3}, " +
                               "web_login = '{4}', " +
                               "web_password = MD5('{5}'), " +
                               "has_web_access = {6}, " +
                               "fk_web_server_guid = {7} " +
                               "WHERE name = '{8}';",
                               secondsOnline, "NOW()", online, id, u.WebUsername, u.PasswordHash, hasWebAccess, id, playerName
                            );
                        ExecuteSQL(query);
                    }

                }
                catch (Exception ex)
                {
                    Log.Append(this, ex.Message, Log.ExceptionsLog);
                }
            }
        }

        public void UpdatePlayers(MinecraftHandler mc)
        {
            lock (mc.Player)
            {
                try
                {
                    foreach (String str in mc.Player)
                    {
                        UpdatePlayer(mc, str, 1);
                    }
                }
                catch (Exception ex)
                {
                    Log.Append(this, ex.Message, Log.ExceptionsLog);
                }
            }
        }

        /// <summary>
        /// Gibt einen MD5 Hash als String zurück
        /// </summary>
        /// <param name="TextToHash">string der Gehasht werden soll.</param>
        /// <returns>Hash als string.</returns>
        public static string GetMD5Hash(string TextToHash)
        {
            //Prüfen ob Daten übergeben wurden.
            if ((TextToHash == null) || (TextToHash.Length == 0))
            {
                return string.Empty;
            }

            //MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
            //zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
            byte[] result = md5.ComputeHash(textToHash);

            return System.BitConverter.ToString(result);
        }

        public bool IsInTable(String columnString, String where, String value)
        {
            connection = new MySqlConnection(conString);
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = String.Format("SELECT id FROM {0} WHERE {1} = '{2}';", columnString, where, value);
            MySqlDataReader reader = command.ExecuteReader();
            bool result = reader.HasRows;
            reader.Close();
            return result;
        }

        public void ExecuteSQL(String sql)
        {
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public int GetServerId(String guid)
        {
            MySqlCommand command = connection.CreateCommand();
            String sql = String.Format("SELECT id FROM zma_server WHERE guid = '{0}';", guid);
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();

            int id = -1;

            if (reader.Read())
            {
                id = reader.GetInt32("id");
            }
            reader.Close();
            
            return id;
        }
    }
}
