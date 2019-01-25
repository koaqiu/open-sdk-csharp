using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 交易订单详情
    /// </summary>
    public class GetTradeParams : ApiParams {
        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("tid")]
        public string Tid { get; set; }
    }
}
