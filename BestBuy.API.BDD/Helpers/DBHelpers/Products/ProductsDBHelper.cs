using BestBuy.API.BDD.Modals.GetProducts;
using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.DBHelpers.Products
{
    class ProductsDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Products\";

        public static DataTable GetAllProductsFromDB()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetProducts.sql");
            return ExecuteDBWrapper.ExecuteQuery(script);
        }

        public static List<Category> GetFilterdCategories(long productId)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetCategoriesFilterd.sql");
            return ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@productid",
                    Value = productId
                }
            }).AsEnumerable().Select(x => new Category()
            {
                id = x.Field<string>("id"),
                name = x.Field<string>("name"),
                createdAt = x.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = x.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T")
            }).OrderBy(y => y.id).ToList(); ;
        }

        public static int GetTotalProductsCount()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetTotalProductsCount.sql");
            return ExecuteDBWrapper.ExecuteQuery(script).Rows.Count;
        }
    }
}
