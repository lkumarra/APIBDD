using BestBuy.API.BDD.API;
using BestBuy.API.BDD.API.Products;
using BestBuy.API.BDD.Helpers.ResponseValidator;
using BestBuy.API.BDD.Helpers.StringExtension;
using System;
using TechTalk.SpecFlow;

namespace BestBuy.API.BDD.Steps.Products
{
    [Binding]
    public class PostProductsSteps
    {
        PostProducts _postProducts;

        PostProductsSteps(ResponseValidator responseValidator,ScenarioContext context)
        {
            _postProducts = new PostProducts(responseValidator);
            context.Set<BaseAPI>(_postProducts);
        }
        [When(@"I create a product with name as '(.*)', type as '(.*)', price as '(.*)', shipping as '(.*)', upc as '(.*)',description as '(.*)',manufacturer as '(.*)', model as '(.*)',url as '(.*)' image as '(.*)'")]
        [When(@"I try create a product with name as '(.*)', type as '(.*)', price as '(.*)', shipping as '(.*)', upc as '(.*)',description as '(.*)',manufacturer as '(.*)', model as '(.*)', url as '(.*)' image as '(.*)'")]
        public void WhenICreateAProductWithNameAsTypeAsPriceAsShippingAsUpcAsDescriptionAsManufacturerAsModelAsImageAs(string name, string type, int price, int shipping, string upc, string description, string manufacturer, string model, string url, string image)
        {
            name = name.RequestStringParser();
            type = type.RequestStringParser();
            upc = upc.RequestStringParser();
            description = description.RequestStringParser();
            manufacturer = manufacturer.RequestStringParser();
            model = model.RequestStringParser();
            image = image.RequestStringParser();
            url = url.RequestStringParser();
            _postProducts.ExecutePostProductsAPI(name, type, price, shipping, upc, description, manufacturer, model, url, image);
        }



        [Then(@"Verify product created in Db\.")]
        public void ThenVerifpProductCreatedInDb_()
        {
            _postProducts.VerifyProductCreatedInDB();
        }
    }
}
