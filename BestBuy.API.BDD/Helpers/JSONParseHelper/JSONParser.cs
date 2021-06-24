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
        /// <summary>
        /// Get the JSON object value by parsing json
        /// </summary>
        /// <param name="json">Json to parse</param>
        /// <param name="value">Json path</param>
        /// <returns>Value of the parsed path</returns>
        public static string GetJSONParsedResult(string json, string value)
        {
            JObject jsonObj = JObject.Parse(json);
            JToken pathResult = jsonObj.SelectToken(value);
            return pathResult.ToString();
        }
    }
}
