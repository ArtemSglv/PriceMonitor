using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace PriceMonitor
{
    class Engine
    {
        public List<StockExchange> exchanges;
        public List<string> listAssets;

        public Engine()
        {
            exchanges = new List<StockExchange>()
            {
                new Poloniex(),
                new Bittrex(),
                new Liqui(),
                new Kraken(),
                new Bitfinex()
            };
            listAssets = new List<string>();

        }

        public static string Request(string url)
        {
            return new WebClient().DownloadString(url);
        }

        public static List<string> DeserializeToAssetsBitfinex(string str)
        {
            string sPattern = "^\\w*btc$";
            List<string> res = new List<string>();
            List<string> curBitfin = JsonConvert.DeserializeObject<List<string>>(str);
            curBitfin.ForEach(x => { if (System.Text.RegularExpressions.Regex.IsMatch(x, sPattern)) res.Add(x.Remove(x.Length - 3).ToUpper()); });
            res.Sort();
            return res;
        }

        public static List<string> DeserializeToAssetsKraken(string str)
        {
            List<string> res = new List<string>();
            CurrencyKraken curKrak = JsonConvert.DeserializeObject<CurrencyKraken>(str);
            curKrak.result.Keys.ToList().ForEach(x => { res.Add((curKrak.result[x])["altname"].ToString()); });
            res.Sort();
            return res;
        }

        public static List<string> DeserializeToAssetsLiqui(string str)
        {
            List<string> res = new List<string>();
            CurrencyLiqui curLiq = JsonConvert.DeserializeObject<CurrencyLiqui>(str);
            curLiq.pairs.Keys.ToList().ForEach(x => { if (x.Contains("_btc")) res.Add(x.Substring(0, x.ToString().Length - 4).ToUpper()); });
            res.Sort();
            return res;
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
            res.Sort();
            return res;
        }

        public static PricePoloniex DeserializeToPricePoloniex(string str)
        {
            return JsonConvert.DeserializeObject<PricePoloniex>(str);
        }

        public static PriceLiqui DeserializeToPriceLiqui(string str)
        {
            return JsonConvert.DeserializeObject<PriceLiqui>(str);
        }

        public static PriceKraken DeserializeToPriceKraken(string str)
        {
            return JsonConvert.DeserializeObject<PriceKraken>(str);
        }

        public static Dictionary<string, Dictionary<string, double>> DeserializeToPriceBitfinex(string str)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, double>>>(str);
        }

        public static Dictionary<string, double> DeserializeToPriceBittrex(string str)
        {
            //List<string> res = new List<string>();

            return JsonConvert.DeserializeObject<PriceBittrex>(str).result;

            //return res;
        }

        public void ScanAssets()
        {
            foreach (StockExchange ex in exchanges)
            {
                if (listAssets.Count == 0)
                    listAssets.AddRange(ex.AvailableCoins = ex.GetAssets());
                else
                {
                    listAssets = listAssets.Union(ex.AvailableCoins = ex.GetAssets()).ToList();
                    listAssets.Sort();
                }
            }
        }

        public void GetPrice(string coin)
        {
            try
            {                
                exchanges.ForEach(x =>
                {
                    x.GetPrice(coin);
                });
            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("Too Many Requests"))
                    Thread.Sleep(95000);

            }
        }
    }
}
