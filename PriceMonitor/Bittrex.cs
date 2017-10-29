using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Bittrex: StockExchange
    {
        public override string GetPrice(string coin)
        {
            string req = "https://poloniex.com/public?command=returnOrderBook&currencyPair=BTC_" + coin + "&depth=1";
            string resp = Engine.Request(req);
            if (resp.Contains("Invalid currency pair."))
                return "";
            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            Price pr = Engine.DeserializeFromJSON(resp);
            return "asks: " + pr.Asks[0] + "\r\n" + "bids: " + pr.Bids[0];
        }
    }
}
