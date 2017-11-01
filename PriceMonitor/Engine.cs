using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Net;
using Newtonsoft.Json;

namespace PriceMonitor
{
    class Engine
    {
        public static List<StockExchange> exchanges= new List<StockExchange>(){
            new Poloniex(),
            new Bittrex() };

       
        public static List<string> listAssets = new List<string>();

        public static string Request(string url)
        {
            return new WebClient().DownloadString(url);
        }

        public static List<string> DeserializeToAssetsPoloniex(string str)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, object>>(str).Keys.ToList();
        }

        public static List<string> DeserializeToAssetsBittrex(string str)
        {
            List<string> res = new List<string>();
            CurrencyBittrex curBit = JsonConvert.DeserializeObject<CurrencyBittrex>(str);
            curBit.result.ForEach(x => { res.Add(x["Currency"].ToString()); });
            return res;
        }

        public static PricePoloniex DeserializeToPricePoloniex(string str)
        {
            return JsonConvert.DeserializeObject<PricePoloniex>(str);
        }

        public static Dictionary<string, double> DeserializeToPriceBittrex(string str)
        {
            //List<string> res = new List<string>();

            return JsonConvert.DeserializeObject<PriceBittrex>(str).result;

            //return res;
        }

        public static void ScanAssets()
        {
            foreach (StockExchange ex in exchanges)
            {
                if (listAssets.Count == 0)
                    listAssets.AddRange(ex.AvailableCoins);
                else
                    listAssets.Union(ex.AvailableCoins);
            }
        }          
            
        public static void GetPrice(string coin)
        {
            exchanges.ForEach(x => {
                x.GetPrice(coin);
            });
        }
    }
}
