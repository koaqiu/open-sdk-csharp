using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
	public class GetItemParams : ApiParams {
		/// <summary>
		/// 商品ID，可以通过列表接口如youzan.items.onsale.get （查询出售中商品）和 youzan.items.inventory.get （查询仓库中商品）获取到
		/// </summary>
		[MustFill(0)]
		public int ItemId { get; set; }
		/// <summary>
		/// 商品别名，可以通过列表接口如youzan.items.onsale.get （查询出售中商品）和 youzan.items.inventory.get （查询仓库中商品）获取到
		/// </summary>
		public string Alias { get; set; }
		
	}
}
