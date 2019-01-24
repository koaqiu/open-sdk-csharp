using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace YZOpenSDK.Entrys {
    public class UploadFile {
        public string FileName { get; set; }
        public Stream Content { get; set; }

        public static UploadFile Create(string filePath) {
            var file = new FileInfo(filePath);
            return new UploadFile {
                FileName = file.FullName,
                Content = file.OpenRead()
            };
        }
        public static UploadFile Create(string fileName, byte[] buffer) {
            return new UploadFile {
                FileName = fileName,
                Content = new MemoryStream(buffer)
            };
        }
    }
}
