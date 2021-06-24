using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BestBuy.API.BDD.Helpers
{
    class HttpClientHelper
    {
        private HttpClient httpClient;
        private HttpRequestMessage httpRequestMessage;
        private ResponseWrapper restResponse;
        private string baseUri = ConfigurationManager.AppSettings["BaseUri"];

        /// <summary>
        /// Add Header to HTTP Client
        /// </summary>
        /// <param name="httpHeaders">Dictionary of headers</param>
        /// <returns>HttpClient</returns>
        private HttpClient AddHeaderToHttpClient(Dictionary<string, string> httpHeaders = null)
        {
            HttpClient httpClient = new HttpClient();
            if (httpHeaders != null)
            {
                foreach (string key in httpHeaders.Keys)
                    httpClient.DefaultRequestHeaders.Add(key, httpHeaders[key]);
            }
            return httpClient;
        }

        /// <summary>
        /// Create HttpRequestMessage 
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="httpMethod">HttpMethod</param>
        /// <returns>HttpRequestMessage</returns>
        private HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod httpMethod, HttpContent httpContent = null)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            if (httpContent != null)
            {
                httpRequestMessage.Content = httpContent;
            }
            return httpRequestMessage;
        }

        /// <summary>
        /// Create ResponseWrapper
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="httpMethod">Http Method</param>
        /// <param name="httpContent">Http Content</param>
        /// <param name="httpHeaders">HttpHeaders</param>
        /// <returns>ResponseWrapper</returns>
        private ResponseWrapper SendRequest(string requestUrl, HttpMethod httpMethod, HttpContent httpContent = null, Dictionary<string, string> httpHeaders = null)
        {
            httpClient = AddHeaderToHttpClient(httpHeaders);
            httpRequestMessage = CreateHttpRequestMessage(requestUrl, httpMethod, httpContent);
            Task<HttpResponseMessage> httpResponseMessage = httpClient.SendAsync(httpRequestMessage);
            try
            {
                restResponse = new ResponseWrapper()
                {
                    StatusCode = (int)httpResponseMessage.Result.StatusCode,
                    Content = httpResponseMessage.Result.Content.ReadAsStringAsync().Result
                };

            }
            catch (Exception err)
            {
                restResponse = new ResponseWrapper() { StatusCode = 500, Content = err.Message };
            }
            finally
            {
                httpRequestMessage?.Dispose();
                httpClient?.Dispose();
            }
            return restResponse;
        }

        /// <summary>
        /// Perform Get Request
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="httpHeaders">HttpHeaders</param>
        /// <returns>ResponseWrapper</returns>
        public ResponseWrapper PerformGetRequest(string requestUrl, Dictionary<string, string> httpHeaders = null)
        {
            return SendRequest(baseUri + requestUrl, HttpMethod.Get, null, httpHeaders);
        }

        /// <summary>
        /// Perform Post Request
        /// </summary>
        /// <param name="requestUrl">Request Url</param>
        /// <param name="httpContent">Content to pass in Body</param>
        /// <param name="httpHeaders">Http headers to add</param>
        /// <returns>ResponseWrapper</returns>
        public ResponseWrapper PerformPostRequest(string requestUrl, string httpContent, Dictionary<string, string> httpHeaders = null)
        {
            HttpContent content = new StringContent(httpContent, Encoding.UTF8, "application/json");
            return SendRequest(baseUri + requestUrl, HttpMethod.Post, content, httpHeaders);
        }

        /// <summary>
        /// Perform Delete request
        /// </summary>
        /// <param name="requestUrl">Request url</param>
        /// <param name="httpHeaders">Http headers to add<<</param>
        /// <returns>ResponseWrapper</returns>
        public ResponseWrapper PerformDeleteRequest(string requestUrl, Dictionary<string, string> httpHeaders = null)
        {
            return SendRequest(baseUri + requestUrl, HttpMethod.Delete, null, httpHeaders);
        }

        /// <summary>
        /// Perform patch request
        /// </summary>
        /// <param name="requestUrl">Request url</param>
        /// <param name="httpContent">Content to pass in Body</param>
        /// <param name="httpHeaders">Http headers to add<</param>
        /// <returns>ResponseWrapper</returns>
        public ResponseWrapper PerformPatchRequest(string requestUrl, string httpContent, Dictionary<string, string> httpHeaders = null)
        {

            HttpContent content = new StringContent(httpContent, Encoding.UTF8, "application/json");
            return SendRequest(baseUri + requestUrl, HttpMethod.Put, content, httpHeaders);
        }
    }
}
