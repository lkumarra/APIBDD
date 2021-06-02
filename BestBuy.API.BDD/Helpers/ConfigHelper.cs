using System;


namespace BestBuy.API.BDD.Helpers
{
    static class ConfigHelper
    {
        public static readonly HttpClientHelper _httpClientHelper;
        public static readonly string BasePath;

        static ConfigHelper()
        {
            _httpClientHelper = new HttpClientHelper();
            BasePath = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
