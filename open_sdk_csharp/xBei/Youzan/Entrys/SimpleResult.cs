using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    /// <summary>
    /// 基础的返回信息结构
    /// </summary>
    public class SimpleResult {
        /// <summary>
        /// 操作是否成功，成功为true
        /// </summary>
        [JsonProperty("is_success")]
        public bool IsSuccess { get; set; }
    }
}
