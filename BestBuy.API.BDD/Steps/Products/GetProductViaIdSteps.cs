using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Enum.DataEnum;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class GetProductViaIdSteps
    {
        GetProductViaId _getProductViaId;

        GetProductViaIdSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            _getProductViaId = new GetProductViaId(responseValidator);
            context.Set<BaseAPI>(_getProductViaId);
        }
        [When(@"I get '(.*)' product")]
        public void WhenIGetProduct(Product_DataEnum product_DataEnum)
        {
            _getProductViaId.ExecuteGetProductViaIDAPI((int)product_DataEnum);
        }

        [Then(@"Verify the product from Db")]
        public void ThenVerifyTheProductFromDb()
        {
            _getProductViaId.VerifyProductFromDB();
        }
    }
}
