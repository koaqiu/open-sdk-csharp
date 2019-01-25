using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.xBei.Youzan.Utils {
    public class SkuImageBuilder {
        public IList<SkuItemImage> Items {
            get;
            private set;
        } = new List<SkuItemImage>();
        public static SkuImageBuilder Parse(string json) {
            if (string.IsNullOrWhiteSpace(json))
                return null;
            try {
                return new SkuImageBuilder {
                    Items = JsonConvert.DeserializeObject<IList<SkuItemImage>>(json)
                };
            } catch {
                return new SkuImageBuilder { Items = null };
            }
        }
        public class SkuItemImage {
            /// <summary>
            /// 对于的SKU 值
            /// </summary>
            [JsonProperty("v")]
            public string Value { get; set; }

            /// <summary>
            /// 图片地址
            /// </summary>
            [JsonProperty("img_url")]
            public string ImgUrl { get; set; }
        }
    }
}
