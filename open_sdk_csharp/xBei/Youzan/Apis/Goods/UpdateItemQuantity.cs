using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
	/// <summary>
	/// 支持全量或增量方式更新SKU库存
	/// </summary>
	public class UpdateItemQuantity : AbstractApi<YouzanItemUpdateListingResult> {
		public override string ApiName => "youzan.item.quantity.update";
		/// <summary>
		/// 支持全量或增量方式更新SKU库存
		/// </summary>
		/// <param name="auth"></param>
		/// <param name="args"></param>
		public UpdateItemQuantity(Auth auth, UpdateItemQuantityParams args) : base(auth, args) {
		}
	}
}
