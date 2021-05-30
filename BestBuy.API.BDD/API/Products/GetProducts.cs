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
            DataTable table = GetProductsDBHelper.GetAllProductsFromDB();
        }
    }
}
