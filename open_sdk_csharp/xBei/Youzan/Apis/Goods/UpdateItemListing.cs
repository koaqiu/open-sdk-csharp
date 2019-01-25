using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
	/// <summary>
	/// 上架商品
	/// </summary>
	public class UpdateItemListing : AbstractApi<SimpleResult> {
		public override string ApiName => "youzan.item.update.listing";
		/// <summary>
		/// 上架商品,取状态是待上架的商品id(item_id)
		/// </summary>
		/// <param name="auth"></param>
		/// <param name="args"></param>
		public UpdateItemListing(Auth auth, UpdateItemListingParams args) : base(auth, args) {
		}
	}
}
