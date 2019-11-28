using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Qc.WestcnSdk
{
    /// <summary>
    /// HTTPClient扩展
    /// </summary>
    public static class HttpClientExtension
    {
        /// <summary>
        /// 发起POST同步请求
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="timeOut"></param>
        /// <param name="headers">填充消息头</param>        
        /// <returns></returns>
        public static string HttpPost(this HttpClient client, string url, string postData = null, string contentType = null, int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            if (headers != null)
            {
                foreach (var header in headers)
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
            {
                if (contentType != null)
                    httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                    return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// FormPost
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="formList"></param>
        /// <returns></returns>
        public static string HttpFormPost(this HttpClient client, string url, List<KeyValuePair<string, object>> formList)
        {
            var formData = formList.Select(x => new KeyValuePair<string, string>(x.Key, x.Value.ToString()));
            using (HttpContent httpContent = new FormUrlEncodedContent(formData))
            {
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");
                using (HttpResponseMessage response = client.PostAsync(url, httpContent).Result)
                    return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// GET
        /// </summary>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="queryList"></param>
        /// <returns></returns>
        public static string HttpQueryGet(this HttpClient client, string url, List<KeyValuePair<string, object>> queryList)
        {
            var queryData = queryList.ToDictionary(k => k.Key, v => v.Value?.ToString());
            var requestUrl = QueryHelpers.AddQueryString(url, queryData);
            using (HttpResponseMessage response = client.GetAsync(requestUrl).Result)
                return response.Content.ReadAsStringAsync().Result;
        }
    }
}
