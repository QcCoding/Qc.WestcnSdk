using System.Collections.Generic;
using System.Xml.Serialization;

namespace Qc.WestcnSdk.Models
{
    /// <summary>
    /// 域名解析记录列表
    /// </summary>
    public class DomainAnalysisRecordListXmlModel : BaseApiResultModel
    {
        /// <summary>
        /// 记录列表
        /// </summary>
        [XmlArray("info"), XmlArrayItem("record")]
        public List<DomainAnalysisRecordItemXmlModel> Info { get; set; }
    }

    /// <summary>
    /// 域名解析记录
    /// </summary>
    public class DomainAnalysisRecordItemXmlModel
    {
        /// <summary>
        /// 记录类型 A,CNAME,MX,TXT类型（不区分大小写）
        /// </summary>
        [XmlElement("type")]
        public string Type { get; set; }

        /// <summary>
        /// 记录ID
        /// </summary>
        [XmlElement("id")]
        public long Id { get; set; }

        /// <summary>
        /// 主机名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 记录值
        /// </summary>
        [XmlElement("value")]
        public string Value { get; set; }

        /// <summary>
        /// 生存时间
        /// </summary>
        [XmlElement("ttl")]
        public int TTL { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        [XmlElement("prio")]
        public int Prio { get; set; }

        /// <summary>
        /// 已经暂停
        /// </summary>
        [XmlElement("ispause")]
        public bool IsPause { get; set; }
    }
}
