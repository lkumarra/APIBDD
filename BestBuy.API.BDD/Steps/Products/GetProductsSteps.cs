using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class GetProductsSteps
    {
        GetProducts getProducts;

        GetProductsSteps(ScenarioContext context)
        {
            getProducts = new GetProducts();
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
