using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;

namespace YZOpenSDK.xBei.Youzan.Apis.Platform {
    /// <summary>
    /// 本地图片上传(http post)，仅支持单个文件上传，每个文件不超过1MB。
    /// TODO:每次发起10个并发请求最佳
    /// </summary>
    public class UploadMaterialsStoragePlatformImg : AbstractApi<YouzanMaterialsStoragePlatformImgUploadResult> {
        public override string ApiName => "youzan.materials.storage.platform.img.upload";
        public override string Method => ApiRequestMethod.POST;
        /// <summary>
        /// 本地图片上传(http post)，仅支持单个文件上传，每个文件不超过1MB。
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="toUploadFile">文件不超过1MB。</param>
        public UploadMaterialsStoragePlatformImg(Auth auth, UploadFile toUploadFile) : base(auth, toUploadFiles: new[] { toUploadFile }) {
        }
    }
}
