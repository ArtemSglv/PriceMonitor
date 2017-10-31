﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriceMonitor
{
    class Poloniex : StockExchange
    {
        public Poloniex()
        {
            Name = "Poloniex";
            UrlAPI = "https://poloniex.com/public?command=";
            AvailableCoins=GetAssets();
            
            
        }

        public override List<string> GetAssets()
        {
            string command = "returnCurrencies";
            return Engine.DeserializeToAssetsPoloniex(Engine.Request(UrlAPI + command));            
        }

        public override string GetPrice(string coin)
        {
            string command ="returnOrderBook&currencyPair=BTC_" + coin + "&depth=1";
            string resp = Engine.Request(UrlAPI+command);

            if (resp.Contains("Invalid currency pair."))
                return "";

            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");

            PricePoloniex pr = Engine.DeserializeToPricePoloniex(resp);

            return "asks: " + pr.Asks[0].ToString() + "\r\n" + "bids: " + pr.Bids[0];
        }
    }
}
