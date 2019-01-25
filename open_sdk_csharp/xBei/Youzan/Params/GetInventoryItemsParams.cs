namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 获取仓库中的商品列表,仅返回商品部分信息	
    /// </summary>
    public class GetInventoryItemsParams: GetOnSaleItemsParams {
		/// <summary>
		/// 分类字段。可选值：for_shelved（已下架的）/ sold_out（已售罄的）
		/// </summary>
		public string Banner { get; set; }
    }
}
