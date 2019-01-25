using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
    public class SearchLogisticsTemplateParams : ApiParams {

        /// <summary>
        /// 页码
        /// </summary>
        [JsonProperty("page_no")]
        [MustFill(0)]
        public int PageNo { get; set; }

        /// <summary>
        /// 分页值，默认20
        /// </summary>
        [JsonProperty("page_size")]
        [MustFill(0)]
        public int PageSize { get; set; }
    }
}
