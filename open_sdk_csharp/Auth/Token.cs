using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Helper;

namespace YZOpenSDK {
    public class Token : Auth {
        private const int RefreshTokenExpiresTime = 3600 * 24 * 28 - 30;
        private readonly YouzanConfig _config;
        private AccessToken _token;
        private readonly ICache _cache;
        private static Task<AccessToken> _getTokenTask;
        private static object lockObj = new object();
        public Token(YouzanConfig config, ICache cache = null) {
            _config = config;
            _cache = cache;
        }

        public string GetToken() {
            if (_token == null) {
                // Console.WriteLine("get token From Cache");
                _token = getFromCache();
            }

            if (!isTokenValid(_token)) {

                return string.Empty;
            }
            return _token.Token;
        }

        private AccessToken getFromCache() => _cache?.GetToken();

        private static bool isTokenValid(AccessToken token) => token != null && !string.IsNullOrWhiteSpace(token.Token) && token.CreateTime.AddSeconds(token.ExpiresIn - 30) > DateTime.Now;
        private static bool isRefreshTokenValid(AccessToken token) => token != null && !string.IsNullOrWhiteSpace(token.RefreshToken) && token.CreateTime.AddSeconds(RefreshTokenExpiresTime) > DateTime.Now;
        public AccessToken RequestToken() {
            lock (lockObj) {
                if (_getTokenTask == null) {
                    //_getTokenTask = getTokenAsync();
                    _getTokenTask = new Task<AccessToken>( () => getTokenAsync().Result);
                    _getTokenTask.Start();
                }
            }
            return _getTokenTask.Result;
        }
        async Task<AccessToken> getTokenAsync() {
            if (_config.IsISV) {
                // ISV版本
                if (isRefreshTokenValid(_token)) {
                    return await refreshToken(_token.RefreshToken);
                }
                throw new Exception("Token无效，请重新认证！");
            }
            const string url = "https://open.youzan.com/oauth/token";
            var httpClient = HttpClientService.GetClient();
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
            return _token;
        }
        private string getAuthorizeUrl(string state) {
            //TODO: 小心这里的Uri.EscapeUriString，如果发现认证失败，尝试取消转码后再认证。
            return $"https://open.youzan.com/oauth/authorize?client_id={_config.AppId}&response_type=code&state={Uri.EscapeUriString(state)}&redirect_uri={Uri.EscapeUriString(_config.CallBackAddress)}";
        }
        public static async Task<AccessToken> GetToken(string code, YouzanConfig config, ICache cache = null, string scope = "") {
            const string url = "https://open.youzan.com/oauth/token";
            var httpClient = HttpClientService.GetClient();
            var myForm = new MultipartFormDataContent
                {
                    { new StringContent(config.AppId, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_id" },
                    { new StringContent(config.AppSecret, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_secret" },
                    { new StringContent("authorization_code", Encoding.UTF8, "application/x-www-form-urlencoded"), "grant_type" },
                    { new StringContent(code, Encoding.UTF8, "application/x-www-form-urlencoded"), "code" },
                    { new StringContent(config.CallBackAddress, Encoding.UTF8, "application/x-www-form-urlencoded"),"redirect_uri"}
                };
            if (!string.IsNullOrWhiteSpace(scope)) {
                myForm.Add(new StringContent(scope, Encoding.UTF8, "application/x-www-form-urlencoded"), "scope");
            }
            var response = await httpClient.PostAsync(url, myForm);
            if (response.IsSuccessStatusCode) {
                var str = await response.Content.ReadAsStringAsync();
                var error = BaseEntry.FromJson<ErrorEntry>(str);
                var token = BaseEntry.FromJson<AccessToken>(str);
                token.CreateTime = DateTime.Now;
                cache?.SaveToken(token);
                return token;
            }

            return null;
        }
        private async Task<AccessToken> refreshToken(string refreshToken, string scope = "") {
            const string url = "https://open.youzan.com/oauth/token";
            var httpClient = HttpClientService.GetClient();
            var myForm = new MultipartFormDataContent
            {
                    { new StringContent(_config.AppId, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_id" },
                    { new StringContent(_config.AppSecret, Encoding.UTF8, "application/x-www-form-urlencoded"), "client_secret" },
                    { new StringContent("refresh_token", Encoding.UTF8, "application/x-www-form-urlencoded"), "grant_type" },
                    { new StringContent(refreshToken, Encoding.UTF8, "application/x-www-form-urlencoded"), "refresh_token" }
                };
            if (!string.IsNullOrWhiteSpace(scope)) {
                myForm.Add(new StringContent(scope, Encoding.UTF8, "application/x-www-form-urlencoded"), "scope");
            }
            var response = await httpClient.PostAsync(url, myForm);
            if (response.IsSuccessStatusCode) {
                var str = await response.Content.ReadAsStringAsync();
                var token = BaseEntry.FromJson<AccessToken>(str);
                token.CreateTime = DateTime.Now;
                _cache?.SaveToken(token);
                return token;
            }
            return null;
        }
    }
}
