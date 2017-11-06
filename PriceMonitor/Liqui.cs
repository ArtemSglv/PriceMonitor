using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Liqui : StockExchange
    {
        public Liqui()
        {
            Name = "Liqui";
            UrlAPI = "https://api.liqui.io/api/3/";
            Url = "https://liqui.io/#/exchange/";
            AvailableCoins = GetAssets();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "info";
            return Engine.DeserializeToAssetsLiqui(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice(string coin)
        {
            string command = "depth/" + coin.ToLower() + "_btc?limit=1";
            string resp = Engine.Request(UrlAPI + command);

            if (resp.Contains("Invalid pair name") || resp.Contains("Requests too often"))
            {
                Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }

            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            resp = resp.Replace(coin.ToLower() + "_btc", "coin");

            PriceLiqui pl = Engine.DeserializeToPriceLiqui(resp);
            CurrentPrice pr;
            if (!pl.Equals(null))
            {
                pr.ask = pl.coin["asks"][0];
                pr.bid = pl.coin["bids"][0];
                Price[coin] = pr;
            }
        }

        public override string GetUrl(string coin)
        {
            return Url + coin + "_BTC";
        }
    }
}
