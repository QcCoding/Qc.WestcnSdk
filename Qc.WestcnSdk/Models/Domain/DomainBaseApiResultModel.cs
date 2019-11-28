using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk.Models.Domain
{
    /// <summary>
    /// 西部数码域名业务数据返回通用模型
    /// </summary>
    public class DomainBaseApiResultModel
    {
        /// <summary>
        /// 返回代码 200 成功 非200失败
        /// </summary>
        public int Result { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        [JsonIgnore]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 请求识别码
        /// </summary>
        public string Clientid { get; set; }

        /// <summary>
        /// 失败/成功返回的文本信息
        /// </summary>
        public string Msg { get; set; }
    }
}
