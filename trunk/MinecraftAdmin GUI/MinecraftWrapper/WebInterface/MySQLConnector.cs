using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Zicore.MinecraftAdmin.IO;
using System.Data;
using MinecraftWrapper.WebInterface;

namespace Zicore.SQLUtils
{
    public class MySQLConnector
    {
        private static volatile MySQLConnector instance = null;
        private static object m_lock = new object();

        public static MySQLConnector GetInstance()
        {
            // DoubleLock
            if (instance == null)
            {
                lock (m_lock)
                {
                    if (instance == null)
                    {
                        instance = new MySQLConnector();
                    }
                }
            }
            return instance;
        }
        
        private MySQLConnector()
        {

        }

        public bool Open(String host, String database, String user, String password)
        {
            try
            {
                string MyConString = String.Format("SERVER={0};" +
                    "DATABASE={1};" +
                    "UID={2};" +
                    "PASSWORD={3};", host, database, user, password);
                conString = MyConString;
                connection = new MySqlConnection(MyConString);
                connection.Open();
                return connection.State == System.Data.ConnectionState.Open;
            }
            catch (Exception ex)
            {
                Log.Append(this, "MySQL Connect " + ex.Message, Log.ExceptionsLog);
            }
            return false;
        }

        public bool Close()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public QueryResult ExecuteSQL(String sql)
        {
            QueryResult result = QueryResult.Default;
            try
            {                
                connection = new MySqlConnection(conString);
                connection.Open();

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = sql;

                result = new QueryResult(command.ExecuteNonQuery());
            }
            catch
            {

            }
            return result;
        }

        public QueryResult TableExists(String table)
        {
            QueryResult result = QueryResult.Default;
            try
            {

                MySqlCommand command = connection.CreateCommand();
                String sql = String.Format("SHOW TABLES LIKE '{0}';",table);
                command.CommandText = sql;
                var reader = command.ExecuteReader(CommandBehavior.SingleResult);
                bool hasRows = reader.HasRows;
                result = new QueryResult(0, hasRows, false, null);

                reader.Close();                
            }
            catch (Exception ex)
            {
                result = new QueryResult(ex);
            }
            return result;
        }

        public QueryResult Insert(String table, String[] columns, Object[] arguments, String where)
        {
            QueryResult result = QueryResult.Default;
            try
            {
                MySqlCommand command = connection.CreateCommand();
                String sql = GenerateInsert(table, columns, arguments, where);
                command.CommandText = sql;
                result = new QueryResult(command.ExecuteNonQuery());
            }
            catch (Exception ex)
            {
                result = new QueryResult(ex);
            }
            return result;
        }

        public QueryResult Insert(String table, String[] columns, Object[] arguments)
        {
            return Insert(table, columns, arguments, String.Empty);
        }

        public QueryResult Update(String table, String[] columns, Object[] arguments)
        {
            return Update(table, columns, arguments, String.Empty);
        }

        public QueryResult Update(string table, string[] columns, object[] arguments, string where)
        {
            QueryResult result = QueryResult.Default;
            try
            {
                MySqlCommand command = connection.CreateCommand();
                String sql = GenerateUpdate(table, columns, arguments, where);
                command.CommandText = sql;
                result = new QueryResult(command.ExecuteNonQuery());
                return result;
            }
            catch (Exception ex)
            {
                result = new QueryResult(ex);
            }
            return result;
        }

        public QueryResult IsInTable(String table, String column, String compareColumn, Object value)
        {
            QueryResult result = QueryResult.Default;
            try
            {
                String c = "";
                if (value is String)
                    c = "'";

                MySqlCommand command = connection.CreateCommand();
                String sql = String.Format("SELECT {0} FROM {1} WHERE {2} = {3}{4}{5};", column, table, compareColumn, c, value, c);
                command.CommandText = sql;
                var reader = command.ExecuteReader( CommandBehavior.SingleResult );
                bool hasRows = reader.HasRows;
                result = new QueryResult(0, hasRows, false, null);
                reader.Close();
            }
            catch (Exception ex)
            {
                result = new QueryResult(ex);
            }
            return result;
        }

        public Object[][] SelectDataSet(String query)
        {
            try
            {
                MySqlCommand command = connection.CreateCommand();
                String sql = query;
                command.CommandText = sql;
                var reader = command.ExecuteReader();
                Object[][] data = new Object[reader.FieldCount][];
                int i = 0;
                while (reader.Read())
                {
                    data[i] = new object[reader.FieldCount];
                    reader.GetValues(data[i]);
                    i++;
                }
                reader.Close();
                return data;
            }
            catch
            {

            }
            return null;
        }

        public String GenerateInsert(String table, String[] columns, Object[] arguments, String where)
        {
            return String.Format("INSERT INTO {0} ({1}) VALUES ({2}) {3};", table, BuildColumns(columns, ", "), BuildValues(arguments, ", "), where);
        }

        public String GenerateUpdate(String table, String[] columns, Object[] arguments, String where)
        {
            return String.Format("UPDATE {0} SET {1} {2};", table, BuildUpdatePairs(columns,arguments,", "), where);
        }

        public static String BuildUpdatePairs(String[] columns, Object[] array, String splitter)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                String c = "";
                if (array[i] is String)
                {
                    c = "'";
                }

                if (i != array.Length - 1)
                {
                    builder.AppendFormat("{0} = {1}{2}{3}{4}",columns[i], c ,array[i], c, splitter);
                }
                else
                {
                    builder.AppendFormat("{0} = {1}{2}{3}", columns[i], c, array[i], c);
                }
            }
            return builder.ToString();
        }

        public static String BuildValues(Object[] array, String splitter)
        {
            StringBuilder builder = new StringBuilder();            

            for (int i = 0; i < array.Length; i++)
			{
                String c = "";
                if (array[i] is String)
                {
                    c = "'";
                }

                if (i != array.Length-1)
                {
                    builder.AppendFormat("{0}{1}{2}{3}",c,array[i],c,splitter);
                }
                else
                {
                    builder.AppendFormat("{0}{1}{2}", c, array[i], c);
                }
			}
            return builder.ToString();
        }

        public static String BuildColumns(Object[] array, String splitter)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (i != array.Length - 1)
                {
                    builder.AppendFormat("{0}{1}", array[i], splitter);
                }
                else
                {
                    builder.AppendFormat("{0}", array[i]);
                }
            }
            return builder.ToString();
        }

        public ConnectionState State
        {
            get { return  connection == null ? System.Data.ConnectionState.Closed : connection.State; }
        }

        MySqlConnection connection = null;
        string conString = "";
    }
}
