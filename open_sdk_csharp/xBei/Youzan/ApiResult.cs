using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan {
    public class ApiResult<T> {
        [JsonProperty("error_response", NullValueHandling = NullValueHandling.Ignore)]
        public ErrorResponseModel ErrorResponse { get; set; }
        [JsonProperty("response", NullValueHandling = NullValueHandling.Ignore)]
        public T Response { get; set; }
        public static ApiResult<T> ParseJson(string json) {
            return JsonConvert.DeserializeObject<ApiResult<T>>(json);
        }
        public string ToJson(Formatting formatting = Formatting.None) {
            return JsonConvert.SerializeObject(this, formatting);
        }

        public override string ToString() => ToJson(Formatting.Indented);

        public bool HasError() => ErrorResponse?.Code > 0;
    }
    public class ErrorResponseModel {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("msg")]
        public string Msg { get; set; }

        [JsonProperty("sub_code")]
        public int SubCode { get; set; }

        [JsonProperty("sub_data")]
        public string SubData { get; set; }

        [JsonProperty("sub_msg")]
        public string SubMsg { get; set; }
    }
}
