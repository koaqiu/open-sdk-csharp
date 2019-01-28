using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Trades {
    /// <summary>
    /// 确认发货的目的是让交易流程继续走下去，确认发货后交易状态会由【买家已付款】变为【卖家已发货】
    /// </summary>
    public class DeliverGoods : AbstractApi<SimpleResult> {
        public override string ApiName => "youzan.logistics.online.confirm";
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public DeliverGoods(Auth auth, DeliverGoodsParams args) : base(auth, args) {
        }
        /// <summary>
        /// 订单发货
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="tradeId">订单号</param>
        /// <param name="outSid">物流单号</param>
        /// <param name="outStype">物流公司编号</param>
        /// <returns></returns>
        public static async Task<ApiResult<SimpleResult>> DeliverAsync(Auth auth, string tradeId, string outSid, string outStype) {
            return await new DeliverGoods(auth, new DeliverGoodsParams {
                IsNoExpress = 0,
                OutSid = outSid,
                OutStype = outStype,
                Tid = tradeId
            }).ExecuteAsync();
        }
    }
}
