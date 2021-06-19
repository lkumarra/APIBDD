using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.GetProducts;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Products
{
    class GetProductViaId : BaseAPI
    {
        private int _id;
        public GetProductViaId(IResponseValidator responseValidator) : base("/products", responseValidator)
        {

        }

        public void ExecuteGetProductViaIDAPI(int id)
        {
            _id = id;
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint + "/" + id);
        }

        public void VerifyProductFromDB()
        {
            Datum actualResponse = JsonConvert.DeserializeObject<Datum>(_response.responseWrapper.Content);
            Datum expectedResponse = ProductsDBHelper.GetProductsViaId(_id).FirstOrDefault();
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
