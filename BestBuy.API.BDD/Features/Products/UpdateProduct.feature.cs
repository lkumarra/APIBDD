﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.8.0.0
//      SpecFlow Generator Version:3.8.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BestBuy.API.BDD.Features.Products
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.8.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Update Products")]
    [NUnit.Framework.CategoryAttribute("Products")]
    [NUnit.Framework.CategoryAttribute("PatchProducts")]
    public partial class UpdateProductsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "Products",
                "PatchProducts"};
        
#line 1 "UpdateProduct.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Products", "Update Products", "\tIn Order to post products\r\n\tI want to told to verify products\r\n\tAPI :- PATCH /pr" +
                    "oducts", ProgrammingLanguage.CSharp, new string[] {
                        "Products",
                        "PatchProducts"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a product")]
        [NUnit.Framework.CategoryAttribute("GetProducts")]
        [NUnit.Framework.CategoryAttribute("PositiveScenatio")]
        public virtual void UpdateAProduct()
        {
            string[] tagsOfScenario = new string[] {
                    "GetProducts",
                    "PositiveScenatio"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a product", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 9
 testRunner.Given("I am a valid user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.When(@"I update a product with prductId as 'AddedProduct', name as 'UpdatedProduct', type as 'UpdatedType', price as '10000', shipping as '200', upc as 'UpdatedUPC',description as 'UpdatedDescription',manufacturer as 'UpdatedManufacturer', model as 'UpdatedModel',url as 'UpdatedUrl' image as 'UpdatedImage'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 11
 testRunner.Then("Products should be updated with status code \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 12
 testRunner.And("Verify product updated in Db.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Update a product with invalid data")]
        [NUnit.Framework.CategoryAttribute("GetProducts")]
        [NUnit.Framework.CategoryAttribute("NegativeScenario")]
        [NUnit.Framework.TestCaseAttribute("Try to update product with producrId as Invalid", "Invalid", "UpdatedName", "UpdatedType", "1", "1", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "404", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with name as null", "AddedProduct", "NULL", "UpdatedType", "1", "1", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with name as null", "AddedProduct", "EMPTY", "UpdatedType", "2", "2", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with type as null", "AddedProduct", "UpdatedName", "NULL", "4", "4", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with type as empty", "AddedProduct", "UpdatedName", "EMPTY", "5", "5", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with upc as null", "AddedProduct", "UpdatedName", "UpdatedType", "13", "13", "NULL", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with upc as empty", "AddedProduct", "UpdatedName", "UpdatedType", "14", "14", "EMPTY", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with description as null", "AddedProduct", "UpdatedName", "UpdatedType", "16", "16", "AddedUpc1", "NULL", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with description as empty", "AddedProduct", "UpdatedName", "UpdatedType", "17", "17", "AddedUpc1", "EMPTY", "AddedManufacturer", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with manufacturer as null", "AddedProduct", "UpdatedName", "UpdatedType", "19", "19", "AddedUpc1", "AddedDescription", "NULL", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with manufacturer as empty", "AddedProduct", "UpdatedName", "UpdatedType", "20", "20", "AddedUpc1", "AddedDescription", "EMPTY", "AddedModel", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with model as null", "AddedProduct", "UpdatedName", "UpdatedType", "22", "22", "AddedUpc1", "AddedDescription", "AddedManufacturer", "NULL", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with model as empty", "AddedProduct", "UpdatedName", "UpdatedType", "23", "23", "AddedUpc1", "AddedDescription", "AddedManufacturer", "EMPTY", "AddedUrl", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with url as null", "AddedProduct", "UpdatedName", "UpdatedType", "25", "25", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "NULL", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with url as empty", "AddedProduct", "UpdatedName", "UpdatedType", "26", "26", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "EMPTY", "AddedImage", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with image as null", "AddedProduct", "UpdatedName", "UpdatedType", "28", "28", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "NULL", "400", null)]
        [NUnit.Framework.TestCaseAttribute("Try to create product with image as empty", "AddedProduct", "UpdatedName", "UpdatedType", "29", "29", "AddedUpc1", "AddedDescription", "AddedManufacturer", "AddedModel", "AddedUrl", "EMPTY", "400", null)]
        public virtual void UpdateAProductWithInvalidData(string scenario, string productId, string name, string type, string price, string shipping, string upc, string description, string manufacturer, string model, string url, string image, string statuscode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "GetProducts",
                    "NegativeScenario"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Scenario", scenario);
            argumentsOfScenario.Add("ProductId", productId);
            argumentsOfScenario.Add("Name", name);
            argumentsOfScenario.Add("type", type);
            argumentsOfScenario.Add("price", price);
            argumentsOfScenario.Add("shipping", shipping);
            argumentsOfScenario.Add("upc", upc);
            argumentsOfScenario.Add("description", description);
            argumentsOfScenario.Add("manufacturer", manufacturer);
            argumentsOfScenario.Add("model", model);
            argumentsOfScenario.Add("url", url);
            argumentsOfScenario.Add("image", image);
            argumentsOfScenario.Add("statuscode", statuscode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Update a product with invalid data", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 15
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 16
 testRunner.Given("I am a valid user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 17
 testRunner.When(string.Format("I try to update a product with prductId as \'{0}\', name as \'{1}\', type as \'{2}\', p" +
                            "rice as \'{3}\', shipping as \'{4}\', upc as \'{5}\',description as \'{6}\',manufacturer" +
                            " as \'{7}\', model as \'{8}\', url as \'{9}\' image as \'{10}\'", productId, name, type, price, shipping, upc, description, manufacturer, model, url, image), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 18
 testRunner.Then(string.Format("Products should not be updated with status code \'{0}\'", statuscode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
