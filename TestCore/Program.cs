using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using YZOpenSDK;
using YZOpenSDK.Entrys;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Youzan;
using YZOpenSDK.xBei.Youzan.Params;

namespace TestCore {
    class Program {
        //const toLowerLine = str =>str.replace(/[A-Z]/g, match=>"_"+match.toLowerCase());
        static string toLowerLine(string str) => Regex.Replace(str, "[A-Z]", match => $"{(match.Index > 0 ? "_" : "")}{match.Value.ToLower()}", RegexOptions.Compiled);

        static void Main(string[] args) {
            var config = getConfig();
            var auth = new Token(config, new FileCache());
            var param = new GetOnSaleItemsParams {
                PageSize = 10,
                Q = "二",
                OrderBy = "aaa"
            };
            var api = new GetOnSaleItemsApi(auth, param);
            var result = api.Execute();
            Console.WriteLine(result);
        }
        static void test() {
            var config = getConfig();
            var auth = new Token(config, new FileCache());

            YZClient yzClient = new DefaultYZClient(auth);
            var dict = new Dictionary<string, object>
            {
                {"title", "aaaaa"}, {"price", 1.0}, {"post_fee", 1.0}
            };

            var files = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("images[]", "/xx/xx/1.jpg")
            };
            // https://open.youzan.com/api/oauthentry/youzan.item/3.0.0/create
            // var result = yzClient.Invoke("youzan.item.create", "3.0.0", "post", dict, files);
            // https://open.youzan.com/api/oauthentry/youzan.items.onsale/3.0.0/get
            var result = yzClient.Invoke("youzan.items.onsale.get", "3.0.0", "get", dict, null);
            Console.WriteLine(result);

        }

        static YouzanConfig getConfig() {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .Build();
            return conf.GetSection("youzan").Get<YouzanConfig>();
        }
    }

}
