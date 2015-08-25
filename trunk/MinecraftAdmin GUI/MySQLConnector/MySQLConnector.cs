using System;
using System.Collections.Generic;
using System.Text;

namespace MySQLConnector
{
    public class MySQLConnector
    {
        MySqlConnection connection;
        string conString = "";

        public MySQLConnector(String bla)
        {            
            try
            {
                string MyConString = "SERVER=217.160.16.235;" +
                    "DATABASE=zma_tool;" +
                    "UID=zma_app;" +
                    "PASSWORD=hldcoxra;";
                conString = MyConString;
                connection = new MySqlConnection(MyConString);
                //MySqlDataReader Reader;
                //command.CommandText = "select * from mycustomers";

                //Reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                Log.Append(this, "MySQL Connect " + ex.Message, Log.ExceptionsLog);
            }
        }
    }
}
