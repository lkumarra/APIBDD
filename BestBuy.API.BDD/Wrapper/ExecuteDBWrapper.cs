using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace BestBuy.API.BDD.Wrapper
{
    class ExecuteDBWrapper
    {
        static string DataBasePath = ConfigurationManager.AppSettings["SqlClientPath"];


        public static DataTable ExecuteQuery(string query, List<SQLiteParameter> parameters = null)
        {
            // Create a new database connection:
            SQLiteConnection sqlite_conn = new SQLiteConnection(DataBasePath);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.CommandType = CommandType.Text;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    sqlite_cmd.Parameters.Add(param);
                }
            }
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqlite_datareader);
            sqlite_conn.Close();
            return table;
        }

        public static void ExecuteNonQuery(string query, List<SQLiteParameter> parameters = null)
        {
            // Create a new database connection:
            SQLiteConnection sqlite_conn = new SQLiteConnection(DataBasePath);
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.CommandType = CommandType.Text;
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    sqlite_cmd.Parameters.Add(param);
                }
            }
            int rowsAffected = sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
        }
    }
}
