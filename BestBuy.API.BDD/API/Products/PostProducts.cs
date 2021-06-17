using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Modals.Products;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Products
{
    class PostProducts : BaseAPI
    {
        private PostProductModal _productsModal;
        private string _name;
        public PostProducts() : base("/products")
        {

        }

        public void ExecutePostProductsAPI(string name, string type, int price, int shipping, string upc, string description, string manufacturer, string modal, string url, string image)
        {
            _name = name;
            _productsModal = new PostProductModal()
            {
                name = name,
                type = type,
                price = price,
                shipping = shipping,
                upc = upc,
                description = description,
                manufacturer = manufacturer,
                model = modal,
                url = url,
                image = image
            };
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformPostRequest(_endpoint, JsonConvert.SerializeObject(_productsModal));
        }

        public void VerifyProductCreatedInDB()
        {
            PostProductModal dataFromDB = ProductsDBHelper.GetProductAddedInDB(_name).FirstOrDefault();
            if (!_productsModal.Equals(dataFromDB))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(_productsModal) + " but actual response  is " + JsonConvert.SerializeObject(dataFromDB));
            }
        }
    }
}
