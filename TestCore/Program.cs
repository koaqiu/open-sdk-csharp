using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using YZOpenSDK;
using YZOpenSDK.Entrys;
using YZOpenSDK.Util;

namespace TestCore {
    class Program {
        static void Main(string[] args) {
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

            //var result = yzClient.Invoke("youzan.item.create", "3.0.0", "post", dict, files);
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
