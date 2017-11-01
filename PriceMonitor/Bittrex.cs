using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriceMonitor
{
    class Bittrex: StockExchange
    {
        public Bittrex()
        {
            Name = "Bittrex";
            UrlAPI = "https://bittrex.com/api/v1.1/public/";
            Url = "https://bittrex.com/Market/Index?MarketName=BTC-";
            AvailableCoins=GetAssets();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "getcurrencies";
            return Engine.DeserializeToAssetsBittrex(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice(string coin)
        {
            string command = "getticker?market=BTC-" + coin;
            string resp = Engine.Request(UrlAPI+command);
            if (resp.Contains("Bad request") || resp.Contains("INVALID_MARKET"))
            {
                Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }
            
            Dictionary<string,double> dict=Engine.DeserializeToPriceBittrex(resp);
            CurrentPrice pr;
            pr.ask= dict["Ask"];
            pr.bid= dict["Bid"];
            Price[coin] = pr;
        }
    }
}
