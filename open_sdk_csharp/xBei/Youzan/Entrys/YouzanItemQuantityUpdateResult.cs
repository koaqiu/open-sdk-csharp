using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
	public class YouzanItemQuantityUpdateResult {
		/// <summary>
		/// 操作是否成功，成功为true
		/// </summary>
		[JsonProperty("is_success")]
		public bool IsSuccess { get; set; }
	}
}
