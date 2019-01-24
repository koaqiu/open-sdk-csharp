using System;
using System.Collections.Generic;
using System.Linq;
using YZOpenSDK.xBei.Helper;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan {
    public class ApiParams {
        public IDictionary<string, object> GetParams() {
            var type = this.GetType();
            var properties = type.GetProperties()
                    .Where(property => {
                        if (property.CustomAttributes.Any(a => a.AttributeType == typeof(IgnoreAttribute)))
                            return false;
                        var canBeNull = property.PropertyType.IsGenericType &&
                                        property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>);
                        var v = property.GetValue(this);
                        if (canBeNull && v == null)
                            return false;

                        var attributes = property.GetCustomAttributes(false);
                        foreach (var attribute in attributes) {
                            if (attribute is MustFillAttribute mfa) {
                                if (!mfa.IsVaild(v)) {
                                    throw new Exception($"【{property.Name}】必须填写！");
                                }
                            }
                        }
                        if (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(v as string)) return false;
                        return true;
                    })
               ;
            return properties.ToDictionary(item => item.Name.ToLowerLine(), item => item.GetValue(this));
        }
    }
}
