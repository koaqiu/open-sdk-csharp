using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YZOpenSDK.Entrys;

namespace YZOpenSDK.xBei.Youzan {
    public abstract class AbstractApi<T> : IApi<T> {
        private const int UPLOAD_FILE_MAX_SIZE = 1024 * 1024;
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
            return _toUploadFiles == null || _toUploadFiles.Count() < 0
                ? new List<KeyValuePair<string, UploadFile>>()
                : _toUploadFiles.Select(file => new KeyValuePair<string, UploadFile>("image[]", file)).ToList();
        }
        /// <summary>
        /// 执行Api请求
        /// </summary>
        /// <returns></returns>
        public ApiResult<T> Execute() {
            var yzClient = new DefaultYZClient(_auth);
            var resultStr = yzClient.Invoke(ApiName, Version, Method, getParams(), getFiles());
            var result = ApiResult<T>.ParseJson(resultStr);
            return result;
        }
    }
}
