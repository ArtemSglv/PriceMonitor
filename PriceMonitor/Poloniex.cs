using System;
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
            Url = "https://poloniex.com/exchange#btc_";
            AvailableCoins=GetAssets();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "returnCurrencies";
            return Engine.DeserializeToAssetsPoloniex(Engine.Request(UrlAPI + command));            
        }

        public override void GetPrice(string coin)
        {
            string command ="returnOrderBook&currencyPair=BTC_" + coin + "&depth=1";
            string resp = Engine.Request(UrlAPI+command);

            if (resp.Contains("Invalid currency pair."))
            {
                Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }

            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");

            PricePoloniex pp = Engine.DeserializeToPricePoloniex(resp);
            CurrentPrice pr;
            pr.ask = double.Parse(pp.Asks[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            pr.bid = double.Parse(pp.Bids[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
            Price[coin]=pr;
        }
        public override string GetUrl(string coin)
        {
            return Url + coin;
        }
    }
}
