using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Trades {
    /// <summary>
    /// 订单搜索
    /// </summary>
    public class SearchTrades : AbstractApi<YouzanTradesSoldGetResult> {
        public override string ApiName => "youzan.trades.sold.get";
        public override string Version => "4.0.0";
        /// <summary>
        /// 订单搜索
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public SearchTrades(Auth auth, SearchTradesParams args) : base(auth, args) {
        }
    }
}
