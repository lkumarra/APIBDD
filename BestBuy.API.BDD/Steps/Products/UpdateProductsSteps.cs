using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Enum.DataEnum;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using BestBuy.API.BDD.Helpers.StringExtension;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class UpdateProductsSteps
    {
        UpdateProducts _updateProducts;

        UpdateProductsSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            _updateProducts = new UpdateProducts(responseValidator);
            context.Set<BaseAPI>(_updateProducts);
        }

        [When(@"I try to update a product with prductId as '(.*)', name as '(.*)', type as '(.*)', price as '(.*)', shipping as '(.*)', upc as '(.*)',description as '(.*)',manufacturer as '(.*)', model as '(.*)', url as '(.*)' image as '(.*)'")]
        [When(@"I update a product with prductId as '(.*)', name as '(.*)', type as '(.*)', price as '(.*)', shipping as '(.*)', upc as '(.*)',description as '(.*)',manufacturer as '(.*)', model as '(.*)',url as '(.*)' image as '(.*)'")]
        public void WhenIUpdateAProductWithPrductIdAsNameAsTypeAsPriceAsShippingAsUpcAsDescriptionAsManufacturerAsModelAsUrlAsImageAs(Product_DataEnum product_DataEnum, string name, string type, int price, int shipping, string upc, string description, string manufacturer, string model, string url, string image)
        {
            name = name.RequestStringParser();
            type = type.RequestStringParser();
            upc = upc.RequestStringParser();
            description = description.RequestStringParser();
            manufacturer = manufacturer.RequestStringParser();
            model = model.RequestStringParser();
            image = image.RequestStringParser();
            url = url.RequestStringParser();
            _updateProducts.ExecuteUpdateProductAPI((int)product_DataEnum, name, type, price, shipping, upc, description, manufacturer, model, url, image);
        }

        [Then(@"Verify product updated in Db\.")]
        public void ThenVerifyProductUpdatedInDb_()
        {
            _updateProducts.VerifyProductUpdatedInDb();
        }

    }
}
