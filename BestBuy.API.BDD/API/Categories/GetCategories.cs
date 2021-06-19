using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Categories;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.Categories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BestBuy.API.BDD.API.Categories
{
    class GetCategories : BaseAPI
    {
        public GetCategories(IResponseValidator responseValidator) : base("/categories", responseValidator)
        {

        }

        /// <summary>
        /// Execute GetCategories API
        /// </summary>
        public void ExecuteGetCategoriesAPI()
        {
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        /// <summary>
        /// Verify the Categories List from DB
        /// </summary>
        public void VerifyCategoriesListFromDB()
        {
            GetCategoriesModal actualResponse = JsonConvert.DeserializeObject<GetCategoriesModal>(_response.responseWrapper.Content);
            GetCategoriesModal expectedResponse = new GetCategoriesModal()
            {
                data = CategoriesDBHelper.GetCategoriesList(),
                skip = 0,
                limit = 10,
                total = CategoriesDBHelper.GetTotalCategoriesCount()
            };
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
