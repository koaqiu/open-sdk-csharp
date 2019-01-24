using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using YZOpenSDK;
using YZOpenSDK.Entrys;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Youzan.Apis.Goods;
using YZOpenSDK.xBei.Youzan.Apis.Platform;
using YZOpenSDK.xBei.Youzan.Goods;
using YZOpenSDK.xBei.Youzan.Params;

namespace TestCore {
    class Program {

        static void Main(string[] args) {
            var config = getConfig();
            var auth = new Token(config, new FileCache());
            // testGetItemCategories(auth);
            // testUploadFile(auth);
            // testUploadFileSizeToLarge(auth);
            //testCreateGoodsItem(auth);
        }

        private static void testCreateGoodsItem(Auth auth) {
            //youzanItemCreateParams.setTitle("多规格部分成本价测试2019011802");
            //youzanItemCreateParams.setPrice(4700L);
            //youzanItemCreateParams.setDesc("多规格部分成本价测试2019011802");
            //youzanItemCreateParams.setSkuStocks("[{"price":1700,"quantity":23,"skus":[{"k":"甜度","kid":642703,"v":"3分","vid":606356},{"k":"净含量","kid":497,"v":"10g","vid":2569}]},{"price":3000,"quantity":54,"skus":[{"k":"甜度","kid":642703,"v":"3分","vid":606356},{"k":"净含量","kid":497,"v":"20g","vid":426}]},{"price":1700,"quantity":13,"skus":[{"k":"甜度","kid":642703,"v":"5分","vid":596657},{"k":"净含量","kid":497,"v":"10g","vid":2569}]},{"price":3000,"quantity":32,"skus":[{"k":"甜度","kid":642703,"v":"5分","vid":596657},{"k":"净含量","kid":497,"v":"20g","vid":426}]}]");
            //youzanItemCreateParams.setItemSkuExtends("[{"cost_price":800,"s1":606356,"s2":2569,"s3":0,"s4":0,"s5":0},{"cost_price":-1,"s1":606356,"s2":426,"s3":0,"s4":0,"s5":0},{"cost_price":800,"s1":596657,"s2":2569,"s3":0,"s4":0,"s5":0},{"cost_price":-1,"s1":596657,"s2":426,"s3":0,"s4":0,"s5":0}]");
            //youzanItemCreateParams.setImageIds("1288877899");
            var result = new CreateItem(auth, new CreateItemParams {
                Title = "多规格部分成本价测试2019012417",
                Cid = 3000000,
                Price = 4700,
                Desc = "多规格部分成本价测试2019012417 desc",
                SkuStocks = "[{\"price\":1700,\"quantity\":23,\"skus\":[{\"k\":\"甜度\",\"kid\":642703,\"v\":\"3分\",\"vid\":606356},{\"k\":\"净含量\",\"kid\":497,\"v\":\"10g\",\"vid\":2569}]},{\"price\":3000,\"quantity\":54,\"skus\":[{\"k\":\"甜度\",\"kid\":642703,\"v\":\"3分\",\"vid\":606356},{\"k\":\"净含量\",\"kid\":497,\"v\":\"20g\",\"vid\":426}]},{\"price\":1700,\"quantity\":13,\"skus\":[{\"k\":\"甜度\",\"kid\":642703,\"v\":\"5分\",\"vid\":596657},{\"k\":\"净含量\",\"kid\":497,\"v\":\"10g\",\"vid\":2569}]},{\"price\":3000,\"quantity\":32,\"skus\":[{\"k\":\"甜度\",\"kid\":642703,\"v\":\"5分\",\"vid\":596657},{\"k\":\"净含量\",\"kid\":497,\"v\":\"20g\",\"vid\":426}]}]",
                ItemSkuExtends = "[{\"cost_price\":800,\"s1\":606356,\"s2\":2569,\"s3\":0,\"s4\":0,\"s5\":0},{\"cost_price\":-1,\"s1\":606356,\"s2\":426,\"s3\":0,\"s4\":0,\"s5\":0},{\"cost_price\":800,\"s1\":596657,\"s2\":2569,\"s3\":0,\"s4\":0,\"s5\":0},{\"cost_price\":-1,\"s1\":596657,\"s2\":426,\"s3\":0,\"s4\":0,\"s5\":0}]",
                ImageIds = "1292764074,1292808215"
            }).Execute();
            Console.WriteLine(result);
        }
        private static void testUploadFileSizeToLarge(Auth auth) {
            var result =
                new UploadMaterialsStoragePlatformImg(auth, UploadFile.Create(@"C:\Users\dell\OneDrive\ME\IMG_5874.JPG"))
                    .Execute();
            Console.WriteLine(result);
        }
        private static void testUploadFile(Auth auth) {
            var result =
                new UploadMaterialsStoragePlatformImg(auth, UploadFile.Create(@"C:\Users\dell\Downloads\80d1a2a67bdcad142848c2061f23ee93.jpg"))
                    .Execute();
            Console.WriteLine(result);
        }
        private static void testGetItemCategories(Auth auth) {
            var api = new GetItemCategories(auth);
            var resultStr = api.Execute();
            Console.WriteLine(resultStr);
        }
        private static void testGetOnSaleItemsParams(Auth auth) {
            var param = new GetOnSaleItemsParams {
                PageSize = 10,
                Q = "二",
                OrderBy = "aaa"
            };
            var api = new GetOnSaleItemsApi(auth, param);
            var resultStr = api.Execute();
            Console.WriteLine(resultStr);
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
