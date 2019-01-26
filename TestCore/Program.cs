using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using YZOpenSDK;
using YZOpenSDK.Entrys;
using YZOpenSDK.Util;
using YZOpenSDK.xBei.Helper;
using YZOpenSDK.xBei.Youzan.Apis.Goods;
using YZOpenSDK.xBei.Youzan.Apis.Logistics;
using YZOpenSDK.xBei.Youzan.Apis.Platform;
using YZOpenSDK.xBei.Youzan.Params;
using YZOpenSDK.xBei.Youzan.Utils;

namespace TestCore {
    internal class Program {
        private static void Main(string[] args) {
            var config = getConfig();
            HttpClientService.Init();

            var auth = new Token(config, new FileCache());
            try {
                //var tasklist = new List<Task>();
                //Console.WriteLine("RUN testSearchLogisticsTemplate...");
                //tasklist.Add(testSearchLogisticsTemplate(auth));
                //Console.WriteLine("RUN testGetItem...");
                //tasklist.Add(testGetItem(auth));
                //testGetInventoryItems(auth);
                //Task.WaitAll(tasklist.ToArray());
                //var img =
                //    new UploadMaterialsStoragePlatformImg(auth, UploadFile.Create(@"C:\Users\dell\Downloads\6a31436c9bf326ba5721a38dda1103c6.jpg"))
                //        .Execute();
                //Console.WriteLine(img);
                var result = new UpdateItem(auth, new UpdateItemParams() {
                    ItemId = 451762956,
                    SkuStocks = new SkuBuilder()
                        .AddItem(1, 1, new[] { "CPU", "I7", "内存", "8G" })
                        .AddItem(1, 1, new[] { "CPU", "I6", "内存", "4G" })
                        .AddItem(1, 1, new[] { "CPU", "I7", "内存", "4G" })
                        .AddItem(1, 1, new[] { "CPU", "I6", "内存", "8G" })
                        .ToJson(),
                    SkuImages = new SkuImageBuilder()
                        .AddItem("8G", "http://www.cgart.cn/zt/ANNI/food/kaffe_2000X2000.png")
                        .AddItem("4G","1293905451")
                        .ToJson(),
                    Cid = 3000000,
                    IsDisplay = 1,
                }).Execute();
                Console.WriteLine(result);

            } catch (Exception ex) {
                Console.WriteLine("发生错误：");
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        private static Task testSearchLogisticsTemplate(Auth auth) {
            return Task.Run(async () => {
                var result = await new SearchLogisticsTemplate(auth, new SearchLogisticsTemplateParams {
                    PageNo = 1,
                    PageSize = 10
                }).ExecuteAsync();
                Console.WriteLine("RUN testSearchLogisticsTemplate　OK：");
                Console.WriteLine(result);
            });

        }
        private static void testUpdateItemSku(Auth auth) {
            var result = new UpdateItemSku(auth, new UpdateItemSkuParams {
                ItemId = 451708760,
                Quantity = 1,
                SkuId = 36287245,
                Price = 9.99F
            }).Execute();
            Console.WriteLine(result);
        }
        private static void testUpdateItem(Auth auth) {
            var result = new UpdateItem(auth, new UpdateItemParams() {
                ItemId = 451708760,
                DeliveryTemplateId = 636431,
                // Title = "多规格部分成本价测试20190125"
                Cid = 3000000
            }).Execute();
            Console.WriteLine(result);
        }
        private static void testUpdateItemQuantity(Auth auth) {
            var result = new UpdateItemQuantity(auth, new UpdateItemQuantityParams {
                ItemId = 451708760,
                Quantity = 999,
                SkuId = 36287244
            }).Execute();
            Console.WriteLine(result);
        }
        private static void testUpdateItemDelisting(Auth auth) {
            var result = new UpdateItemDelisting(auth, new SimpleUpdateItemParams {
                ItemId = 451708760
            }).Execute();
            Console.WriteLine(result);
        }
        private static void testUpdateItemListing(Auth auth) {
            var result = new UpdateItemListing(auth, new SimpleUpdateItemParams {
                ItemId = 451708760
            }).Execute();
            Console.WriteLine(result);
        }
        private static Task testGetItem(Auth auth) {
            return Task.Run(async () => {
                var result = await new GetItem(auth, new GetItemParams {
                    ItemId = 451708760
                }).ExecuteAsync();
                Console.WriteLine("RUN testGetItem OK:");
                Console.WriteLine(result);
            });
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
        private static void testCreateGoodsItem2(Auth auth) {
            var result = new CreateItem(auth, new CreateItemParams {
                Title = "SKU测试 平板",
                Cid = 3000000,
                Price = 1,
                IsDisplay = 0,
                HideStock = 1,
                ItemType = 0,
                Desc = "SKU测试 平板 desc",
                SkuStocks = "[{\"price\":1,\"quantity\":20,\"item_no\":\"高配\",\"skus\":[{\"k\":\"CPU\",\"v\":\"I7\"},{\"k\":\"内存\",\"v\":\"8G\"}]}]",
                // SkuStocks = "[{\"price\":1,\"quantity\":23,\"item_no\":\"高配\",\"skus\":[{\"k\":\"CPU\",\"v\":\"I7\"}]},{\"price\":2,\"quantity\":2,\"item_no\":\"低配\",\"skus\":[{\"k\":\"CPU\",\"v\":\"I6\"}]}]",
                //ItemSkuExtends = "[{\"cost_price\":1,\"s1\":0,\"s2\":0,\"s3\":0,\"s4\":0,\"s5\":0},{\"cost_price\":1,\"s1\":0,\"s2\":0,\"s3\":0,\"s4\":0,\"s5\":0}]",
                ImageIds = "1292764074,1292808215"
            }).Execute();
            //451762956
            Console.WriteLine(result);
        }
        private static void testUpdateItem2(Auth auth) {
            var result = new UpdateItem(auth, new UpdateItemParams() {
                ItemId = 451762956,
                SkuStocks = new SkuBuilder()
                    .AddItem(1, 1, new[] { "CPU", "I7", "内存", "8G" })
                    .AddItem(1, 1, new[] { "CPU", "I6", "内存", "4G" })
                    .AddItem(1, 1, new[] { "CPU", "I7", "内存", "4G" })
                    .AddItem(1, 1, new[] { "CPU", "I6", "内存", "8G" })
                    .ToJson(),
                SkuWeight = "1000,1200,1300,0",

                DeliveryTemplateId = 636431,
                Cid = 3000000
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

        private static void testGetInventoryItems(Auth auth) {
            var param = new GetInventoryItemsParams {
                PageSize = 10,
                Q = "测试"
            };
            var api = new GetInventoryItems(auth, param);
            var resultStr = api.Execute();
            Console.WriteLine("testGetInventoryItems:");
            Console.WriteLine(resultStr);
        }

        private static YouzanConfig getConfig() {
            var conf = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .Build();
            return conf.GetSection("youzan").Get<YouzanConfig>();
        }
    }

}
