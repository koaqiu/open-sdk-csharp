using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Logistics {
    /// <summary>
    /// 获取店铺所有模板列表
    /// </summary>
    public class SearchLogisticsTemplate : AbstractApi<YouzanLogisticsTemplateSearchResult> {
        public override string ApiName => "youzan.logistics.template.search";
        /// <summary>
        /// 获取店铺所有模板列表
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public SearchLogisticsTemplate(Auth auth, SearchLogisticsTemplateParams args) : base(auth, args) {
        }
    }
}
