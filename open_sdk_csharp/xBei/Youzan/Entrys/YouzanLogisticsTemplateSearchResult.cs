using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanLogisticsTemplateSearchResult {

        /// <summary>
        /// 分页信息
        /// </summary>
        [JsonProperty("paginator")]
        public PaginatorModel Paginator { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        [JsonProperty("items")]
        public LogisticsDeliveryTemplateModel[] Items { get; set; }

        public class ValuationRuleModel {

            /// <summary>
            /// 区域id列表
            /// </summary>
            [JsonProperty("regions")]
            public int[] Regions { get; set; }

            /// <summary>
            /// 首件个数
            /// </summary>
            [JsonProperty("first_amount")]
            public long FirstAmount { get; set; }

            /// <summary>
            /// 首件费用
            /// </summary>
            [JsonProperty("first_fee")]
            public long FirstFee { get; set; }

            /// <summary>
            /// 续件个数
            /// </summary>
            [JsonProperty("additional_amount")]
            public long AdditionalAmount { get; set; }

            /// <summary>
            /// 续件费用
            /// </summary>
            [JsonProperty("additional_fee")]
            public long AdditionalFee { get; set; }

        }

        public class CountryOpenApiModel {

            /// <summary>
            /// 区县id
            /// </summary>
            [JsonProperty("country_id")]
            public long CountryId { get; set; }

            /// <summary>
            /// 规则id
            /// </summary>
            [JsonProperty("rule_id")]
            public long RuleId { get; set; }

        }

        public class LogisticsDeliveryTemplateModel {

            /// <summary>
            /// 运费模板id
            /// </summary>
            [JsonProperty("id")]
            public long Id { get; set; }

            /// <summary>
            /// 店铺id
            /// </summary>
            [JsonProperty("kdt_id")]
            public long KdtId { get; set; }

            /// <summary>
            /// 运费模板名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// 付费类型，1买家付费2卖家付费
            /// </summary>
            [JsonProperty("pay_type")]
            public long PayType { get; set; }

            /// <summary>
            /// 计算类型，1按件2按重量3按体积
            /// </summary>
            [JsonProperty("valuation_type")]
            public long ValuationType { get; set; }

            /// <summary>
            /// 使用次数
            /// </summary>
            [JsonProperty("use_count")]
            public long UseCount { get; set; }

            /// <summary>
            /// 复制于哪个模板
            /// </summary>
            [JsonProperty("is_copy_of")]
            public long IsCopyOf { get; set; }

            /// <summary>
            /// 是否包邮0否1全部2部分
            /// </summary>
            [JsonProperty("is_free_delivery")]
            public long IsFreeDelivery { get; set; }

            /// <summary>
            /// 运费规则
            /// </summary>
            [JsonProperty("valuation_rules")]
            public ValuationRuleModel[] ValuationRules { get; set; }

            /// <summary>
            /// 地区规则
            /// </summary>
            [JsonProperty("open_region_rules")]
            public RegionRuleOpenApiModel OpenRegionRules { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonProperty("created_at")]
            public long CreatedAt { get; set; }

            /// <summary>
            /// 更新时间
            /// </summary>
            [JsonProperty("updated_at")]
            public long UpdatedAt { get; set; }

            /// <summary>
            /// 删除时间
            /// </summary>
            [JsonProperty("deleted_at")]
            public long DeletedAt { get; set; }

        }

        public class CityOpenApiModel {

            /// <summary>
            /// 城市id
            /// </summary>
            [JsonProperty("city_id")]
            public long CityId { get; set; }

            /// <summary>
            /// 规则id
            /// </summary>
            [JsonProperty("rule_id")]
            public long RuleId { get; set; }

        }

        public class RegionRuleOpenApiModel {

            /// <summary>
            /// 市
            /// </summary>
            [JsonProperty("city")]
            public CityOpenApiModel[] City { get; set; }

            /// <summary>
            /// 区
            /// </summary>
            [JsonProperty("country")]
            public CountryOpenApiModel[] Country { get; set; }

            /// <summary>
            /// 省
            /// </summary>
            [JsonProperty("province")]
            public ProvinceOpenApiModel[] Province { get; set; }

        }

        public class PaginatorModel {

            /// <summary>
            /// 页码
            /// </summary>
            [JsonProperty("page")]
            public long Page { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            [JsonProperty("page_size")]
            public long PageSize { get; set; }

            /// <summary>
            /// 总条数
            /// </summary>
            [JsonProperty("totalCount")]
            public long TotalCount { get; set; }

        }

        public class ProvinceOpenApiModel {

            /// <summary>
            /// 省级id
            /// </summary>
            [JsonProperty("province_id")]
            public long ProvinceId { get; set; }

            /// <summary>
            /// 规则id
            /// </summary>
            [JsonProperty("rule_id")]
            public long RuleId { get; set; }

        }
    }
}
