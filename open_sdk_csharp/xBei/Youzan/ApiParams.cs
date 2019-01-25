using System;
using System.Collections.Generic;
using System.Linq;
using YZOpenSDK.xBei.Helper;
using YZOpenSDK.xBei.Youzan.Attributes;

namespace YZOpenSDK.xBei.Youzan {
    public abstract class ApiParams {
        /// <summary>
        /// 校验参数，如果参数有错误，直接抛异常
        /// </summary>
        /// <returns></returns>
        protected virtual bool isVaild() => true;

        public IDictionary<string, object> GetParams() {
            isVaild();
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
                        if (property.CustomAttributes.Any(a => a.AttributeType == typeof(OverrideFillAttribute))) {
                            if (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(v as string)) return false;
                            if (property.PropertyType == typeof(int) && (int)v == 0) return false;
                            if (property.PropertyType == typeof(long) && (long)v == 0L) return false;
                            if (property.PropertyType == typeof(float) && Math.Abs((float)v) < 0.000001) return false;
                        }

                        var attributes = property.GetCustomAttributes(false);
                        foreach (var attribute in attributes) {
                            if (attribute is OverrideFillAttribute) {
                                break;
                            }
                            if (attribute is MustFillAttribute mfa) {
                                if (!mfa.IsVaild(v)) {
                                    throw new Exception($"【{property.Name}】必须填写！");
                                }
                            }
                        }

                        if (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(v as string)) return false;
                        return true;
                    });
            return properties.ToDictionary(item => item.Name.ToLowerLine(), item => item.GetValue(this));
        }
    }
}
