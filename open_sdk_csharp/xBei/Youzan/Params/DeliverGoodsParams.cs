using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
    public class DeliverGoodsParams : ApiParams {
        /// <summary>
        /// 发货是否无需物流如果为0则必须传递物流参数，如果为1则无需传递物流参数（out_stype和out_sid），默认为0
        /// </summary>
        [JsonProperty("is_no_express")]
        public long? IsNoExpress { get; set; }

        /// <summary>
        /// 配送期次，周期购订单专用，例如：1，表示配送第1期
        /// </summary>
        [JsonProperty("issue")]
        public long? Issue { get; set; }

        /// <summary>
        /// 如果需要拆单发货，使用该字段指定要发货的商品交易明细编号，多个明细编号用半角逗号“,”分隔；不需要拆单发货，则该字段不传或值为空；
        /// </summary>
        [JsonProperty("oids")]
        public string Oids { get; set; }

        /// <summary>
        /// 快递单号（具体一个物流公司的真实快递单号）
        /// </summary>
        [JsonProperty("out_sid")]
        public string OutSid { get; set; }

        /// <summary>
        /// 物流公司编号，可以通过请求youzan.logistics.express.get该接口获得
        /// </summary>
        [JsonProperty("out_stype")]
        public string OutStype { get; set; }

        /// <summary>
        /// 外部交易编号
        /// </summary>
        [JsonProperty("outer_tid")]
        public string OuterTid { get; set; }

        /// <summary>
        /// 交易订单号
        /// </summary>
        [JsonProperty("tid")]
        [MustFill("")]
        public string Tid { get; set; }
    }
}
