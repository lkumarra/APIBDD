using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Products;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.GetProducts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API.Products
{
    class DeleteProduct : BaseAPI
    {
        private int _id;

        public DeleteProduct(IResponseValidator responseValidator) : base("/products", responseValidator)
        {

        }

        /// <summary>
        /// Execute Delete /product/{id} API
        /// </summary>
        /// <param name="id">Id to delete category</param>
        public void ExecuteDeleteProductAPI(int id)
        {
            _id = id;
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformDeleteRequest(_endpoint + "/" + id.ToString());
        }

        /// <summary>
        /// Verify product is deleted from DB.
        /// </summary>
        public void VerifyProductDeletedFromDB()
        {
            Datum datum = ProductsDBHelper.GetProductsViaId(_id).FirstOrDefault();
            if (datum != null)
            {
                Assert.Fail("Product" + _id + "not deleted from DB");
            }
        }
    }
}
