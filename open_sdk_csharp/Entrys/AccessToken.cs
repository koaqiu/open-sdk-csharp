using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.Entrys {
    public class AccessToken: BaseEntry {
        [JsonProperty("access_token")]
        public string Token { get;set; }
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
        [JsonProperty("scope")]
        public string Scope { get; set; }
        
        public DateTime CreateTime { get; set; }
    }
}
