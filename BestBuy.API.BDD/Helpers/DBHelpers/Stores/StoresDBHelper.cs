using BestBuy.API.BDD.Modals.Strores;
using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.DBHelpers.Stores
{
    class StoresDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Stores\";

        public static List<Datum> GetStoresList()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetStores.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script);
            return new List<Datum>(table.AsEnumerable().Select(st => new Datum()
            {
                id = st.Field<Int64>("id"),
                name = st.Field<string>("name"),
                type = st.Field<string>("type"),
                address = st.Field<string>("address"),
                address2 = st.Field<string>("address2"),
                city = st.Field<string>("city"),
                state = st.Field<string>("state"),
                zip = st.Field<string>("zip"),
                lat = st.Field<Decimal>("lat"),
                lng = st.Field<Decimal>("lng"),
                hours = st.Field<string>("hours"),
                createdAt = st.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = st.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                services = StoresDBHelper.GetServicesList(st.Field<Int64>("id"))
            }));
        }

        public static List<Service> GetServicesList(long storeid)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetServices.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter(){
                    ParameterName = "@storeid",
                    Value = storeid
                }
            });
            return new List<Service>(table.AsEnumerable().Select(sr => new Service()
            {
                id = sr.Field<Int64>("id"),
                name = sr.Field<string>("name"),
                createdAt = sr.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = sr.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                storeservices = new Storeservices()
                {
                    createdAt = sr.Field<string>("stscreatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                    updatedAt = sr.Field<string>("stsupdatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                    storeId = sr.Field<Int64>("storeId"),
                    serviceId = sr.Field<Int64>("serviceId")
                }
            }));
        }

        public static int GetTotalStoresCount()
        {

            string script = File.ReadAllText(ScriptPath + "Script.GetTotalStoresCount.sql");
            return ExecuteDBWrapper.ExecuteQuery(script).Rows.Count;
        }

    }
}
