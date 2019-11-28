using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Qc.WestcnSdk.Models
{
    /// <summary>
    /// 通用API返回模型
    /// </summary>
    [XmlRoot("property")]
    public class BaseApiResultModel
    {
        /// <summary>
        /// 返回结果状态码， 成功为200 ，若为其它数字都表示失败!
        /// </summary>
        [XmlElement("returncode")]
        public int ReturnCode { get; set; }

        /// <summary>
        /// 返回信息提示说明，成功时为ok,错误的时候这一项会描述出错原因。
        /// </summary>
        [XmlElement("returnmsg")]
        public string ReturnMsg { get; set; }

        /// <summary>
        /// 返回是否成功
        /// </summary>
        public bool IsSuccess { get { return ReturnCode == 200; } }
    }
}
