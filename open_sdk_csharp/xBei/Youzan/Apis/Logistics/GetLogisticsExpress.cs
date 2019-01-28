using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Apis.Logistics {
    /// <summary>
    /// 获取快递公司的列表
    /// </summary>
    public class GetLogisticsExpress : AbstractApi<YouzanLogisticsExpressGetResult> {
        public override string ApiName => "youzan.logistics.express.get";
        /// <summary>
        /// 获取快递公司的列表
        /// </summary>
        /// <param name="auth"></param>
        public GetLogisticsExpress(Auth auth) : base(auth) {
        }
        /// <summary>
        /// 获取快递公司的列表
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public static async Task<ApiResult<YouzanLogisticsExpressGetResult>> GetExpressAsync(Auth auth) => await new GetLogisticsExpress(auth).ExecuteAsync();
        /// <summary>
        /// 获取快递公司的列表
        /// </summary>
        /// <param name="auth"></param>
        /// <returns></returns>
        public static ApiResult<YouzanLogisticsExpressGetResult> GetExpress(Auth auth) => new GetLogisticsExpress(auth).ExecuteAsync().Result;
    }
}
