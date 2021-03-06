using BestBuy.API.BDD.Helpers.APIHelpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Categories;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeFeature(tags: new string[] { "PostProducts" }, Order = 1)]
        public static void DeleteProductFromDB()
        {
            ProductsDBHelper.DeleteAddedProductFromDB();
        }

        [BeforeFeature(tags: new string[] { "DeleteProducts", "PatchProducts" }, Order = 2)]
        public static void CreateProductData()
        {
            ProductsDBHelper.DeleteProductData();
            ProductsDBHelper.CreatedProductData();
        }

        [BeforeFeature(tags: new string[] { "PostCategories" }, Order = 3)]
        public static void DeleteCategoryData()
        {
            CategoriesDBHelper.DeleteCategory();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            APIServerStart.StartAPIServer();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            APIServerStart.StopAPIServer();
        }
    }
}
