using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk
{
    public class WestcnConfig
    {
        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// 接口地址
        /// </summary>
        public string DomainApiUrl { get; set; }
        /// <summary>
        /// 西数代理账号
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 西数代理API密码
        /// </summary>
        public string ApiPwd { get; set; }
        /// <summary>
        /// 请求超时时间
        /// </summary>
        public int? Timeout { get; set; } = 30;
    }
}
