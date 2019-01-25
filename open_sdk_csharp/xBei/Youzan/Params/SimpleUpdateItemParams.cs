using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 更新商品参数（简单版）
    /// </summary>
	public class SimpleUpdateItemParams : ApiParams {
		/// <summary>
		/// 商品ID，可以通过列表接口如 youzan.items.inventory.get （查询仓库中商品）获取到
		/// </summary>
		[MustFill(0)]
		public int ItemId { get; set; }
	}
}
