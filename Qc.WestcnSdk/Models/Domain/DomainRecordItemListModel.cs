using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WestcnSdk.Models.Domain
{
    /// <summary>
    /// 域名列表模型
    /// </summary>
    public class DomainRecordItemListModel : DomainBaseApiResultModel
    {
        /// <summary>
        /// 域名分页列表
        /// </summary>
        public DomainRecordPageModel Data { get; set; }
    }

    /// <summary>
    /// 域名列表分页模型
    /// </summary>
    public class DomainRecordPageModel
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
        public int TotalPage { get; set; }

        /// <summary>
        /// 记录项列表
        /// </summary>
        public List<DomainRecordItemModel> Items { get; set; }
    }

    /// <summary>
    /// 域名项
    /// </summary>
    public class DomainRecordItemModel
    {
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime ExpDate { get; set; }

        /// <summary>
        /// 主DNS
        /// </summary>
        public string DNS1 { get; set; }

        /// <summary>
        /// 辅DNS
        /// </summary>
        public string DNS2 { get; set; }

        /// <summary>
        /// 辅DNS
        /// </summary>
        public string DNS3 { get; set; }

        /// <summary>
        /// 辅DNS
        /// </summary>
        public string DNS4 { get; set; }

        /// <summary>
        /// 辅DNS
        /// </summary>
        public string DNS5 { get; set; }

        /// <summary>
        /// 辅DNS
        /// </summary>
        public string DNS6 { get; set; }

        /// <summary>
        /// 注册年数
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// 版本？目前未知作用
        /// </summary>
        public string Version { get; set; }
    }

}
