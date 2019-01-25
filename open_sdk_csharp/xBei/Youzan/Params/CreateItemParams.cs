using Newtonsoft.Json;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 新增商品
    /// </summary>
    public class CreateItemParams : ApiParams {
        /// <summary>
        /// 开始出售时间(时间戳格式)，如1541548800，单位秒；默认为0，表示立即出售。
        /// </summary>
        [JsonProperty("auto_listing_time")]
        public long AutoListingTime { get; set; }

        /// <summary>
        /// 每人限购多少件。0代表无限购，默认为0
        /// </summary>
        [JsonProperty("buy_quota")]
        public long BuyQuota { get; set; }

        /// <summary>
        /// 商品分类的叶子类目id，可通过类目列表接口https://open.youzan.com/apilist/detail/group_item/item_category/youzan.itemcategories.get查询获得。
        /// </summary>
        [JsonProperty("cid")]
        [MustFill(0L)]
        public long Cid { get; set; }

        /// <summary>
        /// 运费模版id，可通过运费模板接口https://open.youzan.com/apilist/detail/group_trade/logistics/youzan.logistics.template.search查询获得
        /// </summary>
        [JsonProperty("delivery_template_id")]
        public long DeliveryTemplateId { get; set; }

        /// <summary>
        /// 商品描述。字数要大于5个字符，小于25000个字符,可以包含图片（上传有赞的图片），受违禁词控制。格式如：&lt;p&gt;详情描述测试&lt;/p&gt;&lt;p&gt;&lt;imgdata-origin-width="800"data-origin-height="800"src="https://img.yzcdn.cn/test.jpg"/&gt;&lt;/p&gt;
        /// </summary>
        [JsonProperty("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// 付款成功后发货天数,默认0
        /// </summary>
        [JsonProperty("etd_days")]
        public long EtdDays { get; set; }

        /// <summary>
        /// 预计发货结束时间,字符串格式的时间
        /// </summary>
        [JsonProperty("etd_end")]
        public string EtdEnd { get; set; }

        /// <summary>
        /// 预计发货开始时间,字符串格式的时间
        /// </summary>
        [JsonProperty("etd_start")]
        public string EtdStart { get; set; }

        /// <summary>
        /// 发货类型:0,xxx时间开始发货,1,付款n天后发货。
        /// </summary>
        [JsonProperty("etd_type")]
        public long EtdType { get; set; }

        /// <summary>
        /// 是否隐藏商品库存。在商品展示时不显示商品的库存，默认0显示库存，设置为1不显示库存
        /// </summary>
        [JsonProperty("hide_stock")]
        public long HideStock { get; set; }

        /// <summary>
        /// 酒店扩展信息，按以下格式：
        /// {
        /// "service_tel_code":"0571",//服务电话区号
        /// "service_tel":"4790043"//服务电话
        /// }
        /// </summary>
        [JsonProperty("hotel_extra")]
        public string HotelExtra { get; set; }

        /// <summary>
        /// 图片id列表，用逗号分隔。可以通过youzan.materials.storage.platform.img.upload上传图片接口去上传图片后获取图片id。
        /// </summary>
        [JsonProperty("image_ids")]
        public string ImageIds { get; set; }

        /// <summary>
        /// 是否上架商品。默认1上架商品，设置为0不上架商品，放入仓库
        /// </summary>
        [JsonProperty("is_display")]
        public long IsDisplay { get; set; }

        /// <summary>
        /// 商品货号（商家为商品设置的外部编号）
        /// </summary>
        [JsonProperty("item_no")]
        public string ItemNo { get; set; }

        /// <summary>
        /// 商品类型
        /// 0：普通商品
        /// 35：酒店商品
        /// 60：虚拟商品
        /// 61：电子卡券
        /// </summary>
        [JsonProperty("item_type")]
        public long ItemType { get; set; }

        /// <summary>
        /// 商品重量，没有SKU时用
        /// </summary>
        [JsonProperty("item_weight")]
        public long ItemWeight { get; set; }

        /// <summary>
        /// 商品sku扩展信息，组装成一个JSON,与sku_stocks参数匹配。
        /// 如上面传入的sku_stocks，则s1为颜色对应的vid，
        /// 传入一定要按照这个格式
        /// [
        ///     { "cost_price":2000, //成本价 "s1":1217,规格层级1对应的规格属性ID "s2":1367, "s3":303435, "s4":0, "s5":0 },
        ///     { "cost_price":2000, "s1":1217, "s2":1367, "s3":6356, "s4":0, "s5":0 }
        /// ]
        /// 无规格商品若需要设置成本价则传入
        /// [
        ///     {"cost_price":1700,"s1":0,"s2":0,"s3":0,"s4":0,"s5":0}
        /// ]
        /// 多规格商品若只设置部分规格商品成本价，则无成本价的sku成本价传入-1，如：
        /// [
        ///     { "cost_price":2000, //成本价 "s1":1217,规格层级1对应的规格属性ID "s2":1367, "s3":303435, "s4":0, "s5":0 },
        ///     { "cost_price":-1, "s1":1217, "s2":1367, "s3":6356, "s4":0, "s5":0 }
        /// ]
        /// </summary>
        [JsonProperty("item_sku_extends")]
        public string ItemSkuExtends { get; set; }

        /// <summary>
        /// 是否参加会员折扣。默认1，设置为1参加会员折扣
        /// </summary>
        [JsonProperty("join_level_discount")]
        public long JoinLevelDiscount { get; set; }

        /// <summary>
        /// 商品留言,格式
        /// "messages":"[
        ///     {"datetime":0,"name":"手机","multiple":0,"type":"tel","required":1},
        ///     {"datetime":0,"name":"邮件","multiple":0,"type":"email","required":1},
        ///     {"datetime":0,"name":"留言","multiple":0,"type":"text","required":1},
        ///     {"datetime":0,"name":"日期","multiple":0,"type":"date","required":1},
        ///     {"datetime":1,"name":"时间","multiple":0,"type":"time","required":1},
        ///     {"datetime":0,"name":"身份证","multiple":0,"type":"id_no","required":0},
        ///     {"datetime":0,"name":"图片","multiple":0,"type":"image","required":1}
        /// ]"
        /// 字段解释：
        /// multiple设置字段是否多行，1多行，0单行；
        /// required是否必填，1必填，0可选；
        /// datetime如果设定是时间字段，值为1，其它都为0；
        /// </summary>
        [JsonProperty("messages")]
        public string Messages { get; set; }

        /// <summary>
        /// 商品划线价格，可以自定义。例如促销价：888
        /// </summary>
        [JsonProperty("origin_price")]
        public string OriginPrice { get; set; }

        /// <summary>
        /// 运费，单位分，如传入500表示5元
        /// </summary>
        [JsonProperty("post_fee")]
        public long PostFee { get; set; }

        /// <summary>
        /// 是否预售，是true，否false
        /// </summary>
        [JsonProperty("pre_sale")]
        public bool PreSale { get; set; }

        /// <summary>
        /// 预售结束时间,字符串格式的时间
        /// </summary>
        [JsonProperty("pre_sale_end")]
        public string PreSaleEnd { get; set; }

        /// <summary>
        /// 价格，单位分，如传入11100表示111元
        /// </summary>
        [JsonProperty("price")]
        public long? Price { get; set; }

        /// <summary>
        /// 是否设置商品购买权限
        /// </summary>
        [JsonProperty("purchase_right")]
        public bool PurchaseRight { get; set; }

        /// <summary>
        /// 总库存
        /// </summary>
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        /// <summary>
        /// 商品卖点信息
        /// </summary>
        [JsonProperty("sell_point")]
        public string SellPoint { get; set; }

        /// <summary>
        /// SKU图片，仅支持第一级规格，
        /// 参数一定要与sku_stocks参数匹配，
        /// 如sku_stocks参数是这样的
        /// [
        ///     {"price":10000,"quantity":100,"item_no":"MOYU-1","skus":[{"k":"颜色","v":"绿色",},{"k":"尺寸","v":"l",},{"k":"内存","v":"1024G",}]},
        ///     {"price":10000,"quantity":100,"item_no":"MOYU-2","skus":[{"k":"颜色","v":"绿色",},{"k":"尺寸","v":"l",},{"k":"内存","v":"16G",}]}
        /// ]
        /// 颜色就是第一级规格。它下面的规格只有“绿色”这一项，sku_images应该与之一一对应，如下
        /// [
        ///     {"v":"绿色","img_url":"www.youzan.com"}
        /// ]
        /// 请务必按此格式传参数，不然校验通不过，无法新增商品
        /// </summary>
        [JsonProperty("sku_images")]
        public string SkuImages { get; set; }

        /// <summary>
        /// sku的JSON字符串，传入一定要按照这个格式
        /// [
        ///     {"price":10000,"quantity":100,"item_no":"MOYU-1","skus":[
        ///         {"k":"颜色","v":"绿色",},
        ///         {"k":"尺寸","v":"l",},
        ///         {"k":"内存","v":"1024G",}
        ///     ]},
        ///     {"price":10000,"quantity":100,"item_no":"MOYU-2","skus":[
        ///         {"k":"颜色","v":"绿色",},
        ///         {"k":"尺寸","v":"l",},
        ///         {"k":"内存","v":"16G",}
        ///     ]}
        /// ]
        /// price是sku价格，quantity是sku的库存，item_no是sku的商家编码，k是规格名称，v是规格值名称
        /// 要注意：sku_stocks数量=规格1数量规格2数量规格3数量
        /// </summary>
        [JsonProperty("sku_stocks")]
        public string SkuStocks { get; set; }

        /// <summary>
        /// SKU重量带有SKU时用
        /// 按如下格式
        /// “100，200”
        /// 由重量组成并且和SKU对应
        /// 顺序由业务方来维护（处理逻辑是会先查询商品关联的这个物流模版是不是按重来的，如果不是就不处理这个规格重量，也就不存下来）
        /// </summary>
        [JsonProperty("sku_weight")]
        public string SkuWeight { get; set; }

        /// <summary>
        /// 分组列表,若不传，则会默认加到其他分组当中
        /// </summary>
        [JsonProperty("tag_ids")]
        public string TagIds { get; set; }

        /// <summary>
        /// 商品页模板，可通过https://open.youzan.com/apilist/detail/group_item/item/youzan.item.template.list.search获得
        /// </summary>
        [JsonProperty("template_id")]
        public long TemplateId { get; set; }

        /// <summary>
        /// 商品标题。不能超过100字，受违禁词控制
        /// </summary>
        [JsonProperty("title")]
        [MustFill("")]
        public string Title { get; set; }

        /// <summary>
        /// 允许购买的粉丝等级，用逗号分隔
        /// </summary>
        [JsonProperty("ump_level")]
        public string UmpLevel { get; set; }

        /// <summary>
        /// 允许购买的粉丝标签，用,号分隔
        /// </summary>
        [JsonProperty("ump_tags")]
        public string UmpTags { get; set; }

        /// <summary>
        /// 虚拟信息扩展信息，一定要按如下JSON格式，否则校验不通过
        /// {
        /// 	"item_validity_start":2322222,//虚拟商品有效期开始时间,1970-01-01开始的秒数,留空表示长期有效
        /// 	"item_validity_end":2322222,//虚拟商品有效期结束时间,1970-01-01开始的秒数,留空表示长期有效
        /// 	"effective_type":1,//电子凭证生效类型，0立即生效，1自定义推迟时间，2隔天生效
        /// 	"effective_delay_hours":1,//电子凭证自定义推迟时间
        /// 	"holidays_available":true//节假日是否可用
        /// }
        /// </summary>
        [JsonProperty("virtual_extra")]
        public string VirtualExtra { get; set; }
    }
}