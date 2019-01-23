using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan {
    public class GetOnSaleItemsApi : IApi {
        public string ApiName { get; } = "youzan.items.onsale.get";
        public string Version { get; } = "3.0.0";
        public string Method { get; } = "get";
        private readonly ApiParams _args;
        private readonly Auth _auth;
        public GetOnSaleItemsApi(Auth auth, GetOnSaleItemsParams args) {
            _auth = auth;
            _args = args;
        }

        public string Execute() {
            YZClient yzClient = new DefaultYZClient(_auth);
            var result = yzClient.Invoke(ApiName, Version, Method, _args.GetParams(), null);
            return result;
        }
    }
}
