using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SendMail
{
    public class HttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// 以 HTTP POST 動詞呼叫後端 API。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="stringContent"></param>
        /// <returns>若回傳 null 代表網路異常，呼叫端需根據是否為 null 做不同判斷。</returns>
        public async Task<T?> PostData<T>(string url, StringContent stringContent) where T : new()
        {
            try
            {
                var httpClient = await GetHttpClient();
                var httpResponse = await httpClient.PostAsync(url, stringContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                    if (contentStream == null)
                    {
                        return default(T);
                    }
                    if (stringContent.Headers.ContentType.MediaType == "text/xml")
                    {
                        var serializer = new XmlSerializer(typeof(T));

                        using (var reader = new MemoryStream())
                        {
                            var obj = (T)serializer.Deserialize(contentStream);
                            return obj;
                        }
                    }

                    return await JsonSerializer.DeserializeAsync<T>(contentStream);
                }
                return default(T);
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 以 HTTP GET 動詞呼叫後端 API。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns>若回傳 null 代表網路異常，呼叫端需根據是否為 null 做不同判斷。</returns>
        public async Task<T?> GetData<T>(string url)
        {
            try
            {
                var httpClient = await GetHttpClient();
                var httpResponse = await httpClient.GetAsync(url);
                if (httpResponse.IsSuccessStatusCode)
                {
                    var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                    if (contentStream == null)
                    {
                        return default(T);
                    }

                    return await JsonSerializer.DeserializeAsync<T>(contentStream);
                }

                return default(T);
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 抽出 HttpClient 方法，其他 HTTP 相關內容 (如 <see cref="HttpClient.BaseAddress"/>, <see cref="HttpClient.DefaultRequestHeaders"/>...) 可以在此修改。
        /// </summary>
        /// <returns></returns>
        public async Task<HttpClient> GetHttpClient()
        {
            var httpClient = _httpClientFactory.CreateClient();
            return httpClient;
        }
    }
}
