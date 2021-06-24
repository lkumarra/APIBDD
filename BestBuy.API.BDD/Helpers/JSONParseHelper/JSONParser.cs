using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers.JSONParseHelper
{
    public class JSONParser
    {
        public static string GetJSONParsedResult(string json, string value)
        {
            JObject jsonObj = JObject.Parse(json);
            JToken pathResult = jsonObj.SelectToken(value);
            return pathResult.ToString();
        }
    }
}
