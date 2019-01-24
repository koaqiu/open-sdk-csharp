using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
	public class GetCustomItemsParams : ApiParams {
		/// <summary>
		/// 商品编码
		/// </summary>
		[MustFill("")]
		public string ItemNo { get; set; }
	}
}
