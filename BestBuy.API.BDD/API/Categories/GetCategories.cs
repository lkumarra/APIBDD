using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Categories;
using BestBuy.API.BDD.Modals.Categories;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BestBuy.API.BDD.API.Categories
{
    class GetCategories : BaseAPI
    {
        public GetCategories() : base("/categories")
        {

        }

        public void ExecuteGetCategoriesAPI()
        {
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        public void VerifyCategoriesListFromDB()
        {
            GetCategoriesModal actualResponse = JsonConvert.DeserializeObject<GetCategoriesModal>(_resposeWrapper.Content);
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
