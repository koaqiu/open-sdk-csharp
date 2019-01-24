using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanMaterialsStoragePlatformImgUploadResult {
        /// <summary>
        ///  图片链接
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }

        /// <summary>
        ///  店铺id
        /// </summary>
        [JsonProperty("kdt_id")]
        public long KdtId { get; set; }

        /// <summary>
        ///  图片id
        /// </summary>
        [JsonProperty("image_id")]
        public long ImageId { get; set; }
    }
}
