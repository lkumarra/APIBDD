using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Wrapper;
using NUnit.Framework;


namespace BestBuy.API.BDD.API
{
    class BaseAPI
    {
        protected string _endpoint;
        protected static IResponseValidator _response;

        public BaseAPI(string endpoint, IResponseValidator response)
        {
            _endpoint = endpoint;
            _response = response;
        }

        /// <summary>
        /// Verify response returned by hitting API
        /// </summary>
        /// <param name="responseWrapper"></param>
        public void VerifyResponse(ResponseModalWrapper responseWrapper)
        {
            _response.VerifyResponse(responseWrapper);
        }
    }
}
