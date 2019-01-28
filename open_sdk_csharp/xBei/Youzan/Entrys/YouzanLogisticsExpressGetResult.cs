using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanLogisticsExpressGetResult {
        /// <summary>
        /// 所有物流公司地址
        /// </summary>
        [JsonProperty("all_express")]
        public LogisticsExpressOpenApiModel[] AllExpress { get; set; }

        public class LogisticsExpressOpenApiModel {

            /// <summary>
            /// 物流公司编号
            /// </summary>
            [JsonProperty("id")]
            public long Id { get; set; }

            /// <summary>
            /// 物流公司名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// 是否显示0显示1不显示
            /// </summary>
            [JsonProperty("display")]
            public long Display { get; set; }

        }
    }
}
