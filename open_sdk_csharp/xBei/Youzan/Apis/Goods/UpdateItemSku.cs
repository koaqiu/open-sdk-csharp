using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 更新SKU
    /// </summary>
    public class UpdateItemSku : AbstractApi<SimpleResult> {
		public override string ApiName => "youzan.item.sku.update";
        public override string Method => ApiRequestMethod.POST;

        /// <summary>
        /// 更新SKU
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public UpdateItemSku(Auth auth, UpdateItemSkuParams args) : base(auth, args) {
		}
	}
}
