using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 获取商品类目二维列表
    /// </summary>
    public class GetItemCategories : AbstractApi<YouzanItemcategoriesGetResult> {
        public override string ApiName => "youzan.itemcategories.get";
        public override string Version => "3.0.0";
        public override string Method => ApiRequestMethod.GET;
        /// <summary>
        /// 获取商品类目二维列表
        /// </summary>
        /// <param name="auth"></param>
        public GetItemCategories(Auth auth) : base(auth){}
    }
}
