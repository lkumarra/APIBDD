using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Enum.DataEnum;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class DeleteProductSteps
    {
        private DeleteProduct _deleteProduct;

        DeleteProductSteps(ScenarioContext context)
        {
            _deleteProduct = new DeleteProduct();
            context.Set<BaseAPI>(_deleteProduct);
        }

        [When(@"I delete '(.*)'  product")]
        public void WhenIDeleteProduct(Product_DataEnum product_DataEnum)
        {
            _deleteProduct.ExecuteDeleteProductAPI((int)product_DataEnum);
        }
        
        [Then(@"Verify product deleted from DB\.")]
        public void ThenVerifyProductDeletedFromDB_()
        {
            _deleteProduct.VerifyProductDeletedFromDB();
        }
    }
}
