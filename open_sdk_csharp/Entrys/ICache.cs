using System;
using System.Collections.Generic;
using System.Text;

namespace YZOpenSDK.Entrys {
    public interface ICache
    {
        AccessToken GetToken();
        void SaveToken(AccessToken token);
    }
}
