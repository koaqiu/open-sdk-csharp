using Newtonsoft.Json;
using System;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanTradesSoldGetResult {

        /// <summary>
        /// 交易基础信息结构体
        /// </summary>
        [JsonProperty("full_order_info_list")]
        public StructurizationTrade[] FullOrderInfoList { get; set; }

        /// <summary>
        /// 搜索订单总条数
        /// </summary>
        [JsonProperty("total_results")]
        public long TotalResults { get; set; }

        public class StructurizationOrderInfoDetailExtra {

            /// <summary>
            /// 是否来自购物车是：true不是：false
            /// </summary>
            [JsonProperty("is_from_cart")]
            public string IsFromCart { get; set; }

            /// <summary>
            /// 收银员id
            /// </summary>
            [JsonProperty("cashier_id")]
            public string CashierId { get; set; }

            /// <summary>
            /// 收银员名字
            /// </summary>
            [JsonProperty("cashier_name")]
            public string CashierName { get; set; }

            /// <summary>
            /// 发票抬头
            /// </summary>
            [JsonProperty("invoice_title")]
            public string InvoiceTitle { get; set; }

            /// <summary>
            /// 结算时间
            /// </summary>
            [JsonProperty("settle_time")]
            public string SettleTime { get; set; }

            /// <summary>
            /// 是否父单(分销合并订单)是：1其他：null
            /// </summary>
            [JsonProperty("is_parent_order")]
            public string IsParentOrder { get; set; }

            /// <summary>
            /// 是否子单(分销买家订单)是：1其他：null
            /// </summary>
            [JsonProperty("is_sub_order")]
            public string IsSubOrder { get; set; }

            /// <summary>
            /// 分销单订单号
            /// </summary>
            [JsonProperty("fx_order_no")]
            public string FxOrderNo { get; set; }

            /// <summary>
            /// 分销店铺id
            /// </summary>
            [JsonProperty("fx_kdt_id")]
            public string FxKdtId { get; set; }

            /// <summary>
            /// 父单号
            /// </summary>
            [JsonProperty("parent_order_no")]
            public string ParentOrderNo { get; set; }

            /// <summary>
            /// 采购单订单号
            /// </summary>
            [JsonProperty("purchase_order_no")]
            public string PurchaseOrderNo { get; set; }

            /// <summary>
            /// 美业分店id
            /// </summary>
            [JsonProperty("dept_id")]
            public string DeptId { get; set; }

            /// <summary>
            /// 下单设备号
            /// </summary>
            [JsonProperty("create_device_id")]
            public string CreateDeviceId { get; set; }

            /// <summary>
            /// 是否是积分订单：1：是0：不是
            /// </summary>
            [JsonProperty("is_points_order")]
            public string IsPointsOrder { get; set; }

            /// <summary>
            /// 海淘身份证信息：332527XXXXXXXXX
            /// </summary>
            [JsonProperty("id_card_number")]
            public string IdCardNumber { get; set; }

            /// <summary>
            /// 下单人昵称
            /// </summary>
            [JsonProperty("buyer_name")]
            public string BuyerName { get; set; }

            /// <summary>
            /// 是否会员订单
            /// </summary>
            [JsonProperty("is_member")]
            public string IsMember { get; set; }

            /// <summary>
            /// 团购返现优惠金额
            /// </summary>
            [JsonProperty("tm_cash")]
            public long TmCash { get; set; }

            /// <summary>
            /// 团购返现最大返现金额
            /// </summary>
            [JsonProperty("t_cash")]
            public long TCash { get; set; }

            /// <summary>
            /// 订单返现金额
            /// </summary>
            [JsonProperty("cash")]
            public long Cash { get; set; }

            /// <summary>
            /// 虚拟总单号：一次下单发生拆单时，会生成一个虚拟总单号
            /// </summary>
            [JsonProperty("orders_combine_id")]
            public string OrdersCombineId { get; set; }

            /// <summary>
            /// 拆单时店铺维度的虚拟总单号：发生拆单时，单个店铺生成了多笔订单会生成一个店铺维度的虚拟总单号
            /// </summary>
            [JsonProperty("kdt_dimension_combine_id")]
            public string KdtDimensionCombineId { get; set; }

            /// <summary>
            /// 使用了同一张优惠券&优惠码的多笔订单对应的虚拟总单号
            /// </summary>
            [JsonProperty("promotion_combine_id")]
            public string PromotionCombineId { get; set; }

        }

        public class StructurizationTradePhasePaymentsDetail {

            /// <summary>
            /// 支付阶段
            /// </summary>
            [JsonProperty("phase")]
            public long Phase { get; set; }

            /// <summary>
            /// 支付开始时间
            /// </summary>
            [JsonProperty("pay_start_time")]
            public DateTime PayStartTime { get; set; }

            /// <summary>
            /// 支付结束时间
            /// </summary>
            [JsonProperty("pay_end_time")]
            public DateTime PayEndTime { get; set; }

            /// <summary>
            /// 阶段支付金额
            /// </summary>
            [JsonProperty("real_price")]
            public long RealPrice { get; set; }

            /// <summary>
            /// 外部支付流水号
            /// </summary>
            [JsonProperty("outer_transaction_no")]
            public string OuterTransactionNo { get; set; }

            /// <summary>
            /// 内部支付流水号
            /// </summary>
            [JsonProperty("inner_transaction_no")]
            public string InnerTransactionNo { get; set; }

        }

        public class StructurizationTrade {

            /// <summary>
            /// 交易基础信息结构体
            /// </summary>
            [JsonProperty("full_order_info")]
            public StructurizationTradeOrderInfo FullOrderInfo { get; set; }

        }

        public class StructurizationTradeChildOrderDetail {

            /// <summary>
            /// 订单号
            /// </summary>
            [JsonProperty("tid")]
            public string Tid { get; set; }

            /// <summary>
            /// 领取人姓名
            /// </summary>
            [JsonProperty("user_name")]
            public string UserName { get; set; }

            /// <summary>
            /// 领取人电话
            /// </summary>
            [JsonProperty("user_tel")]
            public string UserTel { get; set; }

            /// <summary>
            /// 省
            /// </summary>
            [JsonProperty("province")]
            public string Province { get; set; }

            /// <summary>
            /// 市
            /// </summary>
            [JsonProperty("city")]
            public string City { get; set; }

            /// <summary>
            /// 区
            /// </summary>
            [JsonProperty("county")]
            public string County { get; set; }

            /// <summary>
            /// 收货地址详情
            /// </summary>
            [JsonProperty("address_detail")]
            public string AddressDetail { get; set; }

            /// <summary>
            /// 老送礼订单状态：WAIT_EXPRESS(5,"待发货"),EXPRESS(6,"已发货"),SUCCESS(100,"成功")
            /// </summary>
            [JsonProperty("order_state")]
            public string OrderState { get; set; }

        }

        public class StructurizationTradeBuyerInfoDetail {

            /// <summary>
            /// 买家id
            /// </summary>
            [JsonProperty("buyer_id")]
            public long BuyerId { get; set; }

            /// <summary>
            /// 买家手机号
            /// </summary>
            [JsonProperty("buyer_phone")]
            public string BuyerPhone { get; set; }

            /// <summary>
            /// 粉丝类型
            /// 1:自有粉丝;9:代销粉丝
            /// </summary>
            [JsonProperty("fans_type")]
            public long FansType { get; set; }

            /// <summary>
            /// 粉丝id
            /// </summary>
            [JsonProperty("fans_id")]
            public long FansId { get; set; }

            /// <summary>
            /// 粉丝昵称
            /// </summary>
            [JsonProperty("fans_nickname")]
            public string FansNickname { get; set; }

            /// <summary>
            /// 外部用户ID
            /// </summary>
            [JsonProperty("outer_user_id")]
            public string OuterUserId { get; set; }

        }

        public class StructurizationTradeRemarkInfoDetail {

            /// <summary>
            /// 订单买家留言
            /// </summary>
            [JsonProperty("buyer_message")]
            public string BuyerMessage { get; set; }

            /// <summary>
            /// 订单标星等级0-5
            /// </summary>
            [JsonProperty("star")]
            public long Star { get; set; }

            /// <summary>
            /// 订单商家备注
            /// </summary>
            [JsonProperty("trade_memo")]
            public string TradeMemo { get; set; }

        }

        public class StructurizationTradeSourceInfo {

            /// <summary>
            /// 是否来自线下订单
            /// </summary>
            [JsonProperty("is_offline_order")]
            public bool IsOfflineOrder { get; set; }

            /// <summary>
            /// 订单来源平台
            /// </summary>
            [JsonProperty("source")]
            public StructurizationTradeSource Source { get; set; }

            /// <summary>
            /// 订单标记
            /// wx_apps:微信小程序买家版
            /// wx_shop:微信小程序商家版
            /// wx_wm:微信小程序外卖
            /// wap_wm:移动端外卖
            /// super_store:超级门店
            /// weapp_spotlight:新微信小程序买家版
            /// wx_meiye:美业小程序
            /// wx_apps_maidan:小程序餐饮买单
            /// wx_apps_diancan:小程序堂食
            /// weapp_youzan:有赞小程序
            /// retail_free_buy:零售自由购
            /// weapp_owl:知识付费小程序
            /// app_spotlight:有赞精选app
            /// retail_scan_buy:零售扫码购
            /// weapp_plugin:小程序插件
            /// 除以上之外为其他
            /// </summary>
            [JsonProperty("order_mark")]
            public string OrderMark { get; set; }

            /// <summary>
            /// 订单唯一识别码
            /// </summary>
            [JsonProperty("book_key")]
            public string BookKey { get; set; }

            /// <summary>
            /// 活动类型：如群团购：”mall_group_buy“
            /// </summary>
            [JsonProperty("biz_source")]
            public string BizSource { get; set; }

        }

        public class StructurizationTradeItemDetail {

            /// <summary>
            /// 订单明细id
            /// </summary>
            [JsonProperty("oid")]
            public string Oid { get; set; }

            /// <summary>
            /// 订单类型
            /// 0:普通类型商品;1:拍卖商品;5:餐饮商品;10:分销商品;20:会员卡商品;21:礼品卡商品;23:有赞会议商品;24:周期购;30:收银台商品;31:知识付费商品;35:酒店商品;40:普通服务类商品;182:普通虚拟商品;183:电子卡券商品;201:外部会员卡商品;202:外部直接收款商品;203:外部普通商品;205:mock不存在商品;206:小程序二维码
            /// </summary>
            [JsonProperty("item_type")]
            public long ItemType { get; set; }

            /// <summary>
            /// 商品名称
            /// </summary>
            [JsonProperty("title")]
            public string Title { get; set; }

            /// <summary>
            /// 商品数量
            /// </summary>
            [JsonProperty("num")]
            public long Num { get; set; }

            /// <summary>
            /// 商家编码
            /// </summary>
            [JsonProperty("outer_sku_id")]
            public string OuterSkuId { get; set; }

            /// <summary>
            /// 商品留言
            /// </summary>
            [JsonProperty("buyer_messages")]
            public string BuyerMessages { get; set; }

            /// <summary>
            /// 单商品原价
            /// </summary>
            [JsonProperty("price")]
            public float Price { get; set; }

            /// <summary>
            /// 商品优惠后总价
            /// </summary>
            [JsonProperty("total_fee")]
            public float TotalFee { get; set; }

            /// <summary>
            /// 商品最终均摊价
            /// </summary>
            [JsonProperty("payment")]
            public float Payment { get; set; }

            /// <summary>
            /// 商品id
            /// </summary>
            [JsonProperty("item_id")]
            public long ItemId { get; set; }

            /// <summary>
            /// 规格id（无规格商品为0）
            /// </summary>
            [JsonProperty("sku_id")]
            public long SkuId { get; set; }

            /// <summary>
            /// 规格信息（无规格商品为空）
            /// </summary>
            [JsonProperty("sku_properties_name")]
            public string SkuPropertiesName { get; set; }

            /// <summary>
            /// 商品编码
            /// </summary>
            [JsonProperty("outer_item_id")]
            public string OuterItemId { get; set; }

            /// <summary>
            /// 商品积分价（非积分商品则为0）
            /// </summary>
            [JsonProperty("points_price")]
            public string PointsPrice { get; set; }

            /// <summary>
            /// 商品图片地址
            /// </summary>
            [JsonProperty("pic_path")]
            public string PicPath { get; set; }

            /// <summary>
            /// 商品详情链接
            /// </summary>
            [JsonProperty("goods_url")]
            public string GoodsUrl { get; set; }

            /// <summary>
            /// 商品别名
            /// </summary>
            [JsonProperty("alias")]
            public string Alias { get; set; }

            /// <summary>
            /// 是否赠品
            /// </summary>
            [JsonProperty("is_present")]
            public bool IsPresent { get; set; }

            /// <summary>
            /// 单商品现价，减去了商品的优惠金额
            /// </summary>
            [JsonProperty("discount_price")]
            public float DiscountPrice { get; set; }

            /// <summary>
            /// 商品唯一编码
            /// </summary>
            [JsonProperty("sku_unique_code")]
            public string SkuUniqueCode { get; set; }

            /// <summary>
            /// 0全款预售，1定金预售
            /// </summary>
            [JsonProperty("pre_sale_type")]
            public string PreSaleType { get; set; }

            /// <summary>
            /// 是否为预售商品如果是预售商品则为1
            /// </summary>
            [JsonProperty("is_pre_sale")]
            public string IsPreSale { get; set; }

        }

        public class StructurizationTradeChildOrderInfo {

            /// <summary>
            /// 送礼编号
            /// </summary>
            [JsonProperty("gift_no")]
            public string GiftNo { get; set; }

            /// <summary>
            /// 送礼标记
            /// </summary>
            [JsonProperty("gift_sign")]
            public string GiftSign { get; set; }

            /// <summary>
            /// 送礼子单详情
            /// </summary>
            [JsonProperty("child_orders")]
            public StructurizationTradeChildOrderDetail[] ChildOrders { get; set; }

        }

        public class StructurizationTradeOrderInfo {

            /// <summary>
            /// 交易明细详情
            /// </summary>
            [JsonProperty("order_info")]
            public StructurizationOrderInfoDetail OrderInfo { get; set; }

            /// <summary>
            /// 订单来源
            /// </summary>
            [JsonProperty("source_info")]
            public StructurizationTradeSourceInfo SourceInfo { get; set; }

            /// <summary>
            /// 订单买家信息结构体
            /// </summary>
            [JsonProperty("buyer_info")]
            public StructurizationTradeBuyerInfoDetail BuyerInfo { get; set; }

            /// <summary>
            /// 交易支付信息结构体
            /// </summary>
            [JsonProperty("pay_info")]
            public StructurizationTradePayInfoDetail PayInfo { get; set; }

            /// <summary>
            /// 订单标记信息结构体
            /// </summary>
            [JsonProperty("remark_info")]
            public StructurizationTradeRemarkInfoDetail RemarkInfo { get; set; }

            /// <summary>
            /// 订单收货地址信息结构体
            /// </summary>
            [JsonProperty("address_info")]
            public StructurizationTradeAddressInfoDetail AddressInfo { get; set; }

            /// <summary>
            /// 订单明细结构体
            /// </summary>
            [JsonProperty("orders")]
            public StructurizationTradeItemDetail[] Orders { get; set; }

            /// <summary>
            /// 交易送礼子单
            /// </summary>
            [JsonProperty("child_info")]
            public StructurizationTradeChildOrderInfo ChildInfo { get; set; }

        }

        public class StructurizationTradeSource {

            /// <summary>
            /// 平台
            /// wx:微信;merchant_3rd:商家自有app;buyer_v:买家版;browser:系统浏览器;alipay:支付宝;qq:腾讯QQ;wb:微博;other:其他
            /// </summary>
            [JsonProperty("platform")]
            public string Platform { get; set; }

            /// <summary>
            /// 微信平台细分
            /// wx_gzh:微信公众号;yzdh:有赞大号;merchant_xcx:商家小程序;yzdh_xcx:有赞大号小程序;direct_buy:直接购买
            /// </summary>
            [JsonProperty("wx_entrance")]
            public string WxEntrance { get; set; }

        }

        public class StructurizationTradePayInfoDetail {

            /// <summary>
            /// 优惠前商品总价
            /// </summary>
            [JsonProperty("total_fee")]
            public float TotalFee { get; set; }

            /// <summary>
            /// 邮费
            /// </summary>
            [JsonProperty("post_fee")]
            public float PostFee { get; set; }

            /// <summary>
            /// 最终支付价格
            /// payment=orders.payment的总和
            /// </summary>
            [JsonProperty("payment")]
            public float Payment { get; set; }

            /// <summary>
            /// 有赞支付流水号
            /// </summary>
            [JsonProperty("transaction")]
            public String[] Transaction { get; set; }

            /// <summary>
            /// 外部支付单号
            /// </summary>
            [JsonProperty("outer_transactions")]
            public String[] OuterTransactions { get; set; }

            /// <summary>
            /// 多阶段信息结构体
            /// </summary>
            [JsonProperty("phase_payments")]
            public StructurizationTradePhasePaymentsDetail PhasePayments { get; set; }

        }

        public class StructurizationOrderInfoDetailTags {

            /// <summary>
            /// 是否虚拟订单
            /// </summary>
            [JsonProperty("is_virtual")]
            public bool IsVirtual { get; set; }

            /// <summary>
            /// 是否采购单
            /// </summary>
            [JsonProperty("is_purchase_order")]
            public bool IsPurchaseOrder { get; set; }

            /// <summary>
            /// 是否分销单
            /// </summary>
            [JsonProperty("is_fenxiao_order")]
            public bool IsFenxiaoOrder { get; set; }

            /// <summary>
            /// 是否会员订单
            /// </summary>
            [JsonProperty("is_member")]
            public bool IsMember { get; set; }

            /// <summary>
            /// 是否预订单
            /// </summary>
            [JsonProperty("is_preorder")]
            public bool IsPreorder { get; set; }

            /// <summary>
            /// 是否线下订单
            /// </summary>
            [JsonProperty("is_offline_order")]
            public bool IsOfflineOrder { get; set; }

            /// <summary>
            /// 是否多门店订单
            /// </summary>
            [JsonProperty("is_multi_store")]
            public bool IsMultiStore { get; set; }

            /// <summary>
            /// 是否结算
            /// </summary>
            [JsonProperty("is_settle")]
            public bool IsSettle { get; set; }

            /// <summary>
            /// 是否支付
            /// </summary>
            [JsonProperty("is_payed")]
            public bool IsPayed { get; set; }

            /// <summary>
            /// 是否担保交易
            /// </summary>
            [JsonProperty("is_secured_transactions")]
            public bool IsSecuredTransactions { get; set; }

            /// <summary>
            /// 是否享受免邮
            /// </summary>
            [JsonProperty("is_postage_free")]
            public bool IsPostageFree { get; set; }

            /// <summary>
            /// 是否有维权
            /// </summary>
            [JsonProperty("is_feedback")]
            public bool IsFeedback { get; set; }

            /// <summary>
            /// 是否有退款
            /// </summary>
            [JsonProperty("is_refund")]
            public bool IsRefund { get; set; }

            /// <summary>
            /// 是否定金预售
            /// </summary>
            [JsonProperty("is_down_payment_pre")]
            public bool IsDownPaymentPre { get; set; }

        }

        public class StructurizationTradeAddressInfoDetail {

            /// <summary>
            /// 收货人姓名
            /// </summary>
            [JsonProperty("receiver_name")]
            public string ReceiverName { get; set; }

            /// <summary>
            /// 收货人手机号
            /// </summary>
            [JsonProperty("receiver_tel")]
            public string ReceiverTel { get; set; }

            /// <summary>
            /// 省
            /// </summary>
            [JsonProperty("delivery_province")]
            public string DeliveryProvince { get; set; }

            /// <summary>
            /// 市
            /// </summary>
            [JsonProperty("delivery_city")]
            public string DeliveryCity { get; set; }

            /// <summary>
            /// 区
            /// </summary>
            [JsonProperty("delivery_district")]
            public string DeliveryDistrict { get; set; }

            /// <summary>
            /// 详细地址
            /// </summary>
            [JsonProperty("delivery_address")]
            public string DeliveryAddress { get; set; }

            /// <summary>
            /// 字段为json格式，需要开发者自行解析
            /// lng、lon（经纬度）；
            /// checkOutTime（酒店退房时间）；
            /// recipients（入住人）；
            /// checkInTime（酒店入住时间）；
            /// idCardNumber（海淘身份证信息）；
            /// areaCode（邮政编码）
            /// </summary>
            [JsonProperty("address_extra")]
            public string AddressExtra { get; set; }

            /// <summary>
            /// 邮政编码
            /// </summary>
            [JsonProperty("delivery_postal_code")]
            public string DeliveryPostalCode { get; set; }

            /// <summary>
            /// 到店自提信息json格式
            /// </summary>
            [JsonProperty("self_fetch_info")]
            public string SelfFetchInfo { get; set; }

            /// <summary>
            /// 同城送预计送达时间-开始时间
            /// 非同城送以及没有开启定时达的订单不返回
            /// </summary>
            [JsonProperty("delivery_start_time")]
            public DateTime DeliveryStartTime { get; set; }

            /// <summary>
            /// 同城送预计送达时间-结束时间
            /// 非同城送以及没有开启定时达的订单不返回
            /// </summary>
            [JsonProperty("delivery_end_time")]
            public DateTime DeliveryEndTime { get; set; }

        }

        public class StructurizationOrderInfoDetail {

            /// <summary>
            /// 主订单状态WAIT_BUYER_PAY（等待买家付款，定金预售描述：定金待付、等待尾款支付开始、尾款待付）；TRADE_PAID（订单已支付）；WAIT_CONFIRM（待确认，包含待成团、待接单等等。即：买家已付款，等待成团或等待接单）；WAIT_SELLER_SEND_GOODS（等待卖家发货，即：买家已付款）；WAIT_BUYER_CONFIRM_GOODS(等待买家确认收货，即：卖家已发货)；TRADE_SUCCESS（买家已签收以及订单成功）；TRADE_CLOSED（交易关闭）；PS：TRADE_PAID状态仅代表当前订单已支付成功，表示瞬时状态，稍后会自动修改成后面的状态。如果不关心此状态请再次请求详情接口获取下一个状态。
            /// </summary>
            [JsonProperty("status")]
            public string Status { get; set; }

            /// <summary>
            /// 主订单类型
            /// 0:普通订单;1:送礼订单;2:代付;3:分销采购单;4:赠品;5:心愿单;6:二维码订单;7:合并付货款;8:1分钱实名认证;9:品鉴;10:拼团;15:返利;35:酒店;40:外卖;41:堂食点餐;46:外卖买单;51:全员开店;61:线下收银台订单;71:美业预约单;72:美业服务单;75:知识付费;81:礼品卡;100:批发
            /// </summary>
            [JsonProperty("type")]
            public long Type { get; set; }

            /// <summary>
            /// 订单号
            /// </summary>
            [JsonProperty("tid")]
            public string Tid { get; set; }

            /// <summary>
            /// 主订单状态描述
            /// </summary>
            [JsonProperty("status_str")]
            public string StatusStr { get; set; }

            /// <summary>
            /// 支付类型
            /// 0:默认值,未支付;1:微信自有支付;2:支付宝wap;3:支付宝wap;5:财付通;7:代付;8:联动优势;9:货到付款;10:大账号代销;11:受理模式;12:百付宝;13:sdk支付;14:合并付货款;15:赠品;16:优惠兑换;17:自动付货款;18:爱学贷;19:微信wap;20:微信红包支付;21:返利;22:ump红包;24:易宝支付;25:储值卡;27:qq支付;28:有赞E卡支付;29:微信条码;30:支付宝条码;33:礼品卡支付;35:会员余额;72:微信扫码二维码支付;100:代收账户;300:储值账户;400:保证金账户;101:收款码;102:微信;103:支付宝;104:刷卡;105:二维码台卡;106:储值卡;107:有赞E卡;110:标记收款-自有微信支付;111:标记收款-自有支付宝;112:标记收款-自有POS刷卡;113:通联刷卡支付;200:记账账户;201:现金
            /// </summary>
            [JsonProperty("pay_type")]
            public long PayType { get; set; }

            /// <summary>
            /// 店铺类型
            /// 0:微商城;1:微小店;2:爱学贷微商城;3:批发店铺;4:批发商城;5:外卖;6:美业;7:超级门店;8:收银;9:收银加微商城;10:零售总部;99:有赞开放平台平台型应用创建的店铺
            /// </summary>
            [JsonProperty("team_type")]
            public long TeamType { get; set; }

            /// <summary>
            /// 关闭类型
            /// 0:未关闭;1:过期关闭;2:标记退款;3:订单取消;4:买家取消;5:卖家取消;6:部分退款;10:无法联系上买家;11:买家误拍或重拍了;12:买家无诚意完成交易;13:已通过银行线下汇款;14:已通过同城见面交易;15:已通过货到付款交易;16:已通过网上银行直接汇款;17:已经缺货无法交易
            /// </summary>
            [JsonProperty("close_type")]
            public long CloseType { get; set; }

            /// <summary>
            /// 物流类型
            /// 0:快递发货;1:到店自提;2:同城配送;9:无需发货（虚拟商品订单）
            /// </summary>
            [JsonProperty("express_type")]
            public long ExpressType { get; set; }

            /// <summary>
            /// 订单信息打标
            /// </summary>
            [JsonProperty("order_tags")]
            public StructurizationOrderInfoDetailTags OrderTags { get; set; }

            /// <summary>
            /// 订单扩展字段
            /// </summary>
            [JsonProperty("order_extra")]
            public StructurizationOrderInfoDetailExtra OrderExtra { get; set; }

            /// <summary>
            /// 订单创建时间
            /// </summary>
            [JsonProperty("created")]
            public DateTime Created { get; set; }

            /// <summary>
            /// 订单更新时间
            /// </summary>
            [JsonProperty("update_time")]
            public DateTime UpdateTime { get; set; }

            /// <summary>
            /// 订单过期时间（未付款将自动关单）
            /// </summary>
            [JsonProperty("expired_time")]
            public DateTime ExpiredTime { get; set; }

            /// <summary>
            /// 订单支付时间
            /// </summary>
            [JsonProperty("pay_time")]
            public DateTime PayTime { get; set; }

            /// <summary>
            /// 订单发货时间（当所有商品发货后才会更新）
            /// </summary>
            [JsonProperty("consign_time")]
            public DateTime ConsignTime { get; set; }

            /// <summary>
            /// 订单确认时间（多人拼团成团）
            /// </summary>
            [JsonProperty("confirm_time")]
            public DateTime ConfirmTime { get; set; }

            /// <summary>
            /// 退款状态
            /// 0:未退款;1:部分退款中;2:部分退款成功;11:全额退款中;12:全额退款成功
            /// </summary>
            [JsonProperty("refund_state")]
            public long RefundState { get; set; }

            /// <summary>
            /// 是否零售订单
            /// </summary>
            [JsonProperty("is_retail_order")]
            public bool IsRetailOrder { get; set; }

            /// <summary>
            /// 订单成功时间
            /// </summary>
            [JsonProperty("success_time")]
            public DateTime SuccessTime { get; set; }

            /// <summary>
            /// 网点id
            /// </summary>
            [JsonProperty("offline_id")]
            public long OfflineId { get; set; }

            /// <summary>
            /// 支付类型。取值范围：WEIXIN(微信自有支付)WEIXIN_DAIXIAO(微信代销支付)ALIPAY(支付宝支付)BANKCARDPAY(银行卡支付)PEERPAY(代付)CODPAY(货到付款)BAIDUPAY(百度钱包支付)PRESENTTAKE(直接领取赠品)COUPONPAY(优惠券/码全额抵扣)BULKPURCHASE(来自分销商的采购)MERGEDPAY(合并付货款)ECARD(有赞E卡支付)PURCHASE_PAY(采购单支付)MARKPAY(标记收款)OFCASH(现金支付)PREPAIDCARD(储值卡余额支付)
            /// </summary>
            [JsonProperty("pay_type_str")]
            public string PayTypeStr { get; set; }

        }
    }
}
