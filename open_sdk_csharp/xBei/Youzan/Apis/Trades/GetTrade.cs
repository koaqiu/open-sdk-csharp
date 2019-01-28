using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Trades {
    /// <summary>
    /// 交易订单详情
    /// </summary>
    public class GetTrade : AbstractApi<YouzanTradeGetResult> {
        public override string ApiName => "youzan.trade.get";
        public override string Version => "4.0.0";
        /// <summary>
        /// 交易订单详情
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public GetTrade(Auth auth, GetTradeParams args) : base(auth, args) {
        }
        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="tradeId">订单号</param>
        /// <returns></returns>
        public static async Task<ApiResult<YouzanTradeGetResult>> Get(Auth auth, string tradeId) {
            return await new GetTrade(auth, new GetTradeParams() { Tid = tradeId }).ExecuteAsync();
        }
    }
}
