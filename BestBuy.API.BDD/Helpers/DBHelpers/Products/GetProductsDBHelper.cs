using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.DBHelpers.Products
{
    class GetProductsDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Products\";

        public static DataTable GetAllProductsFromDB()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetProducts.sql");
            return ExecuteDBWrapper.ExecuteQuery(script);
        }
    }
}
