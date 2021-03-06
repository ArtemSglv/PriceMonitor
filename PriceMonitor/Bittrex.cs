﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriceMonitor
{
    class Bittrex : StockExchange
    {
        public Bittrex()
        {
            Name = "Bittrex";
            UrlAPI = "https://bittrex.com/api/v1.1/public/";
            Url = "https://bittrex.com/Market/Index?MarketName=BTC-";
            AvailableCoins = new List<string>();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "getcurrencies";
            return Engine.DeserializeToAssetsBittrex(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice()
        {
            string command = string.Empty;
            string resp = string.Empty;
            Price.Keys.ToList().ForEach(pk =>
            {
                command = "getticker?market=BTC-" + pk;
                resp=Engine.Request(UrlAPI + command);
                if (resp.Contains("INVALID_MARKET"))
                {
                    Price.Remove(pk);
                    return;
                }

                Dictionary<string, double> dict = Engine.DeserializeToPriceBittrex(resp);
                CurrentPrice pr;
                if (dict != null)
                {
                    pr.ask = dict["Ask"];
                    pr.bid = dict["Bid"];
                    Price[pk] = pr;
                }
            });
        }

        public override string GetUrl(string coin)
        {
            return Url + coin;
        }
    }
}
