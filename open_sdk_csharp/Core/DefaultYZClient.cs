using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Helper;

namespace YZOpenSDK {
    public class DefaultYZClient : YZClient {
        private Auth auth;

        public DefaultYZClient(Auth auth) {
            this.auth = auth;
        }

        public string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams,
            IEnumerable<KeyValuePair<string, string>> files) {
            var list = files?.ToList();
            return Invoke(apiName, version, method, apiParams,
                list?.Count() < 1
                    ? new List<KeyValuePair<string, UploadFile>>()
                    : list?.Select(file => new KeyValuePair<string, UploadFile>(file.Key, new UploadFile { FileName = file.Value, Content = new FileStream(file.Value, FileMode.Open) }))
                );
        }
        public string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams,
            IEnumerable<KeyValuePair<string, FileInfo>> files) {
            var list = files?.ToList();
            return Invoke(apiName, version, method, apiParams,
                list?.Count() < 1
                    ? new List<KeyValuePair<string, UploadFile>>()
                    : list?.Select(file => new KeyValuePair<string, UploadFile>(file.Key, new UploadFile { FileName = file.Value.FullName, Content = file.Value.OpenRead() }))
            );
        }
        public string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams, IEnumerable<KeyValuePair<string, UploadFile>> files) {
            return InvokeAsync(apiName, version, method, apiParams, files).Result;
        }

        public async Task<string> InvokeAsync(string apiName, string version, string method, IDictionary<string, object> apiParams, IEnumerable<KeyValuePair<string, UploadFile>> files) {
            if (string.IsNullOrWhiteSpace(apiName)) {
                throw new YZException("apiName CAN NOT be null!");
            }

            var allParams = apiParams.Select(item =>
                new KeyValuePair<string, string>(item.Key, item.Value is DateTime ? $"{item.Value:yyyy-MM-dd HH:mm:ss}" : item.Value.ToString())
            ).ToDictionary(item => item.Key, item => item.Value);

            var apiNamePart = apiName.Split('.');
            var action = apiNamePart.Last();
            var service = string.Join('.', apiNamePart, 0, apiNamePart.Length - 1);

            var url = "https://open.youzan.com/api";

            switch (auth) {
                case Sign _:
                    url += "/entry";
                    allParams = GetSign(allParams);
                    break;
                case Token myAuth:
                    url += "/oauthentry";
                    var token = myAuth.GetToken();
                    if (string.IsNullOrWhiteSpace(token)) {
                        return "{\"error_response\":{\"code\":40009,\"msg\":\"参数 token 无效\",\"sub_code\":0,\"sub_data\":null,\"sub_msg\":null}}";
                    }
                    allParams.Add("access_token", token);
                    break;
                default:
                    throw new YZException("Auth type not supported");
            }
            url += "/" + service + "/" + version + "/" + action;

            return await SendRequestAsync(url, method, allParams, files?.ToList());
        }
        private async Task<string> SendRequestAsync(string url, string method, IDictionary<string, string> apiParams, IList<KeyValuePair<string, UploadFile>> files) {
            var httpClient = HttpClientService.GetClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "X-YZ-Client 2.0.0 - CSharp");
            var builder = new UriBuilder(url);
            if (method.ToUpper().Equals("GET")) {
                var query = new StringBuilder();
                foreach (var item in apiParams) {
                    query.AppendFormat("{0}={1}&", item.Key, item.Value);
                }
                builder.Query = query.ToString();
                var reqUrl = builder.ToString();
                var getResult = await httpClient.GetAsync(reqUrl);
                //Console.WriteLine(reqUrl);
                if (getResult.IsSuccessStatusCode) {
                    return await getResult.Content.ReadAsStringAsync();
                }
                throw new YZException("Internal server error, code: " + getResult.StatusCode);
            }

            if (!method.ToUpper().Equals("POST"))
                throw new YZException("ApiName not supported");
            HttpContent form = null;
            if (files?.Count() > 0) {
                var myForm = new MultipartFormDataContent();
                foreach (var item in apiParams) {
                    myForm.Add(new StringContent(item.Value, Encoding.UTF8, "application/x-www-form-urlencoded"), item.Key);
                }
                foreach (var file in files) {
                    var content = new StreamContent(file.Value.Content);
                    var fileName = file.Value.FileName;
                    var idx = fileName.LastIndexOf("/", StringComparison.Ordinal) + 1;
                    myForm.Add(content, file.Key, fileName.Substring(idx, fileName.Length - idx));
                }
                form = myForm;
            } else {
                form = new FormUrlEncodedContent(apiParams);
            }

            var postResult = await httpClient.PostAsync(url, form);
            if (postResult.IsSuccessStatusCode) {
                return await postResult.Content.ReadAsStringAsync();
            }
            throw new YZException("Internal server error, code: " + postResult.StatusCode);
        }
        private Dictionary<string, string> GetSign(IDictionary<string, string> apiParams) {
            var myAuth = auth as Sign;
            var paramMap = new Dictionary<string, string>();
            var timestamp = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            paramMap.Add("timestamp", timestamp);
            paramMap.Add("format", "json");
            paramMap.Add("app_id", myAuth.getAppId());
            paramMap.Add("v", "1.0");
            paramMap.Add("sign_method", "md5");
            foreach (var item in apiParams) {
                paramMap.Add(item.Key, item.Value);
            }
            var sb = new StringBuilder();
            sb.Append(myAuth.getAppSecret());
            foreach (var item in paramMap) {
                sb.Append(item.Key + item.Value);
            }
            sb.Append(myAuth.getAppSecret());
            var sign = MD5Util.Hash(sb.ToString());
            //Console.WriteLine(sb.ToString());
            paramMap.Add("sign", sign);

            return paramMap;
        }
    }
}
