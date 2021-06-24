using BestBuy.API.BDD.Helpers.JSONParseHelper;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Wrapper;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.ResponseValidator
{
    class ResponseValidator : IResponseValidator
    {
        public ResponseWrapper responseWrapper { get; set; }

        public void VerifyResponse(ResponseModalWrapper responseModalWrapper)
        {
            if (responseWrapper.StatusCode != responseModalWrapper.code)
            {
                Assert.Fail("Expected status code is " + responseWrapper.StatusCode + "But acutal status code is" + responseModalWrapper.code);
            }
            if (responseWrapper.Content.Contains("name") && responseWrapper.Content.Contains("message") && responseWrapper.Content.Contains("errors") && responseWrapper.Content.Contains("data"))
            {
                if (!JSONParser.GetJSONParsedResult(responseWrapper.Content, "name").Equals(responseModalWrapper.name))
                {
                    Assert.Fail("Expected name is " + responseModalWrapper.name + "But actual name is" + JSONParser.GetJSONParsedResult(responseWrapper.Content, "name"));
                }
                if (!JSONParser.GetJSONParsedResult(responseWrapper.Content, "message").Equals(responseModalWrapper.message))
                {
                    Assert.Fail("Expected message is " + responseModalWrapper.message + "But actual message is" + JSONParser.GetJSONParsedResult(responseWrapper.Content, "message"));
                }
                if (!JSONParser.GetJSONParsedResult(responseWrapper.Content, "errors[0]").Equals(responseModalWrapper.errors))
                {
                    Assert.Fail("Expected error is " + responseModalWrapper.errors + "But actual error is" + JSONParser.GetJSONParsedResult(responseWrapper.Content, "errors[0]"));
                }
            }
            else if (responseWrapper.Content.Contains("name") && responseWrapper.Content.Contains("message") && responseWrapper.Content.Contains("errors"))
            {
                if (!JSONParser.GetJSONParsedResult(responseWrapper.Content, "name").Equals(responseModalWrapper.name))
                {
                    Assert.Fail("Expected name is " + responseModalWrapper.name + "But actual name is" + JSONParser.GetJSONParsedResult(responseWrapper.Content, "name"));
                }
                if (!JSONParser.GetJSONParsedResult(responseWrapper.Content, "message").Equals(responseModalWrapper.message))
                {
                    Assert.Fail("Expected message is " + responseModalWrapper.message + "But actual message is" + JSONParser.GetJSONParsedResult(responseWrapper.Content, "message"));
                }
            }
        }
    }
}
