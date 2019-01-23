using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.xBei.Youzan.Params {
    public class GetOnSaleItemsParams : ApiParams {
        /// <summary>
        /// 排序方式。格式为column:asc/desc，
        /// 目前排序字段：
        ///     1.创建时间：created_time，
        ///     2.更新时间：update_time，
        ///     3.价格：price，
        ///     4.销量：sold_num
        /// </summary>
        public string OrderBy { get; set; }
        /// <summary>
        /// 页码，不传或为0时默认设置为1
        /// </summary>
        public int? PageNo { get; set; }
        /// <summary>
        /// 每页条数，最大300个，不传或为0时默认设置为40
        /// </summary>
        public int? PageSize { get; set; }
        /// <summary>
        /// 搜索字段。搜索商品的title
        /// </summary>
        public string Q { get; set; }
        /// <summary>
        /// 商品标签的ID
        /// </summary>
        public int? TagId { get; set; }
        /// <summary>
        /// 商品终止更新时间，单位为ms
        /// </summary>
        public int? UpdateTimeEnd { get; set; }
        /// <summary>
        /// 商品初始更新时间，单位为ms
        /// </summary>
        public int? UpdateTimeStart { get; set; }
    }
}
