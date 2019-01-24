using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
	/// <summary>
	/// 下架商品
	/// </summary>
	public class UpdateItemDelisting : AbstractApi<YouzanItemQuantityUpdateResult> {
		public override string ApiName => "youzan.item.update.delisting";
		/// <summary>
		/// 下架商品,取出售中的商品id
		/// </summary>
		/// <param name="auth"></param>
		/// <param name="args"></param>
		public UpdateItemDelisting(Auth auth, UpdateItemListingParams args) : base(auth, args) {
		}
	}
}
