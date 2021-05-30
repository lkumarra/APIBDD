using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Modals.GetProducts;
using Newtonsoft.Json;
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
            for (int i = 0; i<actualResponse.data.Count; i++)
            {
                for (int j = 0; j<actualResponse.data[i].categories.Count; j++)
                {
                    actualResponse.data[i].categories[j].productid = actualResponse.data[i].id;
                }
            }
            DataTable table = GetProductsDBHelper.GetAllProductsFromDB();
            List<Category> categoriesList = GetProductsDBHelper.GetFilterdCategories().AsEnumerable().Select(x => new Category()
            {
                productid = x.Field<long>("productid"),
                id = x.Field<string>("id"),
                name = x.Field<string>("name"),
                createdAt = x.Field<string>("createdAt"),
                updatedAt = x.Field<string>("updatedAt")
            }).OrderBy(y => y.id).ToList();
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
                createdAt = r.Field<string>("createdAt"),
                updatedAt = r.Field<string>("updatedAt"),
                categories = categoriesList.Where(x => x.productid == r.Field<long>("id")).ToList()
            }).ToList();
            GetProductsModal expectedResponse = new GetProductsModal()
            {
                total = GetProductsDBHelper.GetTotalProductsCount(),
                limit = 10,
                skip = 0,
                data = data
            };
            if (!actualResponse.Equals(expectedResponse))
            {
                Console.WriteLine("Response are not equal");
            }
        }
    }
}
