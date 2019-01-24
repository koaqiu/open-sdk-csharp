using System.Text.RegularExpressions;

namespace YZOpenSDK.xBei.Helper {
    public static class StringHelper {
        /// <summary>
        /// 驼峰转下划线
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToLowerLine(this string str) => Regex.Replace(str, "[A-Z]", match => $"{(match.Index > 0 ? "_" : "")}{match.Value.ToLower()}", RegexOptions.Compiled);
        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FirstUpperCase(this string str) => str.Length > 0 ? $"{char.ToUpper(str[0])}{str.Substring(1)}" : str;
        /// <summary>
        /// 转换为驼峰
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCamel(this string str) =>
            Regex.Replace(str, "([^_])(?:_+([^_]))", match => $"{match.Groups[1].Value}{match.Groups[2].Value.ToUpper()}").Trim('_').FirstUpperCase();
    }
}
