using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Security;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Services {
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CallbackController : ControllerBase {
		private readonly YouzanConfig _config;
		public CallbackController(IOptions<YouzanConfig> config) {
			_config = config.Value;
		}
		[HttpPost]
		public ActionResult Post([FromBody] MsgPushEntity msg) {
			handler(msg);
			return new JsonResult(new { code = 0, msg = "success" });
		}
		private void handler(MsgPushEntity msg) {
			Task.Run(() => handlerAsync(msg));
		}
		private void handlerAsync(MsgPushEntity msg) {
			if (msg.Test || msg.Mode != 1) return;
			if (!msg.CheckSign(_config)) return;

		}
	}
}
