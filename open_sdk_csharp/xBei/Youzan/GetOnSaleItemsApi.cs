using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan {
    public class GetOnSaleItemsApi : IApi<YouzanItemsOnsaleGetResult> {
        public string ApiName { get; } = "youzan.items.onsale.get";
        public string Version { get; } = "3.0.0";
        public string Method { get; } = "get";
        private readonly ApiParams _args;
        private readonly Auth _auth;
        public GetOnSaleItemsApi(Auth auth, GetOnSaleItemsParams args) {
            _auth = auth;
            _args = args;
        }

        public ApiResult<YouzanItemsOnsaleGetResult> Execute() {
            var yzClient = new DefaultYZClient(_auth);
            var resultStr = yzClient.Invoke(ApiName, Version, Method, _args.GetParams(), null);
            var result = ApiResult<YouzanItemsOnsaleGetResult>.ParseJson(resultStr);
            return result;
        }
    }
}
