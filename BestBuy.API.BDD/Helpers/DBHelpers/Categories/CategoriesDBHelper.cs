using BestBuy.API.BDD.Modals.Categories;
using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.DBHelpers.Categories
{
    class CategoriesDBHelper
    {
        private static readonly string ScriptPath = ConfigHelper.BasePath + @"\Helpers\DBHelpers\Categories\";

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

        public static int GetTotalCategoriesCount()
        {
            string script = File.ReadAllText(ScriptPath + "Script.GetTotalCategories.sql");
            DataTable table = ExecuteDBWrapper.ExecuteQuery(script);
            return table.Rows.Count;
        }
    }
}
