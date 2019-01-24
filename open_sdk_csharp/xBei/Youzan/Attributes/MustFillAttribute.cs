using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.xBei.Youzan.Attributes {
    public class MustFillAttribute : Attribute {
        private readonly long _dvLong;
        private readonly string _dvString;
        private readonly int _dvInt;
        private readonly int _mode;
        public MustFillAttribute(long dv) {
            _mode = 1;
            _dvLong = dv;
        }
        public MustFillAttribute(string dv) {
            _mode = 2;
            _dvString = dv;
        }
        public MustFillAttribute(int dv) {
            _mode = 3;
            _dvInt = dv;
        }

        public bool IsVaild(object value) {
            if (value == null) return false;
            switch (_mode) {
                case 1:
                    return isVaildLong((long)value);
                case 2:
                    return isVaildString((string)value);
                case 3:
                    return isVaildInt((int)value);
                default: return false;
            }
        }

        private bool isVaildLong(long value) {
            return _dvLong != value;
        }
        private bool isVaildString(string value) {
            return _dvString != value;
        }
        private bool isVaildInt(int value) {
            return _dvInt != value;
        }
    }
}
