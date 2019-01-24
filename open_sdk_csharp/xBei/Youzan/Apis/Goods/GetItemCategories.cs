using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Goods {
    public class GetItemCategories : AbstractApi<YouzanItemcategoriesGetResult> {
        public override string ApiName => "youzan.itemcategories.get";
        public override string Version => "3.0.0";
        public override string Method => ApiRequestMethod.GET;

        public GetItemCategories(Auth auth) : base(auth){}
    }
}
