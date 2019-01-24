using System;
using System.Collections.Generic;
using System.IO;
using YZOpenSDK.Entrys;

namespace YZOpenSDK
{
	public interface YZClient
	{
		string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams, IEnumerable<KeyValuePair<string, UploadFile>> files);
	    string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams, IEnumerable<KeyValuePair<string, string>> files);
	    string Invoke(string apiName, string version, string method, IDictionary<string, object> apiParams, IEnumerable<KeyValuePair<string, FileInfo>> files);
    }
}
