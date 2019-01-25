using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Utils {
    public class SkuBuilder {

        public IList<SkuItem> Items {
            get;
            private set;
        } = new List<SkuItem>();

        public static SkuBuilder Parse(string json) {
            if (string.IsNullOrWhiteSpace(json))
                return null;
            try {
                return new SkuBuilder {
                    Items = JsonConvert.DeserializeObject<IList<SkuItem>>(json)
                };
            } catch {
                return new SkuBuilder { Items = null };
            }
        }

        public SkuBuilder AddItem(int price, int quantity, IList<string> skus, string itemNo = "") {
            if (skus.Count % 2 != 0) throw new Exception("SKU信息错误");
            var list = new List<Sku>();
            for (var i = 0; i <= skus.Count / 2; i += 2) {
                list.Add(new Sku(skus[i], skus[i + 1]));
            }
            Items.Add(new SkuItem {
                Price = price,
                Quantity = quantity,
                ItemNo = itemNo,
                SkuList = list
            });
            return this;
        }
        public SkuBuilder AddItem(int price, int quantity, IList<Sku> skus, string itemNo = "") {
            Items.Add(new SkuItem {
                Price = price,
                Quantity = quantity,
                ItemNo = itemNo,
                SkuList = skus
            });
            return this;
        }

        private static string fix(string json) {
            return json.Replace(",\"item_no\":\"\"", "");
        }
        public string ToJson() {
            if (Items.Count < 1) return "";
            if (Items.Count < 2) {
                if (Items[0].SkuList?.Count < 1)
                    throw new Exception("缺失SKU信息");
                return fix(JsonConvert.SerializeObject(Items));
            }

            var s = Items[0].SkuList?.Count;
            if (s < 1) throw new Exception("缺失SKU信息");
            for (var i = 1; i < Items.Count; i++) {
                if (s != Items[i].SkuList.Count)
                    throw new Exception($"第{i + 1}条记录的SKU项目数量不匹配！需要：{s}只有：{Items[i].SkuList.Count}。");
            }

            if (Items.Select(i2 => string.Join("", i2.SkuList.Select(item => $"{item.Key}={item.Value}"))).Distinct().Count() != Items.Count) {
                throw new Exception("有重复的SKU条目");
            }

            // ReSharper disable once AssignNullToNotNullAttribute
            var allKeys = Items[0].SkuList.Select(item => item.Key).Distinct();
            var keyVaule = allKeys.ToDictionary(key => key, key => Items.Select(i => i.SkuList.FirstOrDefault(ss => ss.Key == key).Value).Distinct().Count());
            var mustItemCount = keyVaule.Values.Aggregate((workingSentence, next) => workingSentence * next);
            if (Items.Count != mustItemCount)
                throw new Exception($"一共需要{mustItemCount}条SKU记录，现在只有{Items.Count}条");
            return fix(JsonConvert.SerializeObject(Items));
        }

        public class SkuItem {
            /// <summary>
            /// 价格，单位分，如传入11100表示111元
            /// </summary>
            [JsonProperty("price")]
            public int Price { get; set; }

            /// <summary>
            /// 总库存
            /// </summary>
            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            /// <summary>
            /// 商品货号（商家为商品设置的外部编号）
            /// </summary>
            [JsonProperty("item_no", NullValueHandling = NullValueHandling.Ignore)]
            public string ItemNo { get; set; }

            /// <summary>
            /// SKU清单
            /// </summary>
            [JsonProperty("skus")]
            public IList<Sku> SkuList { get; set; }
        }

        public class Sku {
            public Sku(string key, string value) {
                Key = key;
                Value = value;
            }

            [JsonProperty("k")]
            public string Key { get; set; }
            [JsonProperty("v")]
            public string Value { get; set; }
        }
    }
}
