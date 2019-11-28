using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk.Models.Domain
{
    /// <summary>
    /// 域名解析列表模型
    /// </summary>
    public class DomainAnalysisRecordListModel : DomainBaseApiResultModel
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public GeneralErrorType Errcode { get; set; }

        /// <summary>
        /// 成功返回数据(具体以各API返回数据说明为准)
        /// </summary>
        public DomainAnalysisRecordPageModel Data { get; set; }
    }

    /// <summary>
    /// 域名解析记录分页模型
    /// </summary>
    public class DomainAnalysisRecordPageModel
    {
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageNo { get; set; }

        /// <summary>
        /// 每页数量
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// 记录项列表
        /// </summary>
        public List<DomainAnalysisRecordItemModel> Items { get; set; }
    }

    /// <summary>
    /// 域名解析记录项
    /// </summary>
    public class DomainAnalysisRecordItemModel
    {
        /// <summary>
        /// 记录编号,修改时必填
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 主机名
        /// </summary>
        public string Item { get; set; }

        /// <summary>
        /// 解析值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 解析类型  限 A,CNAME,MX,TXT,AAAA,SRV
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 优先级别 1-100 默认(10)
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 解析生效时间值  60~86400 单位秒 (默认900)
        /// </summary>
        public int TTL { get; set; }

        /// <summary>
        /// 线路: 必须先添加默认线程后才能添加其它线路(默认="" ,电信="LTEL" ,联通="LCNC" ,移动="LMOB" ,教育网="LEDU" ,搜索引擎="LSEO")	
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// 线路详细信息
        /// </summary>
        public string LineInfo
        {
            get
            {
                if (Line == "LTEL")
                {
                    return "电信";
                }
                else if (Line == "LCNC")
                {
                    return "联通";
                }
                else if (Line == "LMOB")
                {
                    return "移动";
                }
                else if (Line == "LEDU")
                {
                    return "教育网";
                }
                else if (Line == "LSEO")
                {
                    return "搜索引擎";
                }
                return "默认";
            }
        }

        /// <summary>
        /// 已暂停
        /// </summary>
        [JsonConverter(typeof(BooleanJsonConverter))]
        public bool Pause { get; set; }
    }

}
