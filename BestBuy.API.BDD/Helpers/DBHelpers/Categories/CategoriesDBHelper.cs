using BestBuy.API.BDD.Modals.Categories;
using BestBuy.API.BDD.Wrapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;


namespace BestBuy.API.BDD.Helpers.DBHelpers.Categories
{
    class CategoriesDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Categories\";

        /// <summary>
        /// Get Categories list from DB.
        /// </summary>
        /// <returns></returns>
        public static List<Datum> GetCategoriesList()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetCategories.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script);
            return new List<Datum>(table.AsEnumerable().Select(c => new Datum()
            {
                id = c.Field<string>("id"),
                name = c.Field<string>("name"),
                createdAt = c.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = c.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                subCategories = CategoriesDBHelper.GetSubCategoriesList(c.Field<string>("id")),
                categoryPath = CategoriesDBHelper.GetCategoryPathList(c.Field<string>("id"))
            }));
        }

        /// <summary>
        /// Get Subcategories related to categories
        /// </summary>
        /// <param name="categoryId">Category id to fetch subcategories</param>
        /// <returns></returns>
        public static List<SubCategory> GetSubCategoriesList(string categoryId)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetSubCategories.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@categoryid",
                    Value = categoryId
                }
            });
            return new List<SubCategory>(table.AsEnumerable().Select(s => new SubCategory()
            {
                id = s.Field<string>("id"),
                name = s.Field<string>("name"),
                createdAt = s.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = s.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T")
            }));
        }

        /// <summary>
        /// Get Category path from DB
        /// </summary>
        /// <param name="categoryId">Category id to fetch category path</param>
        /// <returns></returns>
        public static List<CategoryPath> GetCategoryPathList(string categoryId)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetCategoryPath.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@categoryid",
                    Value = categoryId
                }
            });
            return new List<CategoryPath>(table.AsEnumerable().Select(cp => new CategoryPath()
            {
                id = cp.Field<string>("id"),
                name = cp.Field<string>("name"),
                createdAt = cp.Field<string>("createdAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = cp.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T")
            }));
        }

        /// <summary>
        /// Get total Category count from DB
        /// </summary>
        /// <returns></returns>
        public static int GetTotalCategoriesCount()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetTotalCategories.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script);
            return table.Rows.Count;
        }

        public static void DeleteCategory()
        {
            string script = File.ReadAllText(ScriptPath + "Script.DeleteCategory.sql");
            ExecuteDBWrapper.ExecuteNonQuery(script);
        }

        public static List<PostCategoriesModal> GetCategoriesViaId(string id)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetCategoryViaId.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@id",
                    Value = id
                }
            });
            return new List<PostCategoriesModal>(table.AsEnumerable().Select(cp => new PostCategoriesModal()
            {
                id = cp.Field<string>("id"),
                name = cp.Field<string>("name"),
            }));
        }

        public static List<Datum> GetCategoryListViaId(string id)
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetCategoryViaId.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script, new List<SQLiteParameter>() {
                new SQLiteParameter()
                {
                    ParameterName = "@id",
                    Value = id
                }
            });
            return new List<Datum>(table.AsEnumerable().Select(c => new Datum()
            {
                id = c.Field<string>("id"),
                name = c.Field<string>("name"),
                createdAt = c.Field<string>("createdAt")?.Replace(" +00:00", "Z").Replace(" ", "T"),
                updatedAt = c.Field<string>("updatedAt")?.Replace(" +00:00", "Z").Replace(" ", "T"),
                subCategories = CategoriesDBHelper.GetSubCategoriesList(c.Field<string>("id")),
                categoryPath = CategoriesDBHelper.GetCategoryPathList(c.Field<string>("id"))
            }));
        }
    }
}
