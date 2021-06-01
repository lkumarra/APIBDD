using BestBuy.API.BDD.Wrapper;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.API
{
    class BaseAPI
    {
        protected string _endpoint;
        protected static ResponseWrapper _resposeWrapper;

        public BaseAPI(string endpoint)
        {
            _endpoint = endpoint;
        }

        public BaseAPI()
        {

        }

        public virtual void VerifyResponse(int statusCode)
        {
            if (_resposeWrapper.StatusCode != statusCode)
            {
                Assert.Fail("Expected status code is " + statusCode + " but actual status code is " + _resposeWrapper.StatusCode);
            }
        }
    }
}
