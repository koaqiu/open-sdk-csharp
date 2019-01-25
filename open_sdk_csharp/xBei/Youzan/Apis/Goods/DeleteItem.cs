using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 根据商品Id删除商品
    /// </summary>
    public class DeleteItem: AbstractApi<ItemUpdateResult> {
		public override string ApiName => "youzan.item.delete";
        /// <summary>
        /// 根据商品Id删除商品
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public DeleteItem(Auth auth, SimpleUpdateItemParams args) : base(auth, args) {
		}
	}
}
