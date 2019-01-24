using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
	/// <summary>
	/// 获取仓库中的商品列表,仅返回商品部分信息	
	/// </summary>
	public class GetItem : AbstractApi<YouzanItemGetResult> {
		public override string ApiName => "youzan.item.get";
		public GetItem(Auth auth, GetItemParams args) : base(auth, args) {
		}

	}
}
