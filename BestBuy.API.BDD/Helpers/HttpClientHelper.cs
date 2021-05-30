using BestBuy.API.BDD.Wrapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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

        private HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod httpMethod)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            return httpRequestMessage;
        }

        private HttpRequestMessage CreateHttpRequestMessage(string requestUrl, HttpMethod httpMethod, HttpContent httpContent)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, requestUrl);
            httpRequestMessage.Content = httpContent;
            return httpRequestMessage;
        }

        private ResponseWrapper SendRequest(string requestUrl, HttpMethod httpMethod, Dictionary<string, string> httpHeaders = null)
        {
            httpClient = AddHeaderToHttpClient(httpHeaders);
            httpRequestMessage = CreateHttpRequestMessage(requestUrl, httpMethod);
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

        private ResponseWrapper SendRequest(string requestUrl, HttpMethod httpMethod, HttpContent httpContent, Dictionary<string, string> httpHeaders = null)
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

        public ResponseWrapper PerformGetRequest(string requestUrl, Dictionary<string, string> httpHeaders = null)
        {
            return SendRequest(baseUri + requestUrl, HttpMethod.Get, httpHeaders);
        }

        public ResponseWrapper PerformPostRequest(string requestUrl, HttpContent httpContent, Dictionary<string, string> httpHeaders = null)
        {
            return SendRequest(baseUri + requestUrl, HttpMethod.Post, httpContent, httpHeaders);
        }

        public ResponseWrapper PerformDeleteRequest(string requestUrl, Dictionary<string, string> httpHeaders = null)
        {
            return SendRequest(baseUri + requestUrl, HttpMethod.Delete, httpHeaders);
        }
    }
}
