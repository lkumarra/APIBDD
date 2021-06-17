using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
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
        public GetProductViaId() : base("/products")
        {

        }

        public void ExecuteGetProductViaIDAPI(int id)
        {
            _id = id;
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint + "/" + id);
        }

        public void VerifyProductFromDB()
        {
            Datum actualResponse = JsonConvert.DeserializeObject<Datum>(_resposeWrapper.Content);
            Datum expectedResponse = ProductsDBHelper.GetProductsViaId(_id).FirstOrDefault();
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
