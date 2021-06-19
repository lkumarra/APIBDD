using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Categories;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.Categories;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Categories
{
    class GetCategoryViaId : BaseAPI
    {
        private string _id;
        public GetCategoryViaId(IResponseValidator responseValidator) : base("/categories",responseValidator)
        {

        }

        public void ExecuteGetCategoriesViaIdAPI(string id)
        {
            _id = id;
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint + "/" + id);
        }

        public void VerifyGetCategoiesIdFromDB()
        {
            Datum actualResponse = JsonConvert.DeserializeObject<Datum>(_response.responseWrapper.Content);
            Datum expectedResponse = CategoriesDBHelper.GetCategoryListViaId(_id).FirstOrDefault();
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
