using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Stores;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class GetStoresSteps
    {

        GetStores getStores;

        GetStoresSteps(ResponseValidator responseValidator, ScenarioContext context)
        {
            getStores = new GetStores(responseValidator);
            context.Set<BaseAPI>(getStores);
        }

        [When(@"I get all stores")]
        public void WhenIGetAllStores()
        {
            getStores.ExecuteGetStoresBaseAPI();
        }

        [Then(@"Verify the stores list from Db")]
        public void ThenVerifyTheStoresListFromDb()
        {
            getStores.VerifyResponseFromDB();
        }
    }
}
