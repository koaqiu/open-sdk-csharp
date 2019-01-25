using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 更新商品信息
    /// </summary>
    public class UpdateItemParams : CreateItemParams {
        /// <summary>
        /// 是否为二手商品
        /// </summary>
        [JsonProperty("is_used")]
        public bool IsUsed { get; set; }

        /// <summary>
        /// 商品ID,可以通过列表接口如youzan.items.onsale.get（查询出售中商品）和youzan.items.inventory.get（查询仓库中商品）获取到
        /// </summary>
        [JsonProperty("item_id")]
        [MustFill(0L)]
        public long ItemId { get; set; }

        /// <summary>
        /// 商家自定义的序号
        /// </summary>
        [JsonProperty("num")]
        public long Num { get; set; }

        /// <summary>
        /// 要删除的商品图片id列表，英文逗号分隔，格式如"1,2"
        /// </summary>
        [JsonProperty("remove_image_ids")]
        public string RemoveImageIds { get; set; }

        /// <summary>
        /// 是否标品，true表示是，false表示否
        /// </summary>
        [JsonProperty("standard")]
        public bool Standard { get; set; }
    }
}
