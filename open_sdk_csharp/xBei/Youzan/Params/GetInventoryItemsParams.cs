using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.xBei.Youzan.Params {
    public class GetInventoryItemsParams: GetOnSaleItemsParams {
		/// <summary>
		/// 分类字段。可选值：for_shelved（已下架的）/ sold_out（已售罄的）
		/// </summary>
		public string Banner { get; set; }
    }
}
