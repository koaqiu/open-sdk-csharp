using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YZOpenSDK.Entrys;

namespace YZOpenSDK.Util {
    public class FileCache : ICache {
        string getCacheFile() {
            var path = Path.Combine(AppContext.BaseDirectory, "cache");
            Directory.CreateDirectory(path);
            return Path.Combine(path, "youzan-token.cache");
        }
        public AccessToken GetToken() {
            var configFile = getCacheFile();
            return File.Exists(configFile) ? BaseEntry.FromJson<AccessToken>(File.ReadAllText(configFile)) : null;
        }

        public void SaveToken(AccessToken token) {
            var configFile = getCacheFile();
            File.WriteAllText(configFile, token.ToJson());
        }
    }
}
