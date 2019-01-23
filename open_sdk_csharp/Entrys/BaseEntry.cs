using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.Entrys {
    public class BaseEntry {
        public static T FromJson<T>(string json) where T : BaseEntry {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ToJson() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
