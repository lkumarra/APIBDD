using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Services;
using BestBuy.API.BDD.Modals.Services;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BestBuy.API.BDD.API.Services
{
    class GetServices:BaseAPI
    {
        public GetServices() : base("/services")
        {

        }

        public void ExecuteGetServicesAPI()
        {
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        public void VerifyServicesListFromDB()
        {
            GetServicesModal actualResponse = JsonConvert.DeserializeObject<GetServicesModal>(_resposeWrapper.Content);
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
