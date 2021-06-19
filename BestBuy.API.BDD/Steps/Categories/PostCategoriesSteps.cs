using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Categories;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using BestBuy.API.BDD.Helpers.StringExtension;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Categories
{
    [Binding]
    public class PostCategoriesSteps
    {
        PostCategories _postCategories;

        PostCategoriesSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            _postCategories = new PostCategories(responseValidator);
            context.Set<BaseAPI>(_postCategories);
        }
        [When(@"I try to create a category with id as '(.*)'and name as '(.*)'")]
        [When(@"I create a category with id as '(.*)' and name as '(.*)'")]
        public void WhenICreateACategoryWithIdAsAndNameAs(string Id, string name)
        {
            Id = Id.RequestStringParser();
            name = name.RequestStringParser();
            _postCategories.ExecutePostCategoriesAPI(Id, name);
        }


        [Then(@"Verify Category created in DB\.")]
        public void ThenVerifyCategoryCreatedInDB_()
        {
            _postCategories.VerifyCategoryCreatedInDb();
        }
    }
}
