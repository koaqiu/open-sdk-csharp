using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace YZOpenSDK.xBei.Helper {
    public static class StringHelper {
        public static string ToLowerLine(this string str) => Regex.Replace(str, "[A-Z]", match => $"{(match.Index > 0 ? "_" : "")}{match.Value.ToLower()}", RegexOptions.Compiled);
    }
}
