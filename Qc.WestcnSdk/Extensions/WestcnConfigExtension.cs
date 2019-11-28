using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Qc.WestcnSdk
{
    public static class WestcnConfigExtension
    {
        public static string GetWestcnPostUrl(this WestcnConfig westcnConfig, List<string> cmdList)
        {
            var strCmd = string.Join<string>(ApplicationConstant.NEW_LINE_STR, cmdList);

            var beSign = strCmd;
            if (beSign.Length > 10)
            {
                beSign = beSign.Substring(0, 10);
            }
            beSign = $"{westcnConfig.UserId}{westcnConfig.ApiPwd}{beSign}";

            var sign = beSign.GetHash<MD5>();

            var cmdStrUrlEncode = HttpUtility.UrlEncode(strCmd, Encoding.GetEncoding("GB2312"));

            return $"{westcnConfig.ApiUrl}?Userid={westcnConfig.UserId}&strCmd={cmdStrUrlEncode}&versig={sign}";
        }
    }
}
