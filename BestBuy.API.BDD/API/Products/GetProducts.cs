using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Modals.GetProducts;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Products
{
    class GetProducts : BaseAPI
    {
        public GetProducts() : base("/products")
        {

        }

        public void ExecuteProductsAPI()
        {
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        public void VerifyProductsFromDB()
        {
            GetProductsModal actualResponse = JsonConvert.DeserializeObject<GetProductsModal>(_resposeWrapper.Content);
            DataTable table = ProductsDBHelper.GetAllProductsFromDB();
            List<Datum> data = table.AsEnumerable().Select(r => new Datum()
            {
                id = r.Field<long>("id"),
                name = r.Field<string>("name"),
                type = r.Field<string>("type"),
                price = r.Field<Decimal>("price"),
                upc = r.Field<string>("upc"),
                shipping = r.Field<Decimal>("shipping"),
                description = r.Field<string>("description"),
                manufacturer = r.Field<string>("manufacturer"),
                model = r.Field<string>("model"),
                url = r.Field<string>("url"),
                image = r.Field<string>("image"),
                createdAt = r.Field<string>("createdAt").Replace(" +00:00","Z").Replace(" ","T"),
                updatedAt = r.Field<string>("updatedAt").Replace(" +00:00", "Z").Replace(" ", "T"),
                categories = ProductsDBHelper.GetFilterdCategories(r.Field<long>("id"))
            }).ToList();
            GetProductsModal expectedResponse = new GetProductsModal()
            {
                total = ProductsDBHelper.GetTotalProductsCount(),
                limit = 10,
                skip = 0,
                data = data
            };
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
