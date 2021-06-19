using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals;
using BestBuy.API.BDD.Modals.ErrorModals;
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
                ErrorModal modal = JsonConvert.DeserializeObject<ErrorModal>(responseWrapper.Content);
                if (!modal.name.Equals(responseModalWrapper.name))
                {
                    Assert.Fail("Expected name is " + responseModalWrapper.name + "But actual name is" + modal.name);
                }
                if (!modal.message.Equals(responseModalWrapper.message))
                {
                    Assert.Fail("Expected message is " + responseModalWrapper.message + "But actual message is" + modal.message);
                }
                if (!modal.errors[0].Equals(responseModalWrapper.errors))
                {
                    Assert.Fail("Expected error is " + responseModalWrapper.errors + "But actual error is" + modal.errors[0]);
                }
            }
            else if (responseWrapper.Content.Contains("name") && responseWrapper.Content.Contains("message") && responseWrapper.Content.Contains("errors"))
            {
                NotFoundErrorModal notFoundErrorModal = JsonConvert.DeserializeObject<NotFoundErrorModal>(responseWrapper.Content);
                if (!notFoundErrorModal.name.Equals(responseModalWrapper.name))
                {
                    Assert.Fail("Expected name is " + responseModalWrapper.name + "But actual name is" + notFoundErrorModal.name);
                }
                if (!notFoundErrorModal.message.Equals(responseModalWrapper.message))
                {
                    Assert.Fail("Expected message is " + responseModalWrapper.message + "But actual message is" + notFoundErrorModal.message);
                }

            }
        }
    }
}
