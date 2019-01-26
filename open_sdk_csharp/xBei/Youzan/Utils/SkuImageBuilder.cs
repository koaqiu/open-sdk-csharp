using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public SkuImageBuilder AddItem(string value, string imgUrl) => AddItems(new [] {value, imgUrl});
        public SkuImageBuilder AddItems(IList<string> images) {
            if (images.Count % 2 != 0) throw new Exception("SKU Image 信息错误");
            for (var i = 0; i <= images.Count / 2; i += 2) {
                Items.Add(new SkuItemImage(images[i], images[i + 1]));
            }
            return this;
        }

        public SkuImageBuilder AddItem(SkuBuilder sku, string value, string imgUrl) => AddItems(sku, new [] { value, imgUrl });
        public SkuImageBuilder AddItems(SkuBuilder sku, IList<string> images) {
            if (images.Count % 2 != 0) throw new Exception("SKU Image 信息错误");
            var skuValues = sku.Items.Select(item => item.SkuList.First().Value).Distinct().ToList();
            for (var i = 0; i <= images.Count / 2; i += 2) {
                if (!skuValues.Contains(images[i])) {
                    throw new Exception($"{images[i]} 无效！，有效的值：{string.Join(',', skuValues)}");
                }
                Items.Add(new SkuItemImage(images[i], images[i + 1]));
            }
            return this;
        }
        public string ToJson() {
            if (Items.Count < 1) return "";
            return JsonConvert.SerializeObject(Items);
        }
        public class SkuItemImage {
            public SkuItemImage(string value, string imgUrl) {
                Value = value;
                ImgUrl = imgUrl;
            }
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
