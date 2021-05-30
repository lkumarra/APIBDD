using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Wrapper
{
    class ExecuteDBWrapper
    {
        static string DataBasePath = ConfigurationManager.AppSettings["SqlClientPath"];

        
        public static DataTable ExecuteQuery(string query)
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

            }
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(sqlite_datareader);
            sqlite_conn.Close();
            return table;
        }
    }
}
