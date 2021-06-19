using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Services;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Services
{
    [Binding]
    public class GetServicesSteps
    {
        GetServices getServices;

        GetServicesSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            getServices = new GetServices(responseValidator);
            context.Set<BaseAPI>(getServices);
        }

        [When(@"I get all services")]
        public void WhenIGetAllServices()
        {
            getServices.ExecuteGetServicesAPI();
        }
        
        [Then(@"Verify the services list from Db")]
        public void ThenVerifyTheServicesListFromDb()
        {
            getServices.VerifyServicesListFromDB();
        }
    }
}
