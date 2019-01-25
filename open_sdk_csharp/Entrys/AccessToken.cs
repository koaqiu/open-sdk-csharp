using Newtonsoft.Json;
using System;

namespace YZOpenSDK.Entrys {
	public class AccessToken : BaseEntry {
		/// <summary>
		/// 用于调用 API 的 access_token，有效7天；access_token失效前可通过refresh_token刷新获取新的access_token，有效期仍是7天
		/// </summary>
		[JsonProperty("access_token")]
		public string Token { get; set; }

		/// <summary>
		/// access_token 的有效时长，单位：秒（过期时间：7天）
		/// </summary>
		[JsonProperty("expires_in")]
		public int ExpiresIn { get; set; }

		/// <summary>
		/// access_token 最终的访问范围
		/// </summary>
		[JsonProperty("scope")]
		public string Scope { get; set; }

		/// <summary>
		/// 令牌类型
		/// </summary>
		[JsonProperty("token_type")]
		public string TokenType { get; set; }

		/// <summary>
		/// 用于延长 access_token 有效时间的刷新令牌（过期时间：28 天），在刷新后access_token会返回新的refresh_token
		/// </summary>
		[JsonProperty("refresh_token")]
		public string RefreshToken { get; set; }


		public DateTime CreateTime { get; set; }
	}
}
