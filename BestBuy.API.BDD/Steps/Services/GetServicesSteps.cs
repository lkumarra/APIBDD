using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Services;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Services
{
    [Binding]
    public class GetServicesSteps
    {
        GetServices getServices;

        GetServicesSteps(ScenarioContext context)
        {
            getServices = new GetServices();
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
