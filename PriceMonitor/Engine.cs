using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace PriceMonitor
{
    class Engine
    {
        public static string Request(string url)
        {
            return new WebClient().DownloadString(url);
        }

        public static Dictionary<K, V> DeserializeFromJSON<K, V>(string str)
        {
            return JsonConvert.DeserializeObject<Dictionary<K,V>>(str);
        }
    }
}
