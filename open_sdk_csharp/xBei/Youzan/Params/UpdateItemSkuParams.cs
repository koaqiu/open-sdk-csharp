using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 更新SKU
    /// </summary>
    public class UpdateItemSkuParams : ApiParams {

        /// <summary>
        /// 商品数字编号
        /// </summary>
        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        /// <summary>
        /// 商品编码
        /// </summary>
        [JsonProperty("item_no")]
        public string ItemNo { get; set; }

        /// <summary>
        /// sku销售价格，精确到小数点2位；单位:元
        /// </summary>
        [JsonProperty("price")]
        public float Price { get; set; }

        /// <summary>
        /// sku库存数量
        /// </summary>
        [JsonProperty("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// skuid
        /// </summary>
        [JsonProperty("sku_id")]
        public long SkuId { get; set; }

    }
}
