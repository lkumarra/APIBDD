using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Enum.DataEnum;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class DeleteProductSteps
    {
        DeleteProduct _deleteProduct;

        DeleteProductSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            _deleteProduct = new DeleteProduct(responseValidator);
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
