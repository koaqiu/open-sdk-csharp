using Newtonsoft.Json;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Security;

namespace YZOpenSDK.xBei.Youzan.Entrys {
	public class MsgPushEntity {
		[JsonProperty("msg")]
		public string Msg { get; set; }

		[JsonProperty("sendCount")]
		public int SendCount { get; set; }

		/// <summary>
		/// 默认0 : appid  1 :client
		/// </summary>
		[JsonProperty("mode")]
		public int Mode { get; set; }

		[JsonProperty("app_id")]
		public string AppId { get; set; }

		[JsonProperty("client_id")]
		public string Client_id { get; set; }

		[JsonProperty("version")]
		public long Version { get; set; }

		/// <summary>
		/// 消息业务类型：
		/// TRADE_ORDER_STATE-订单状态事件，
		/// TRADE_ORDER_REFUND-退款事件，
		/// TRADE_ORDER_EXPRESS-物流事件，
		/// ITEM_STATE-商品状态事件，
		/// ITEM_INFO-商品基础信息事件，
		/// POINTS-积分，
		/// SCRM_CARD-会员卡（商家侧），
		/// SCRM_CUSTOMER_CARD-会员卡（用户侧），
		/// TRADE-交易V1，
		/// ITEM-商品V1
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("sign")]
		public string Sign { get; set; }

		[JsonProperty("kdt_id")]
		public int KdtId { get; set; }

		[JsonProperty("test")]
		public bool Test { get; set; } = false;

		/// <summary>
		/// 消息状态，对应消息业务类型。
		/// 如TRADE_ORDER_STATE-订单状态事件，对应有等待买家付款（WAIT_BUYER_PAY）、等待卖家发货（WAIT_SELLER_SEND_GOODS）等多种状态，
		/// 详细可参考 消息结构里的描述
		/// </summary>
		[JsonProperty("status")]
		public string Status { get; set; }

		[JsonProperty("kdt_name")]
		public string KdtName { get; set; }

		[JsonProperty("msg_id")]
		public string MsgId { get; set; }

		public bool CheckSign(YouzanConfig config) =>
			EncryptUtils.MD5Encrypt($"{config.AppId}{Msg}{config.AppSecret}") == Sign;
	}
}
