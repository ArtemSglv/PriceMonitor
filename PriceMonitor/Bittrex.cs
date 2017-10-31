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
            AvailableCoins=GetAssets(); 
        }

        public override List<string> GetAssets()
        {
            string command = "getcurrencies";
            return Engine.DeserializeToAssetsBittrex(Engine.Request(UrlAPI + command));
        }

        public override string GetPrice(string coin)
        {
            string command = "getticker?market=BTC-" + coin;
            string resp = Engine.Request(UrlAPI+command);
            if (resp.Contains("Bad request") || resp.Contains("INVALID_MARKET"))
                return "";
            
            Dictionary<string,double> dict=Engine.DeserializeToPriceBittrex(resp);

            return "asks: " + dict["Ask"] + "\r\n" + "bids: " + dict["Bid"];
        }
    }
}
