using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 获取出售中的商品列表,仅返回商品部分信息
    /// </summary>
    public class GetOnSaleItemsApi : AbstractApi<YouzanItemsOnsaleGetResult> {
        public override string ApiName => "youzan.items.onsale.get";
        public override string Version => "3.0.0";
        public override string Method => ApiRequestMethod.GET;
        /// <summary>
        /// 获取出售中的商品列表,仅返回商品部分信息	
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public GetOnSaleItemsApi(Auth auth, GetOnSaleItemsParams args) : base(auth, args) {}
    }
}
