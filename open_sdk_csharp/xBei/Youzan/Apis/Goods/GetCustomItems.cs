using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 根据商品编码查询商品
    /// </summary>
    public class GetCustomItems :AbstractApi<YouzanItemsOnsaleGetResult> {
		public override string ApiName => "youzan.items.custom.get";
        /// <summary>
        /// 根据商品编码查询商品
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
		public GetCustomItems(Auth auth, GetCustomItemsParams args) : base(auth, args) {
		}

	}
}
