using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class GetProductsSteps
    {
        GetProducts getProducts;

        GetProductsSteps(ResponseValidator responseValidator, ScenarioContext context)
        {
            getProducts = new GetProducts(responseValidator);
            context.Set<BaseAPI>(getProducts);
        }

        [When(@"I get all products")]
        public void WhenIGetAllProducts()
        {
            getProducts.ExecuteProductsAPI();
        }


        [Then(@"Verify the products list from Db")]
        public void ThenVerifyTheProductsListFromDb()
        {
            getProducts.VerifyProductsFromDB();
        }
    }
}
