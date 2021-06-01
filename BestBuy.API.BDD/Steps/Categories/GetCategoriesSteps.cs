using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Categories;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Categories
{
    [Binding]
    public class GetCategoriesSteps
    {
        GetCategories getCategories;

        GetCategoriesSteps(ScenarioContext scenario)
        {
            getCategories = new GetCategories();
            scenario.Set<BaseAPI>(getCategories);
        }

        [When(@"I get all categories")]
        public void WhenIGetAllCategories()
        {
            getCategories.ExecuteGetCategoriesAPI();
        }

        [Then(@"Verify the categories list from Db")]
        public void ThenVerifyTheCategoriesListFromDb()
        {
            getCategories.VerifyCategoriesListFromDB();
        }
    }
}
