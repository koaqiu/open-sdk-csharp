using Newtonsoft.Json;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
	public class UpdateItemQuantityParams : ApiParams {
		/// <summary>
		/// 商品数字编号
		/// </summary>
		[JsonProperty("item_id")]
		[MustFill(0L)]
		public long ItemId { get; set; }

		/// <summary>
		/// sku库存数量
		/// </summary>
		[JsonProperty("quantity")]
		[MustFill(0L)]
		public long Quantity { get; set; }

		/// <summary>
		/// skuid如果商品为无规格商品是可以不传，否则必传
		/// </summary>
		[JsonProperty("sku_id")]
		public long SkuId { get; set; }

		/// <summary>
		/// 库存更新方式：0为全量更新，1为增量更新(默认为0)
		/// </summary>
		[JsonProperty("type")]
		public long Type { get; set; }
	}
}
