using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace YZOpenSDK.xBei.Youzan.Entrys {
    public class YouzanItemcategoriesGetResult {
        /// <summary>
        ///  商品自定义标签列表
        /// </summary>
        [JsonProperty("categories")]
        public CategoriesModel[] Categories { get; set; }


        public class CategoriesModel {
            /// <summary>
            ///  节点
            /// </summary>
            [JsonProperty("cid")]
            public long Cid { get; set; }

            /// <summary>
            ///  父节点
            /// </summary>
            [JsonProperty("parent_cid")]
            public long ParentCid { get; set; }

            /// <summary>
            ///  名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            ///  是否为父节点
            /// </summary>
            [JsonProperty("is_parent")]
            public Boolean IsParent { get; set; }

            /// <summary>
            ///  分类
            /// </summary>
            [JsonProperty("sub_categories")]
            public SubCategoriesModel[] SubCategories { get; set; }

        }

        public class SubCategoriesModel {
            /// <summary>
            ///  节点id
            /// </summary>
            [JsonProperty("cid")]
            public long Cid { get; set; }

            /// <summary>
            ///  父节点id
            /// </summary>
            [JsonProperty("parent_cid")]
            public long ParentCid { get; set; }

            /// <summary>
            ///  名称
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            ///  是否为父节点
            /// </summary>
            [JsonProperty("is_parent")]
            public Boolean IsParent { get; set; }

            /// <summary>
            ///  子节点
            /// </summary>
            [JsonProperty("sub_categories")]
            public SubCategoriesModel[] SubCategories { get; set; }
        }
    }
}
