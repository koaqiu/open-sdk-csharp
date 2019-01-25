using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 更新商品信息
    /// </summary>
    public class UpdateItem : AbstractApi<ItemUpdateResult> {
        public override string ApiName => "youzan.item.update";
        public override string Method => ApiRequestMethod.POST;
        /// <summary>
        ///	更新商品信息
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public UpdateItem(Auth auth, UpdateItemParams args) : base(auth, args) {
        }
    }
}
