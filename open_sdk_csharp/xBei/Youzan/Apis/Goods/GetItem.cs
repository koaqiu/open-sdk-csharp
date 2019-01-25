using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 获取单个商品信息
    /// </summary>
    public class GetItem : AbstractApi<YouzanItemGetResult> {
		public override string ApiName => "youzan.item.get";
        /// <summary>
        /// 获取单个商品信息
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
		public GetItem(Auth auth, GetItemParams args) : base(auth, args) {
		}

	}
}
