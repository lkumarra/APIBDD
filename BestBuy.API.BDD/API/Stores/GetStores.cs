using BestBuy.API.BDD.Helpers;
using BestBuy.API.BDD.Helpers.DBHelpers.Stores;
using BestBuy.API.BDD.Modals.Strores;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BestBuy.API.BDD.API.Stores
{
    class GetStores : BaseAPI
    {
        public GetStores() : base("/stores")
        {

        }

        /// <summary>
        /// Execute GetStores API from DB.
        /// </summary>
        public void ExecuteGetStoresBaseAPI()
        {
            _resposeWrapper = ConfigHelper._httpClientHelper.PerformGetRequest(_endpoint);
        }

        /// <summary>
        /// Verify Stores List from DB
        /// </summary>
        public void VerifyResponseFromDB()
        {
            GetStoresModal actualResponse = JsonConvert.DeserializeObject<GetStoresModal>(_resposeWrapper.Content);
            GetStoresModal expectedResponse = new GetStoresModal()
            {
                total = StoresDBHelper.GetTotalStoresCount(),
                limit = 10,
                skip = 0,
                data = StoresDBHelper.GetStoresList()
            };
            if (!actualResponse.Equals(expectedResponse))
            {
                Assert.Fail("Expected Response is " + JsonConvert.SerializeObject(expectedResponse) + " but actual response  is " + JsonConvert.SerializeObject(actualResponse));
            }
        }
    }
}
