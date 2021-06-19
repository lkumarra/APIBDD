using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Services;
using BestBuy.API.BDD.Interface;
using BestBuy.API.BDD.Modals.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BestBuy.API.BDD.API.Services
{
    class GetServices : BaseAPI
    {
        public GetServices(IResponseValidator responseValidator) : base("/services", responseValidator)
        {

        }

        /// <summary>
        /// Execute GetServices API
        /// </summary>
        public void ExecuteGetServicesAPI()
        {
            _response.responseWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        /// <summary>
        /// Verify the services list from DB
        /// </summary>
        public void VerifyServicesListFromDB()
        {
            GetServicesModal actualResponse = JsonConvert.DeserializeObject<GetServicesModal>(_response.responseWrapper.Content);
            GetServicesModal expectedResponse = new GetServicesModal()
            {
                total = ServicesDBHelper.GetTotalServicesCount(),
                limit = 10,
                skip = 0,
                data = ServicesDBHelper.GetServicesList()
            };
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
