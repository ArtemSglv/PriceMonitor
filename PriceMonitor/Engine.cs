﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;

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
                new Liqui()
            };
            listAssets = new List<string>();
            
        }

        public static string Request(string url)
        {
            return new WebClient().DownloadString(url);
        }

        public static List<string> DeserializeToAssetsLiqui(string str)
        {
            List<string> res = new List<string>();
            CurrencyLiqui curLiq = JsonConvert.DeserializeObject<CurrencyLiqui>(str);
            //curLiq.pairs.ForEach(x=> { x.Keys.ToList().ForEach(k=> { if (k.Contains("_btc")) res.Add(k.Substring(0, x.ToString().Length - 4)); });  });
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
                    listAssets.AddRange(ex.AvailableCoins);
                else
                    listAssets.Union(ex.AvailableCoins);
            }
        }

        public void GetPrice(string coin)
        {
            exchanges.ForEach(x =>
            {
                x.GetPrice(coin);
            });
        }
    }
}
