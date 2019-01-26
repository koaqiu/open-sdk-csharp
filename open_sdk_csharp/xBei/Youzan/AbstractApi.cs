using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;

namespace YZOpenSDK.xBei.Youzan {
    /// <summary>
    /// API基类
    /// </summary>
    /// <typeparam name="TResult">返回数据类型</typeparam>
    public abstract class AbstractApi<TResult> : IApi<TResult> {
        private const int UPLOAD_FILE_MAX_SIZE = 1024 * 1024;
        private const int MaxTryTime = 3;
        /// <summary>
        /// API方法
        /// </summary>
        public virtual string ApiName => "youzan.AbstractApi.get";
        /// <summary>
        /// APi版本：默认填写了3.0.0
        /// </summary>
        public virtual string Version => "3.0.0";
        /// <summary>
        /// HTTP METHOD 默认：GET
        /// </summary>
        public virtual string Method => ApiRequestMethod.GET;

        private readonly ApiParams _args;
        private readonly Auth _auth;
        private readonly IList<UploadFile> _toUploadFiles;

        protected AbstractApi(Auth auth, ApiParams args = null, IEnumerable<UploadFile> toUploadFiles = null) {
            _auth = auth;
            _args = args;
            _toUploadFiles = toUploadFiles?.ToList();
            checkUploadFile(_toUploadFiles);
        }

        static void checkUploadFile(IList<UploadFile> toUploadFiles) {
            if (toUploadFiles == null || toUploadFiles.Count() < 0) return;
            foreach (var file in toUploadFiles) {
                if (file.Content.Length > UPLOAD_FILE_MAX_SIZE) {
                    throw new Exception("上传的文件大小不能超过1Mb");
                }
            }
        }
        private IDictionary<string, object> getParams() {
            return _args == null
                ? new ConcurrentDictionary<string, object>()
                : _args.GetParams();
        }
        private List<KeyValuePair<string, UploadFile>> getFiles() {
            if (_toUploadFiles == null || _toUploadFiles.Count() < 0) return null;
            return _toUploadFiles.Select(file => new KeyValuePair<string, UploadFile>("image[]", file)).ToList();
        }
        /// <summary>
        /// 执行Api请求
        /// </summary>
        /// <returns></returns>
        public ApiResult<TResult> Execute() {
            return ExecuteAsync().Result;
        }

        public async Task<ApiResult<TResult>> ExecuteAsync() {
            var yzClient = new DefaultYZClient(_auth);
            var tryTime = 0;
            while (tryTime < MaxTryTime) {
                string resultStr;
                try {
                    resultStr = await yzClient.InvokeAsync(ApiName, Version, Method, getParams(), getFiles());
                } catch (Exception e) {
                    return getError(e);
                }
                var result = ApiResult<TResult>.ParseJson(resultStr);
                if (!result.HasError()) return result;
                switch (result.ErrorResponse.Code) {
                    case 40005: //签名校验失败	检查AppId和AppSecret是否正确；如果是自行开发的协议封装，请检查代码
                        return result;
                    case 10000:
                    case 10001:
                    case 40009:
                    case 40010:
                        // 尝试刷新TOKEN
                        var now = DateTime.Now;
                        Console.WriteLine($"{ApiName} begin request token as {now}");
                        // ReSharper disable once PossibleNullReferenceException
                        (_auth as Token).RequestToken();
                        var dt = DateTime.Now - now;
                        Console.WriteLine($"{ApiName} got token.  {dt}");
                        tryTime++;
                        continue;
                    default:
                        return result;
                }
            }
            return getError(90000, "多次尝试获取Token失败");
        }
        private static ApiResult<TResult> getError(int code, string exception) {
            return new ApiResult<TResult> {
                ErrorResponse = new ErrorResponseModel {
                    Msg = exception,
                    Code = code
                }
            };
        }
        private static ApiResult<TResult> getError(Exception exception) {
            return new ApiResult<TResult> {
                ErrorResponse = new ErrorResponseModel {
                    Msg = exception.Message,
                    Code = exception.HResult
                }
            };
        }
    }
}
