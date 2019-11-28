using Qc.WestcnSdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk
{
    public interface IWestcnSdkHook
    {
        /// <summary>
        /// 获取OCR配置
        /// </summary>
        /// <returns></returns>
        WestcnConfig GetConfig();
    }
}
