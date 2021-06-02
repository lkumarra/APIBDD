using BestBuy.API.BDD.Modals.Services;
using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace BestBuy.API.BDD.Helpers.DBHelpers.Services
{
    class ServicesDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Services\";

        /// <summary>
        /// Get services list from db
        /// </summary>
        /// <returns></returns>
        public static List<Datum> GetServicesList()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetServices.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script);
            return new List<Datum>(table.AsEnumerable().Select(sr => new Datum() {
                id = sr.Field<Int64>("id"),
                name = sr.Field<string>("name"),
                createdAt = sr.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = sr.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T")
            }));
        }

        /// <summary>
        /// Get total services count from db
        /// </summary>
        /// <returns></returns>
        public static int GetTotalServicesCount()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetTotalServices.sql");
            return ExecuteDBWrapper.ExecuteQuery(script).Rows.Count;
        }
    }
}
