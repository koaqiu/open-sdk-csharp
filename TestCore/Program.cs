using System;
using System.Collections.Generic;
using YZOpenSDK;

namespace TestCore {
    class Program {
        static void Main(string[] args) {
            
            var auth = new Token("7940650b133c322f8e84919f3938e4b7");
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
    }
}
