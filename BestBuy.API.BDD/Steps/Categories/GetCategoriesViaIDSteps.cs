using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Categories;
using BestBuy.API.BDD.Enum.DataEnum;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Categories
{
    [Binding]
    public class GetCategoriesViaIDSteps
    {
        private GetCategoryViaId _getCategoriesViaId;

        public GetCategoriesViaIDSteps(ScenarioContext context)
        {
            _getCategoriesViaId = new GetCategoryViaId();
            context.Set<BaseAPI>(_getCategoriesViaId);
        }

        [When(@"I get category with id a '(.*)'")]
        public void WhenIGetCategoryWithIdA(Categories_DataEnum dataEnum)
        {
            string id = CategoriesData.GetEnumString(dataEnum);
            _getCategoriesViaId.ExecuteGetCategoriesViaIdAPI(id);
        }
        
        [Then(@"Verify the category from Db")]
        public void ThenVerifyTheCategoryFromDb()
        {
            _getCategoriesViaId.VerifyGetCategoiesIdFromDB();
        }
    }
}
