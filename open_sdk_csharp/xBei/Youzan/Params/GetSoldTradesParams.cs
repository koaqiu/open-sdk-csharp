using Newtonsoft.Json;
using System;

namespace YZOpenSDK.xBei.Youzan.Params {
    /// <summary>
    /// 订单搜索
    /// </summary>
    public class GetSoldTradesParams : ApiParams {
        /// <summary>
        /// 买家id
        /// </summary>
        [JsonProperty("buyer_id")]
        public long? BuyerId { get; set; }

        /// <summary>
        /// 交易创建结束时间，例:2017-01-0112:00:00;开始时间和结束时间的跨度不能大于3个月;结束时间必须大于开始时间;开始时间和结束时间必须成对出现
        /// </summary>
        [JsonProperty("end_created")]
        public DateTime? EndCreated { get; set; }

        /// <summary>
        /// 交易状态更新的结束时间，例:2017-01-0112:00:00;开始时间和结束时间的跨度不能大于3个月;结束时间必须大于开始时间;开始时间和结束时间必须成对出现
        /// </summary>
        [JsonProperty("end_update")]
        public DateTime? EndUpdate { get; set; }

        /// <summary>
        /// 物流类型搜索
        /// 同城送订单：LOCAL_DELIVERY
        /// 自提订单：SELF_FETCH
        /// 快递配送：EXPRESS
        /// </summary>
        [JsonProperty("express_type")]
        public string ExpressType { get; set; }

        /// <summary>
        /// 粉丝id
        /// </summary>
        [JsonProperty("fans_id")]
        public long? FansId { get; set; }

        /// <summary>
        /// 粉丝类型
        /// </summary>
        [JsonProperty("fans_type")]
        public long? FansType { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        [JsonProperty("goods_title")]
        public string GoodsTitle { get; set; }

        /// <summary>
        /// 商品id
        /// </summary>
        [JsonProperty("item_id")]
        public long? ItemId { get; set; }

        /// <summary>
        /// 搜索关键词，可使用以下信息进行搜索
        /// 1.订单号
        /// 2.收货人手机号
        /// 3.收货人昵称
        /// 4.团编号
        /// </summary>
        [JsonProperty("keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// 是否需要返回订单详情url
        /// </summary>
        [JsonProperty("need_order_url")]
        public bool? NeedOrderUrl { get; set; }

        /// <summary>
        /// 门店id
        /// </summary>
        [JsonProperty("offline_id")]
        public long? OfflineId { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [JsonProperty("order_source")]
        public string OrderSource { get; set; }

        /// <summary>
        /// 页码，从1开始，最大不能超过100
        /// </summary>
        [JsonProperty("page_no")]
        public long? PageNo { get; set; }

        /// <summary>
        /// 每页条数，最大不能超过100，建议使用默认分页20
        /// </summary>
        [JsonProperty("page_size")]
        public long? PageSize { get; set; }

        /// <summary>
        /// 收货人昵称
        /// </summary>
        [JsonProperty("receiver_name")]
        public string ReceiverName { get; set; }

        /// <summary>
        /// 收货人手机号
        /// </summary>
        [JsonProperty("receiver_phone")]
        public string ReceiverPhone { get; set; }

        /// <summary>
        /// 交易创建的开始时间例:2017-01-0112:00:00;开始时间和结束时间的跨度不能大于3个月;结束时间必须大于开始时间;开始时间和结束时间必须成对出现	
        /// </summary>
        [JsonProperty("start_created")]
        public DateTime? StartCreated { get; set; }

        /// <summary>
        /// 交易状态更新的开始时间例:2017-01-0112:00:00;开始时间和结束时间的跨度不能大于3个月;结束时间必须大于开始时间;开始时间和结束时间必须成对出现
        /// </summary>
        [JsonProperty("start_update")]
        public DateTime? StartUpdate { get; set; }

        /// <summary>
        /// 订单状态，一次只能查询一种状态
        /// 待付款：WAIT_BUYER_PAY
        /// 待发货：WAIT_SELLER_SEND_GOODS
        /// 等待买家确认：WAIT_BUYER_CONFIRM_GOODS
        /// 订单完成：TRADE_SUCCESS
        /// 订单关闭：TRADE_CLOSE
        /// 退款中：TRADE_REFUND
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [JsonProperty("tid")]
        public string Tid { get; set; }

        /// <summary>
        /// 订单类型
        /// NORMAL：普通订单
        /// PEERPAY：代付
        /// GIFT：我要送人
        /// FX_CAIGOUDAN：分销采购单
        /// PRESENT：赠品
        /// WISH：心愿单
        /// QRCODE：二维码订单
        /// QRCODE_3RD：线下收银台订单
        /// FX_MERGED：合并付货款
        /// VERIFIED：1分钱实名认证
        /// PINJIAN：品鉴
        /// REBATE：返利
        /// FX_QUANYUANDIAN：全员开店
        /// FX_DEPOSIT：保证金
        /// PF：批发
        /// GROUP：拼团
        /// HOTEL：酒店
        /// TAKE_AWAY：外卖
        /// CATERING_OFFLINE：堂食点餐
        /// CATERING_QRCODE：外卖买单
        /// BEAUTY_APPOINTMENT：美业预约单
        /// BEAUTY_SERVICE：美业服务单
        /// KNOWLEDGE_PAY：知识付费
        /// GIFT_CARD：礼品卡
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

    }
}
