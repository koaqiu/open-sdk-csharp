using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanItemCreateResult {
        /// <summary>
        /// 创建成功后的商品详情
        /// </summary>
        [JsonProperty("item")]
        public ItemDetailOpenModel Item { get; set; }
        
        public class FenxiaoExtendOpenModel {
            /// <summary>
            /// 供货店铺Id
            /// </summary>
            [JsonProperty("supplier_kdt_id")]
            public long SupplierKdtId { get; set; }

            /// <summary>
            /// 供货商品Id
            /// </summary>
            [JsonProperty("supplier_goods_id")]
            public long SupplierGoodsId { get; set; }
        }

        public class ItemGroupOpenModel {
            /// <summary>
            /// id
            /// </summary>
            [JsonProperty("id")]
            public long Id { get; set; }

            /// <summary>
            /// 分组类型
            /// </summary>
            [JsonProperty("type")]
            public long Type { get; set; }

            /// <summary>
            /// 别名
            /// </summary>
            [JsonProperty("alias")]
            public string Alias { get; set; }

            /// <summary>
            /// 分组链接
            /// </summary>
            [JsonProperty("tag_url")]
            public string TagUrl { get; set; }

            /// <summary>
            /// 分享链接
            /// </summary>
            [JsonProperty("share_url")]
            public string ShareUrl { get; set; }

            /// <summary>
            /// 商品数量
            /// </summary>
            [JsonProperty("item_num")]
            public long ItemNum { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonProperty("created")]
            public string Created { get; set; }

            /// <summary>
            /// 描述
            /// </summary>
            [JsonProperty("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 分组名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }
        }

        public class ItemHotelOpenModel {
            /// <summary>
            /// 客服电话区号
            /// </summary>
            [JsonProperty("service_tel_code")]
            public string ServiceTelCode { get; set; }

            /// <summary>
            /// 客服电话
            /// </summary>
            [JsonProperty("service_tel")]
            public string ServiceTel { get; set; }
        }

        public class DeliveryTemplateOpenModel {
            /// <summary>
            /// 运费模板ID
            /// </summary>
            [JsonProperty("delivery_template_id")]
            public long DeliveryTemplateId { get; set; }

            /// <summary>
            /// 运费的范围
            /// </summary>
            [JsonProperty("delivery_template_fee")]
            public string DeliveryTemplateFee { get; set; }

            /// <summary>
            /// 运费模板名称
            /// </summary>
            [JsonProperty("delivery_template_name")]
            public string DeliveryTemplateName { get; set; }

            /// <summary>
            /// 运费模版的计算类型，1按件2按重量3按体积
            /// </summary>
            [JsonProperty("delivery_template_valuationType")]
            public long DeliveryTemplateValuationtype { get; set; }
        }

        public class SkuImageOpenModel {
            /// <summary>
            /// 规格值ID
            /// </summary>
            [JsonProperty("v_id")]
            public long VId { get; set; }

            /// <summary>
            /// 规格项ID，第一级规格项
            /// </summary>
            [JsonProperty("k_id")]
            public long KId { get; set; }

            /// <summary>
            /// SKU图片链接
            /// </summary>
            [JsonProperty("img_url")]
            public string ImgUrl { get; set; }
        }

        public class ItemDetailOpenModel {
            /// <summary>
            /// 商品id
            /// </summary>
            [JsonProperty("item_id")]
            public long ItemId { get; set; }

            /// <summary>
            /// 店铺id
            /// </summary>
            [JsonProperty("kdt_id")]
            public long KdtId { get; set; }

            /// <summary>
            /// 标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 商品内容
            /// </summary>
            [JsonProperty("desc")]
            public string Desc { get; set; }

            /// <summary>
            /// 商品划线价格，可以自定义。例如促销价：888
            /// </summary>
            [JsonProperty("origin_price")]
            public string OriginPrice { get; set; }

            /// <summary>
            /// 每人限购多少件。0代表无限购，默认为0
            /// </summary>
            [JsonProperty("buy_quota")]
            public long BuyQuota { get; set; }

            /// <summary>
            /// 创建时间
            /// </summary>
            [JsonProperty("created")]
            public string Created { get; set; }

            /// <summary>
            /// 短地址
            /// </summary>
            [JsonProperty("alias")]
            public string Alias { get; set; }

            /// <summary>
            /// 商品分类的叶子类目id
            /// </summary>
            [JsonProperty("cid")]
            public long Cid { get; set; }

            /// <summary>
            /// 商品标签id列表
            /// </summary>
            [JsonProperty("tag_ids")]
            public int[] TagIds { get; set; }

            /// <summary>
            /// 适合wap应用的商品详情url
            /// </summary>
            [JsonProperty("detail_url")]
            public string DetailUrl { get; set; }

            /// <summary>
            /// 分享出去的商品详情url
            /// </summary>
            [JsonProperty("share_url")]
            public string ShareUrl { get; set; }

            /// <summary>
            /// 商品主图片地址
            /// </summary>
            [JsonProperty("pic_url")]
            public string PicUrl { get; set; }

            /// <summary>
            /// 商品主图片缩略图地址
            /// </summary>
            [JsonProperty("pic_thumb_url")]
            public string PicThumbUrl { get; set; }

            /// <summary>
            /// 总库存
            /// </summary>
            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            /// <summary>
            /// 总销量
            /// </summary>
            [JsonProperty("sold_num")]
            public long SoldNum { get; set; }

            /// <summary>
            /// 价格(分)
            /// </summary>
            [JsonProperty("price")]
            public long Price { get; set; }

            /// <summary>
            /// 商品类型
            /// 0：普通商品
            /// 3：UMP降价拍
            /// 5：外卖商品
            /// 10：分销商品
            /// 20：会员卡商品
            /// 21：礼品卡商品
            /// 22：团购券
            /// 25：批发商品
            /// 30：收银台商品
            /// 31：知识付费商品
            /// 35：酒店商品
            /// 40：美业商品
            /// 60：虚拟商品
            /// 61：电子卡券
            /// </summary>
            [JsonProperty("item_type")]
            public long ItemType { get; set; }

            /// <summary>
            /// 商品上架状态。true为已上架，false为已下架
            /// </summary>
            [JsonProperty("is_listing")]
            public bool IsListing { get; set; }

            /// <summary>
            /// 商品是否锁定。true为已锁定，false为未锁定
            /// </summary>
            [JsonProperty("is_lock")]
            public bool IsLock { get; set; }

            /// <summary>
            /// 商品定时上架（定时开售）的时间。没设置则为空
            /// </summary>
            [JsonProperty("auto_listing_time")]
            public string AutoListingTime { get; set; }

            /// <summary>
            /// 是否参加会员折扣
            /// </summary>
            [JsonProperty("join_level_discount")]
            public bool JoinLevelDiscount { get; set; }

            /// <summary>
            /// 是否设置商品购买权限
            /// </summary>
            [JsonProperty("purchase_right")]
            public bool PurchaseRight { get; set; }

            /// <summary>
            /// 运费类型
            /// </summary>
            [JsonProperty("post_type")]
            public long PostType { get; set; }

            /// <summary>
            /// 运费
            /// </summary>
            [JsonProperty("post_fee")]
            public long PostFee { get; set; }

            /// <summary>
            /// 商品货号（商家为商品设置的外部编号，可与商家外部系统对接）
            /// </summary>
            [JsonProperty("item_no")]
            public string ItemNo { get; set; }

            /// <summary>
            /// 商品预售信息
            /// </summary>
            [JsonProperty("presale_extend")]
            public ItemPreSaleOpenModel PresaleExtend { get; set; }

            /// <summary>
            /// 商品分销信息
            /// </summary>
            [JsonProperty("fenxiao_extend")]
            public FenxiaoExtendOpenModel FenxiaoExtend { get; set; }

            /// <summary>
            /// 商品酒店扩展信息
            /// </summary>
            [JsonProperty("hotel_extend")]
            public ItemHotelOpenModel HotelExtend { get; set; }

            /// <summary>
            /// 虚拟商品扩展信息
            /// </summary>
            [JsonProperty("virtual_extend")]
            public ItemVirtualOpenModel VirtualExtend { get; set; }

            /// <summary>
            /// 运费模板信息
            /// </summary>
            [JsonProperty("delivery_template_info")]
            public DeliveryTemplateOpenModel DeliveryTemplateInfo { get; set; }

            /// <summary>
            /// 商品规格库存信息
            /// </summary>
            [JsonProperty("skus")]
            public ItemSkuOpenModel[] Skus { get; set; }

            /// <summary>
            /// 图片信息
            /// </summary>
            [JsonProperty("item_imgs")]
            public ItemImageOpenModel[] ItemImgs { get; set; }

            /// <summary>
            /// 分组信息
            /// </summary>
            [JsonProperty("item_tags")]
            public ItemGroupOpenModel[] ItemTags { get; set; }

            /// <summary>
            /// 商品留言
            /// </summary>
            [JsonProperty("messages")]
            public string Messages { get; set; }

            /// <summary>
            /// 商品详情模板信息
            /// </summary>
            [JsonProperty("template")]
            public TemplateOpenModel Template { get; set; }

            /// <summary>
            /// 购买权限信息
            /// </summary>
            [JsonProperty("purchase_rightList")]
            public PurchaseRightOpenModel PurchaseRightlist { get; set; }

            /// <summary>
            /// openapi商品SKU图片模型
            /// </summary>
            [JsonProperty("sku_images")]
            public SkuImageOpenModel[] SkuImages { get; set; }

            /// <summary>
            /// 商家排序字段
            /// </summary>
            [JsonProperty("num")]
            public long Num { get; set; }

            /// <summary>
            /// 商品卖点
            /// </summary>
            [JsonProperty("sell_point")]
            public string SellPoint { get; set; }
        }

        public class ItemVirtualOpenModel {
            /// <summary>
            /// 虚拟商品有效期开始时间
            /// </summary>
            [JsonProperty("item_validity_start")]
            public string ItemValidityStart { get; set; }

            /// <summary>
            /// 虚拟商品有效期结束时间
            /// </summary>
            [JsonProperty("item_validity_end")]
            public string ItemValidityEnd { get; set; }

            /// <summary>
            /// 电子凭证生效类型，0立即生效，1自定义推迟时间，2隔天生效
            /// </summary>
            [JsonProperty("effective_type")]
            public long EffectiveType { get; set; }

            /// <summary>
            /// 电子凭证自定义推迟时间
            /// </summary>
            [JsonProperty("effective_delay_hours")]
            public long EffectiveDelayHours { get; set; }

            /// <summary>
            /// 节假日是否可用
            /// </summary>
            [JsonProperty("holidays_available")]
            public bool HolidaysAvailable { get; set; }
        }

        public class ItemSkuOpenModel {
            /// <summary>
            /// 商品ID
            /// </summary>
            [JsonProperty("item_id")]
            public long ItemId { get; set; }

            /// <summary>
            /// 规格ID
            /// </summary>
            [JsonProperty("sku_id")]
            public long SkuId { get; set; }

            /// <summary>
            /// 唯一编码，店铺Id和商品Id组合
            /// </summary>
            [JsonProperty("sku_unique_code")]
            public string SkuUniqueCode { get; set; }

            /// <summary>
            /// Sku所对应的销售属性的Json字符串（需另行解析）。
            /// 格式定义：
            /// [
            /// {
            /// "kid":"20000",
            /// "vid":"3275069",
            /// "k":"品牌",
            /// "v":"盈讯"
            /// },
            /// {
            /// "kid":"1753146",
            /// "vid":"3485013",
            /// "k":"型号",
            /// "v":"F908"
            /// }
            /// </summary>
            [JsonProperty("properties_name_json")]
            public string PropertiesNameJson { get; set; }

            /// <summary>
            /// 商品在付款减库存的状态下，该Sku上未付款的订单数量
            /// </summary>
            [JsonProperty("with_hold_quantity")]
            public long WithHoldQuantity { get; set; }

            /// <summary>
            /// 商品的这个Sku的价格，单位分
            /// </summary>
            [JsonProperty("price")]
            public long Price { get; set; }

            /// <summary>
            /// Sku创建日期，时间格式：yyyy-MM-ddHH:mm:ss
            /// </summary>
            [JsonProperty("created")]
            public string Created { get; set; }

            /// <summary>
            /// Sku最后修改日期，时间格式：yyyy-MM-ddHH:mm:ss
            /// </summary>
            [JsonProperty("modified")]
            public string Modified { get; set; }

            /// <summary>
            /// 属于这个Sku的商品的数量
            /// </summary>
            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            /// <summary>
            /// 商家编码（商家为Sku设置的外部编号）
            /// </summary>
            [JsonProperty("item_no")]
            public string ItemNo { get; set; }

            /// <summary>
            /// 属于这个Sku的销量
            /// </summary>
            [JsonProperty("sold_num")]
            public long SoldNum { get; set; }

            /// <summary>
            /// 属于这个Sku的成本价
            /// </summary>
            [JsonProperty("cost_price")]
            public long CostPrice { get; set; }
        }

        public class TemplateOpenModel {
            /// <summary>
            /// 模板ID
            /// </summary>
            [JsonProperty("template_id")]
            public long TemplateId { get; set; }

            /// <summary>
            /// 模板名称
            /// </summary>
            [JsonProperty("template_title")]
            public string TemplateTitle { get; set; }
        }

        public class ItemImageOpenModel {
            /// <summary>
            /// 图片链接地址
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            /// 图片缩略图链接地址
            /// </summary>
            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }

            /// <summary>
            /// 中号大小图片链接地址
            /// </summary>
            [JsonProperty("medium")]
            public string Medium { get; set; }

            /// <summary>
            /// 组合图片链接地址
            /// </summary>
            [JsonProperty("combine")]
            public string Combine { get; set; }

            /// <summary>
            /// 图片创建时间，时间格式：yyyy-MM-ddHH:mm:ss
            /// </summary>
            [JsonProperty("created")]
            public string Created { get; set; }

            /// <summary>
            /// 图片ID
            /// </summary>
            [JsonProperty("id")]
            public long Id { get; set; }
        }

        public class PurchaseRightOpenModel {
            /// <summary>
            /// 可购买该商品的用户标签id列表
            /// </summary>
            [JsonProperty("ump_tags")]
            public string[] UmpTags { get; set; }

            /// <summary>
            /// 可购买该商品的会员等级id列表
            /// </summary>
            [JsonProperty("ump_levels")]
            public string[] UmpLevels { get; set; }

            /// <summary>
            /// 可购买该商品的用户标签名称列表
            /// </summary>
            [JsonProperty("ump_tags_text")]
            public string[] UmpTagsText { get; set; }

            /// <summary>
            /// 可购买该商品的会员等级名称列表
            /// </summary>
            [JsonProperty("ump_level_text")]
            public string[] UmpLevelText { get; set; }
        }

        public class ItemPreSaleOpenModel {
            /// <summary>
            /// 预售结束时间
            /// </summary>
            [JsonProperty("presale_end")]
            public string PresaleEnd { get; set; }

            /// <summary>
            /// 发货开始时间
            /// </summary>
            [JsonProperty("etd_start")]
            public string EtdStart { get; set; }

            /// <summary>
            /// 发货结束时间
            /// </summary>
            [JsonProperty("etd_end")]
            public string EtdEnd { get; set; }

            /// <summary>
            /// 发货类型:0,xxx时间开始发货,1,付款n天后发货。
            /// </summary>
            [JsonProperty("etd_type")]
            public long EtdType { get; set; }

            /// <summary>
            /// 付款成功后发货天数。
            /// </summary>
            [JsonProperty("etd_days")]
            public long EtdDays { get; set; }
        }
    }
}
