using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.xBei.Youzan {
    interface IApi<T> {
        string ApiName { get; }
        string Version { get; }
        string Method { get; }
        ApiResult<T> Execute();
    }
}
