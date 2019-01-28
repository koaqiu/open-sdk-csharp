using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Trades {
    public class MarkTradeSign : AbstractApi<SimpleResult> {
        public override string ApiName => "youzan.logistics.online.marksign";
        public override string Method => ApiRequestMethod.POST;
        /// <summary>
        /// 卖家标记签收
        /// 标记签收后交易状态会由【卖家已发货】变为【买家已签收】
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public MarkTradeSign(Auth auth, GetTradeParams args) : base(auth, args) {
        }
        /// <summary>
        /// 卖家标记签收
        /// 标记签收后交易状态会由【卖家已发货】变为【买家已签收】
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="tradeId">订单号</param>
        /// <returns></returns>
        public static async Task<ApiResult<SimpleResult>> Mark(Auth auth, string tradeId) {
            return await new MarkTradeSign(auth, new GetTradeParams() { Tid = tradeId }).ExecuteAsync();
        }
    }
}
