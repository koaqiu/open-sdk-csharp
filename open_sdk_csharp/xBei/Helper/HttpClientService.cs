using System;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace YZOpenSDK.xBei.Helper {
    public static class HttpClientService {
        private static IHttpClientFactory _clientFactory;
        public static void Init() {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient();
            var services = serviceCollection.BuildServiceProvider();
            _clientFactory = services.GetService<IHttpClientFactory>();
        }
        public static void ConfigureClientFactory(this IServiceCollection services) {
            services.AddHttpClient();
        }
        public static HttpClient GetClient() {
            if (_clientFactory == null)
                throw new Exception("请在主进程调用：HttpClientService.Init();");
            return _clientFactory.CreateClient();
        }
    }
}
