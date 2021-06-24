using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.GetProducts;
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
    class UpdateProducts : BaseAPI
    {
        private string _name;
        private PostProductModal _productsModal;

        public UpdateProducts(IResponseValidator responseValidator) : base("/products", responseValidator)
        {

        }

        /// <summary>
        /// Execute Put /product API
        /// </summary>
        /// <param name="id">Id of the product to update</param>
        /// <param name="name">Name of the product</param>
        /// <param name="type">Type of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="shipping">Shipping of the product</param>
        /// <param name="upc">Upc of the product</param>
        /// <param name="description">Description of the product</param>
        /// <param name="manufacturer">Manufacturer of the product</param>
        /// <param name="modal">Modal of the product</param>
        /// <param name="url">Url of the product</param>
        /// <param name="image">Image of the product</param>
        internal void ExecuteUpdateProductAPI(int id, string name, string type, int price, int shipping, string upc, string description, string manufacturer, string modal, string url, string image)
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
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformPatchRequest(_endpoint+"/"+id, JsonConvert.SerializeObject(_productsModal));
        }

        /// <summary>
        /// Verify product updated in DB
        /// </summary>
        internal void VerifyProductUpdatedInDb()
        {

            PostProductModal dataFromDB = ProductsDBHelper.GetProductAddedInDB(_name).FirstOrDefault();
            if (!_productsModal.Equals(dataFromDB))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(_productsModal) + " but actual response  is " + JsonConvert.SerializeObject(dataFromDB));
            }
        }
    }
}
