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
            AvailableCoins = new List<string>();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "returnCurrencies";
            return Engine.DeserializeToAssetsPoloniex(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice() //даже тут не надо передавать список
        {
            string command = "returnOrderBook&currencyPair=all&depth=1";
            string resp = Engine.Request(UrlAPI + command);

            //if (resp.Contains("Invalid currency pair."))
            //{
            //    Price.Remove(coin);
            //    //Price[coin].Clear();
            //    return;
            //}

            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");

            Dictionary<string,PricePoloniex> pp = Engine.DeserializeToPricePoloniex(resp);
            CurrentPrice pr;
            if (!pp.Equals(null))
            {
                string key; 
                Price.Keys.ToList().ForEach(pk =>
                {
                    key= "BTC_" + pk.ToUpper();
                    if (pp.Keys.Contains(key))
                    {
                        pr.ask = double.Parse(pp[key].Asks[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        pr.bid = double.Parse(pp[key].Bids[0].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                        Price[pk] = pr;
                    }

                });
                
            }
        }
        public override string GetUrl(string coin)
        {
            return Url + coin;
        }
    }
}
