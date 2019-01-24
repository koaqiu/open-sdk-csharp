using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanItemsOnsaleGetResult {
        /// <summary>
        ///  商品列表
        /// </summary>
        [JsonProperty("items")]
        public ItemListOpenModel[] Items { get; set; }

        /// <summary>
        ///  搜索到的商品数量
        /// </summary>
        [JsonProperty("count")]
        public long Count { get; set; }


        public class ItemListOpenModel {
            /// <summary>
            ///  商品的数字id
            /// </summary>
            [JsonProperty("item_id")]
            public long ItemId { get; set; }

            /// <summary>
            ///  商品别名，是一串字符
            /// </summary>
            [JsonProperty("alias")]
            public string Alias { get; set; }

            /// <summary>
            ///  商品标题
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            ///  价格，单位分
            /// </summary>
            [JsonProperty("price")]
            public long Price { get; set; }

            /// <summary>
            ///  商品类型
            /// </summary>
            [JsonProperty("item_type")]
            public long ItemType { get; set; }

            /// <summary>
            ///  商家编码，商家给商品设置的商家编码。
            /// </summary>
            [JsonProperty("item_no")]
            public string ItemNo { get; set; }

            /// <summary>
            ///  总库存
            /// </summary>
            [JsonProperty("quantity")]
            public long Quantity { get; set; }

            /// <summary>
            ///  运费类型，1 是统一运费，2是运费模板
            /// </summary>
            [JsonProperty("post_type")]
            public long PostType { get; set; }

            /// <summary>
            ///  运费，单位分。当post_type为1时的运费
            /// </summary>
            [JsonProperty("post_fee")]
            public long PostFee { get; set; }

            /// <summary>
            ///  创建时间
            /// </summary>
            [JsonProperty("created_time")]
            public string CreatedTime { get; set; }

            /// <summary>
            ///  更新时间
            /// </summary>
            [JsonProperty("update_time")]
            public string UpdateTime { get; set; }

            /// <summary>
            ///  商品详情链接
            /// </summary>
            [JsonProperty("detail_url")]
            public string DetailUrl { get; set; }

            /// <summary>
            ///  运费模板信息
            /// </summary>
            [JsonProperty("delivery_template")]
            public DeliveryTemplateOpenModel DeliveryTemplate { get; set; }

            /// <summary>
            ///  商家排序字段
            /// </summary>
            [JsonProperty("num")]
            public long Num { get; set; }

            /// <summary>
            ///  图片信息
            /// </summary>
            [JsonProperty("item_imgs")]
            public ItemImageOpenModel[] ItemImgs { get; set; }

            /// <summary>
            ///  商品划线价
            /// </summary>
            [JsonProperty("origin")]
            public string Origin { get; set; }

            /// <summary>
            ///  默认为"youzan_goods_selling"
            /// </summary>
            [JsonProperty("classId")]
            public string ClassId { get; set; }

            /// <summary>
            ///  图片链接
            /// </summary>
            [JsonProperty("image")]
            public string Image { get; set; }

            /// <summary>
            ///  同image
            /// </summary>
            [JsonProperty("shareIcon")]
            public string ShareIcon { get; set; }

            /// <summary>
            ///  商品标题
            /// </summary>
            [JsonProperty("shareTitle")]
            public string ShareTitle { get; set; }

            /// <summary>
            ///  同price
            /// </summary>
            [JsonProperty("shareDetail")]
            public long ShareDetail { get; set; }

            /// <summary>
            ///  小程序路径
            /// </summary>
            [JsonProperty("pageUrl")]
            public string PageUrl { get; set; }



        }

        public class DeliveryTemplateOpenModel {
            /// <summary>
            ///  运费模板ID
            /// </summary>
            [JsonProperty("delivery_template_id")]
            public long DeliveryTemplateId { get; set; }

            /// <summary>
            ///  运费的范围
            /// </summary>
            [JsonProperty("delivery_template_fee")]
            public string DeliveryTemplateFee { get; set; }

            /// <summary>
            ///  运费模板名称
            /// </summary>
            [JsonProperty("delivery_template_name")]
            public string DeliveryTemplateName { get; set; }

            /// <summary>
            ///  运费模版的计算类型，1 按件 2 按重量 3 按体积
            /// </summary>
            [JsonProperty("delivery_template_valuationType")]
            public long DeliveryTemplateValuationtype { get; set; }



        }

        public class ItemImageOpenModel {
            /// <summary>
            ///  图片链接地址
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }

            /// <summary>
            ///  图片缩略图链接地址
            /// </summary>
            [JsonProperty("thumbnail")]
            public string Thumbnail { get; set; }

            /// <summary>
            ///  中号大小图片链接地址
            /// </summary>
            [JsonProperty("medium")]
            public string Medium { get; set; }

            /// <summary>
            ///  组合图片链接地址
            /// </summary>
            [JsonProperty("combine")]
            public string Combine { get; set; }

            /// <summary>
            ///  图片创建时间，时间格式：yyyy-MM-dd HH:mm:ss
            /// </summary>
            [JsonProperty("created")]
            public string Created { get; set; }

            /// <summary>
            ///  图片ID
            /// </summary>
            [JsonProperty("id")]
            public long Id { get; set; }



        }
    }
}
