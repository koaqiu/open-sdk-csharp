using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
	/// <summary>
	/// 获取仓库中的商品列表,仅返回商品部分信息
	/// </summary>
	public class GetCustomItems :AbstractApi<YouzanItemsOnsaleGetResult> {
		public override string ApiName => "youzan.items.custom.get";
        /// <summary>
        /// 获取仓库中的商品列表,仅返回商品部分信息
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
		public GetCustomItems(Auth auth, GetCustomItemsParams args) : base(auth, args) {
		}

	}
}
