using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Bitfinex : StockExchange
    {
        public Bitfinex()
        {
            Name = "Bitfinex";
            UrlAPI = "https://api.bitfinex.com/v1/";
            Url = "https://www.bitfinex.com/t/";
            AvailableCoins = new List<string>();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "symbols";
            return Engine.DeserializeToAssetsBitfinex(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice()
        {
            string command = string.Empty;
            string resp = string.Empty;
            Price.Keys.ToList().ForEach(pk =>
            {
                command = "book/" + pk + "BTC?limit_asks=1&limit_bids=1";
                resp = Engine.Request(UrlAPI + command);

                if (resp.Contains("Unknown symbol"))
                {
                    Price.Remove(pk);
                    return;
                }

                resp = resp.Replace("[", "");
                resp = resp.Replace("]", "");

                Dictionary<string, Dictionary<string, double>> pb = Engine.DeserializeToPriceBitfinex(resp);
                CurrentPrice pr;
                if (pb.Keys != null)
                {
                    pr.ask = pb["asks"]["price"];
                    pr.bid = pb["bids"]["price"];
                    Price[pk] = pr;
                }
            });
        }

        public override string GetUrl(string coin)
        {
            return Url + coin.ToUpper() + ":BTC";
        }
    }
}
