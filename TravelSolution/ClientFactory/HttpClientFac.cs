using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Globers.Models;

namespace Globers.ClientFactory
{
    public class HttpClientFac
    {
        private readonly IHttpClientFactory _httpClient;

        public HttpClientFac(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<IEnumerable<AutorModel>> HttpService()
        {
            var client = _httpClient.CreateClient("Server");
            var result = await client.GetAsync("api/Autor");
            IEnumerable<AutorModel> autors = new List<AutorModel>();
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                autors = JsonConvert.DeserializeObject<IEnumerable<AutorModel>>(response);
            }
            return autors;
        }

        //public static dynamic SYS_WSRequest(string method, string url, object parameters, Dictionary<String, String> headers,  double? minTimeout)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(method) || string.IsNullOrEmpty(url))
        //        {
        //            throw new ArgumentNullException("method or url");
        //        }

        //        HttpMethod httpMethod = new HttpMethod(method);
        //        double min = minTimeout != null && minTimeout > 0 ? (double)minTimeout : 3;
        //        using (HttpClient Client = new HttpClient { Timeout = TimeSpan.FromMinutes(min) })
        //        {
        //            using (var request = new HttpRequestMessage(httpMethod, url))
        //            {
        //                if (parameters != null)
        //                {
        //                    request.Content = new StringContent(JsonConvert.SerializeObject(parameters), Encoding.UTF8, "application/json");
        //                }

        //                if (headers != null)
        //                {
        //                    foreach (KeyValuePair<String, String> header in headers)
        //                    {
        //                        request.Headers.Add(header.Key, header.Value);
        //                    }
        //                }

        //                using (HttpResponseMessage response = Client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead).Result)
        //                {
        //                    using HttpContent content = response.Content;
        //                    string result = content.ReadAsStringAsync().Result;

        //                    if (response.StatusCode == HttpStatusCode.OK)
        //                    {
        //                        var resultWs = JsonConvert.DeserializeObject<dynamic>(result);
        //                        if ((bool)resultWs.IsError)
        //                        {
        //                            return new { IsError = true, ErrorMessage = resultWs.ErrorMessage };
        //                        }
        //                        return new { IsSuccessful = resultWs.IsSucessfull, Result = resultWs.Result };

        //                    }

        //                    else
        //                        return new { IsError = true, ErrorMessage = result };
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new { IsError = true, ErrorMessage = ex.InnerException.Message + ex.StackTrace };
        //    }
        //}

    }
}
