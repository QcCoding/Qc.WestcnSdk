using Microsoft.Extensions.Options;
using Qc.WestcnSdk.Models;
using Qc.WestcnSdk.Models.Domain;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Qc.WestcnSdk
{
    public class WestcnDomainService
    {
        private readonly HttpClient _httpClient;
        private readonly WestcnConfig _apiConfig;
        private readonly IWestcnSdkHook _sdkHook;
        public WestcnDomainService(IHttpClientFactory _httpClientFactory
            , IWestcnSdkHook WestcnSdkHook
            )
        {
            _sdkHook = WestcnSdkHook;
            _apiConfig = WestcnSdkHook.GetConfig();
            if (_apiConfig == null)
                throw new Exception("Westcn not configured");
            _httpClient = _httpClientFactory.CreateClient("Westcn");
            if (!string.IsNullOrWhiteSpace(_apiConfig.DomainApiUrl))
                _httpClient.BaseAddress = new Uri(_apiConfig.DomainApiUrl);
            _httpClient.BaseAddress = new Uri(_apiConfig.DomainApiUrl);
            if (_apiConfig.Timeout.HasValue)
                _httpClient.Timeout = TimeSpan.FromSeconds(_apiConfig.Timeout.Value);
        }

        #region 域名业务接口V2

        #region 3.3、获取域名列表
        /// <summary>
        /// 3.3、获取域名列表
        /// </summary>
        /// <param name="limit">每页大小 默认20</param>
        /// <param name="pageno">第几页 默认为1</param>
        /// <returns></returns>
        public DomainRecordItemListModel GetDomainList(int limit = 20, int pageno = 1)
        {
            string methodUrl = "/api/v2/domain/?act=getdomains";
            Dictionary<string, object> postData = new Dictionary<string, object> {
                { "limit", limit },
                { "page", pageno }
            };
            var result = WestcnDomainV2Get<DomainRecordItemListModel>(methodUrl, postData);
            return result;
        }
        #endregion

        #region 3.8、修改域名解析
        /// <summary>
        /// 3.8、修改域名解析
        /// </summary>
        /// <param name="domain">需要修改解析的相关域名 如：west.cn</param>
        /// <param name="recordId">需要修改的记录ID 可列举域名解析记录获取</param>
        /// <param name="newValue">解析记录新值</param>
        /// <param name="ttl">生存时间 可选，数值型，不能低于200</param>
        /// <returns></returns>
        public DomainBaseApiResultModel ModifyDomainAnalysisRecord(string domain, long recordId, string newValue, int ttl = 0)
        {
            string methodUrl = "/api/v2/domain/?act=moddnsrecord";
            Dictionary<string, object> postData = new Dictionary<string, object> {
                { "domain", domain },
                { "id", recordId },
                { "value", newValue },
                { "ttl", ttl },
            };
            var result = WestcnDomainV2Post<DomainBaseApiResultModel>(methodUrl, postData);
            return result;
        }

        #endregion

        #region 3.10、获取域名解析记录
        /// <summary>
        /// 3.10、获取域名解析记录
        /// </summary>
        /// <param name="domain">需要获取解析记录的的相关域名 如：west.cn</param>
        /// <param name="limit">每页大小 默认20</param>
        /// <param name="pageno">第几页 默认为1</param>
        /// <returns></returns>
        public DomainAnalysisRecordListModel GetDomainAnalysisList(string domain, int limit = 20, int pageno = 1)
        {
            string methodUrl = "/api/v2/domain/?act=getdnsrecord";
            Dictionary<string, object> postData = new Dictionary<string, object> {
                { "domain", domain },
                { "limit", limit },
                { "pageno", pageno }
            };
            var result = WestcnDomainV2Post<DomainAnalysisRecordListModel>(methodUrl, postData);
            return result;
        }
        #endregion

        #endregion

        #region Westcn域名业务V2通用请求
        /// <summary>
        /// Westcn域名业务V2通用POST
        /// </summary>
        /// <param name="postUrl"></param>
        /// <param name="inPostDic"></param>
        /// <returns></returns>
        public T WestcnDomainV2Post<T>(string postUrl, Dictionary<string, object> inPostDic)
        {
            var timestamp = Utils.RandomHelper.GenerateTimeStamp();
            var token = $"{_apiConfig.UserId}{_apiConfig.ApiPwd}{timestamp}".GetHash<MD5>();
            List<KeyValuePair<string, object>> formList = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("username", _apiConfig.UserId),
                new KeyValuePair<string, object>("time", timestamp),
                new KeyValuePair<string, object>("token", token)
            };
            formList.AddRange(inPostDic);
            var json = _httpClient.HttpFormPost(postUrl, formList);
            Console.WriteLine(json);
            var result = Utils.JsonHelper.Deserialize<T>(json);
            return result;
        }

        /// <summary>
        /// Westcn域名业务V2通用GET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="getUrl"></param>
        /// <param name="queryDic"></param>
        /// <returns></returns>
        public T WestcnDomainV2Get<T>(string getUrl, Dictionary<string, object> queryDic)
        {
            var timestamp = Utils.RandomHelper.GenerateTimeStamp();
            var token = $"{_apiConfig.UserId}{_apiConfig.ApiPwd}{timestamp}".GetHash<MD5>();
            List<KeyValuePair<string, object>> queryList = new List<KeyValuePair<string, object>> {
                new KeyValuePair<string, object>("username", _apiConfig.UserId),
                new KeyValuePair<string, object>("time", timestamp),
                new KeyValuePair<string, object>("token", token)
            };
            queryList.AddRange(queryDic);
            var json = _httpClient.HttpQueryGet(getUrl, queryList);
            Console.WriteLine(json);
            var result = Utils.JsonHelper.Deserialize<T>(json);
            return result;
        }
        #endregion

        #region (老)域名相关接口

        #region 2.7 修改域名解析记录
        ///// <summary>
        ///// 2.7 修改域名解析记录
        ///// </summary>
        ///// <param name="domain">需要修改解析的相关域名 如：west.cn</param>
        ///// <param name="recordId">需要修改的记录ID 可列举域名解析记录获取</param>
        ///// <param name="newValue">解析记录新值</param>
        ///// <param name="ttl">生存时间 可选，数值型，不能低于200</param>
        ///// <returns></returns>
        //public BaseApiResultModel ModifyDomainAnalysisRecord(string domain, long recordId, string newValue, int ttl = 0)
        //{
        //    var cmdList = new List<string>
        //    {
        //        $"dnsresolve",
        //        $"mod",
        //        $"entityname:dnsrecord"
        //    };

        //    cmdList.Add($"domain:{domain}");
        //    cmdList.Add($"rr_id:{recordId}");
        //    cmdList.Add($"value:{newValue}");

        //    if (ttl > 0)
        //        cmdList.Add($"ttl:{ttl}");
        //    else
        //        cmdList.Add($"ttl:{300}");

        //    cmdList.Add(".");
        //    cmdList.Add("");

        //    var postUrl = _apiConfig.GetWestcnPostUrl(cmdList);
        //    var resultXml = _httpClient.HttpPost(postUrl);

        //    var result = Utils.XmlHelper.Deserialize<BaseApiResultModel>(resultXml);
        //    return result;
        //}
        #endregion

        #region 2.9 列举域名解析记录
        ///// <summary>
        ///// 2.9 列举域名解析记录
        ///// </summary>
        ///// <param name="domain">相关域名</param>
        ///// <returns></returns>
        //public List<DomainAnalysisRecordItemModel> GetDomainAnalysisList(string domain)
        //{
        //    var cmdList = new List<string>
        //    {
        //        $"dnsresolve",
        //        $"list",
        //        $"entityname:dnsrecord"
        //    };

        //    cmdList.Add($"domain:{domain}");

        //    cmdList.Add(".");
        //    cmdList.Add("");

        //    var postUrl = _apiConfig.GetWestcnPostUrl(cmdList);
        //    var resultXml = _httpClient.HttpPost(postUrl);

        //    var result = Utils.XmlHelper.Deserialize<DomainAnalysisRecordListModel>(resultXml);

        //    return result.Info;
        //}
        #endregion

        #endregion

    }
}
