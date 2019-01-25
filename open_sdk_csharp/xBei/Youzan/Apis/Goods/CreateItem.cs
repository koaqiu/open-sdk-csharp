﻿using System;
using System.Collections.Generic;
using System.Text;
using YZOpenSDK.Entrys;
using YZOpenSDK.xBei.Youzan.Entrys;
using YZOpenSDK.xBei.Youzan.Params;

namespace YZOpenSDK.xBei.Youzan.Apis.Goods {
    /// <summary>
    /// 新增商品
    /// </summary>
    public class CreateItem : AbstractApi<YouzanItemCreateResult> {
        public override string ApiName => "youzan.item.create";
        public override string Method => ApiRequestMethod.POST;
        /// <summary>
        ///	新增商品
        /// </summary>
        /// <param name="auth"></param>
        /// <param name="args"></param>
        public CreateItem(Auth auth, CreateItemParams args) : base(auth, args) {
        }
    }
}
