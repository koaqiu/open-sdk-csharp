using System;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Text;

namespace YZOpenSDK {
    public class DefaultYZClient : YZClient {
        private Auth auth;

        public DefaultYZClient(Auth auth) {
            this.auth = auth;
        }

        public string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams, List<KeyValuePair<string, string>> files) {
            if (string.IsNullOrWhiteSpace(apiName)) {
                throw new YZException("apiName CAN NOT be null!");
            }
            IDictionary<string, string> allParams = new Dictionary<string, string>();
            foreach (var item in apiParams) {
                var val = item.Value.ToString();
                if (item.Value is DateTime) {
                    val = $"{item.Value:yyyy-MM-dd HH:mm:ss}";
                }
                allParams.Add(item.Key, val);
            }
            var idx = apiName.LastIndexOf(".", StringComparison.Ordinal);
            var service = apiName.Substring(0, idx);
            var action = apiName.Substring(idx + 1, apiName.Length - (idx + 1));

            var url = "https://open.youzan.com/api";

            switch (auth) {
                case Sign _:
                    url += "/entry";
                    allParams = GetSign(allParams);
                    break;
                case Token myAuth:
                    url += "/oauthentry";
                    allParams.Add("access_token", myAuth.GetToken());
                    break;
                default:
                    throw new YZException("Auth type not supported");
            }
            url += "/" + service + "/" + version + "/" + action;

            return SendRequest(url, method, allParams, files);
        }

        private string SendRequest(string url, string method, IDictionary<string, string> apiParams, IReadOnlyCollection<KeyValuePair<string, string>> files) {
            using (var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "X-YZ-Client 2.0.0 - CSharp");
                var builder = new UriBuilder(url);
                if (method.ToUpper().Equals("GET")) {
                    var query = new StringBuilder();
                    foreach (var item in apiParams) {
                        query.AppendFormat("{0}={1}&", item.Key, item.Value);
                    }
                    builder.Query = query.ToString();
                    var reqUrl = builder.ToString();
                    var getResult = httpClient.GetAsync(reqUrl).Result;
                    //Console.WriteLine(reqUrl);
                    if (getResult.IsSuccessStatusCode) {
                        return getResult.Content.ReadAsStringAsync().Result;
                    }
                    throw new YZException("Internal server error, code: " + getResult.StatusCode);
                }

                if (!method.ToUpper().Equals("POST"))
                    throw new YZException("Method not supported");

                HttpContent form = null;
                if (files != null) {
                    var myForm = new MultipartFormDataContent();
                    foreach (var item in apiParams) {
                        myForm.Add(new StringContent(item.Value, Encoding.UTF8, "application/x-www-form-urlencoded"), item.Key);
                    }
                    foreach (var file in files) {
                        var content = new StreamContent(new FileStream(file.Value, FileMode.Open));
                        var fileName = file.Value;
                        var idx = fileName.LastIndexOf("/", StringComparison.Ordinal) + 1;
                        myForm.Add(content, file.Key, fileName.Substring(idx, fileName.Length - idx));
                    }
                    form = myForm;
                } else {
                    form = new FormUrlEncodedContent(apiParams);
                }

                var postResult = httpClient.PostAsync(url, form).Result;
                if (postResult.IsSuccessStatusCode) {
                    return postResult.Content.ReadAsStringAsync().Result;
                }
                throw new YZException("Internal server error, code: " + postResult.StatusCode);

            }
        }

        private IDictionary<string, string> GetSign(IDictionary<string, string> apiParams) {
            var myAuth = auth as Sign;
            var paramMap = new SortedDictionary<string, string>();
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
