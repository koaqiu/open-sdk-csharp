using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Services {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CallbackController : ControllerBase {
        private readonly YouzanConfig _config;
        public CallbackController(IOptions<YouzanConfig> config) {
            _config = config.Value;
        }
        /// <summary>
        /// 认证回调
        /// </summary>
        /// <returns></returns>
        [HttpPost("authorize")]
        public async Task<ActionResult> Authorize() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 接收推送信息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [HttpPost("msg")]
        public async Task<ActionResult> PushMsg([FromBody] MsgPushEntity msg) {
            await Task.Run(() => {
                try {
                    handlerAsync(msg);
                } catch {
                    // do nothing
                }
            });
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
