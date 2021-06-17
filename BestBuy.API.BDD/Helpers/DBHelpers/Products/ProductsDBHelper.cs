using BestBuy.API.BDD.Modals.GetProducts;
using BestBuy.API.BDD.Modals.Products;
using BestBuy.API.BDD.Wrapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;


namespace BestBuy.API.BDD.Helpers.DBHelpers.Products
{
    class ProductsDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Products\";

        /// <summary>
        /// Get all prducts from db
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllProductsFromDB()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetProducts.sql");
            return ExecuteDBWrapper.ExecuteQuery(script);
        }

        /// <summary>
        /// Get categories of product from Db
        /// </summary>
        /// <param name="productId">Product id to fetch categories </param>
        /// <returns></returns>
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

        /// <summary>
        /// Get total count of product from db.
        /// </summary>
        /// <returns></returns>
        public static int GetTotalProductsCount()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetTotalProductsCount.sql");
            return ExecuteDBWrapper.ExecuteQuery(script).Rows.Count;
        }

        public static List<PostProductModal> GetProductAddedInDB(string name)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetProductViaName.sql");
            return ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@name",
                    Value = name
                }
            }).AsEnumerable().Select(x => new PostProductModal()
            {
                name = x.Field<string>("name"),
                type = x.Field<string>("type"),
                price = x.Field<decimal>("price"),
                upc = x.Field<string>("upc"),
                shipping = x.Field<decimal>("shipping"),
                description = x.Field<string>("description"),
                manufacturer = x.Field<string>("manufacturer"),
                model = x.Field<string>("model"),
                url = x.Field<string>("url"),
                image = x.Field<string>("image")
            }).ToList();
        }

        public static void DeleteAddedProductFromDB()
        {
            string script = File.ReadAllText(ScriptPath + "Script.DeleteAddedProduct.sql");
            ExecuteDBWrapper.ExecuteNonQuery(script);
        }
    }
}
