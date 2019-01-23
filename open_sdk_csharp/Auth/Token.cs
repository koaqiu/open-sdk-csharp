using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;

namespace YZOpenSDK {
    public class Token : Auth {
        private readonly YouzanConfig _config;
        private AccessToken _token;
        private readonly ICache _cache;

        public Token(YouzanConfig config, ICache cache = null) {
            _config = config;
            _cache = cache;
        }

        public string GetToken() {
            if (!isTokenValid(_token)) {
                _token = getAsync().Result;
            }
            return _token.Token;
        }

        private AccessToken getFromCache() => _cache?.GetToken();

        private static bool isTokenValid(AccessToken token) => token != null && !string.IsNullOrWhiteSpace(token.Token) && token.CreateTime.AddSeconds(token.ExpiresIn - 30) > DateTime.Now;

        private async Task<AccessToken> getAsync() {
            _token = getFromCache();
            if (isTokenValid(_token)) {
                return _token;
            }

            const string url = "https://open.youzan.com/oauth/token";
            using (var httpClient = new HttpClient()) {
                var myForm = new MultipartFormDataContent
                {
                    { new StringContent(_config.AppId, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_id" },
                    { new StringContent(_config.AppSecret, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_secret" },
                    { new StringContent("silent", Encoding.UTF8, "application/x-www-form-urlencoded"), "grant_type" },
                    { new StringContent(_config.KdtId, Encoding.UTF8, "application/x-www-form-urlencoded"), "kdt_id" }
                };

                var response = await httpClient.PostAsync(url, myForm);
                if (response.IsSuccessStatusCode) {
                    var str = await response.Content.ReadAsStringAsync();
                    _token = BaseEntry.FromJson<AccessToken>(str);
                    _token.CreateTime = DateTime.Now;
                    _cache?.SaveToken(_token);
                }
            }
            return _token;
        }
    }
}
