using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanItemUpdateListingResult : SimpleResult {
        /// <summary>
        /// 操作上架的商品id
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
    }
}
