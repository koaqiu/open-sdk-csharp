using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    /// <summary>
    /// 更新商品项目返回值
    /// </summary>
    public class ItemUpdateResult : SimpleResult {
        /// <summary>
        /// 操作上架的商品id
        /// </summary>
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
    }
}
