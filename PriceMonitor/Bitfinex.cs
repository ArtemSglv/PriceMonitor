﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Bitfinex:StockExchange
    {
        public Bitfinex()
        {
            Name = "Bitfinex";
            UrlAPI = "https://api.bitfinex.com/v1";
            Url = "https://";
            AvailableCoins = GetAssets();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "Assets";
            return Engine.DeserializeToAssetsKraken(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice(string coin)
        {
            string command = "Depth?pair=" + coin + "XBT&count=1";
            string resp = Engine.Request(UrlAPI + command);

            if (resp.Contains("Unknown asset pair"))
            {
                Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }
            //21
            resp = resp.Substring(21, resp.Length - 22);
            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            resp = resp.Remove(0, resp.IndexOf(':'));
            resp = "{\"coin\"" + resp;

            PriceLiqui pl = Engine.DeserializeToPriceKraken(resp);
            CurrentPrice pr;
            pr.ask = pl.coin["asks"][0];
            pr.bid = pl.coin["bids"][0];
            Price[coin] = pr;
        }

        public override string GetUrl(string coin)
        {
            return Url;
        }
    }
}