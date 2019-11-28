using Microsoft.Extensions.Options;
using Qc.WestcnSdk.Models;
using Qc.WestcnSdk.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Qc.WestcnSdk
{
    public class DefaultWestcnSdkHook : IWestcnSdkHook
    {
        private readonly WestcnConfig _apiConfig;
        public DefaultWestcnSdkHook(IOptions<WestcnConfig> options)
        {
            _apiConfig = options.Value;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public WestcnConfig GetConfig()
        {
            return _apiConfig;
        }
    }
}
