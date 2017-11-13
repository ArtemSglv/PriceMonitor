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
            AvailableCoins = new List<string>();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "info";
            return Engine.DeserializeToAssetsLiqui(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice()
        {
            string command = "depth/";
            string resp = string.Empty;
            Price.Keys.ToList().ForEach(pk =>
            {
                if(AvailableCoins.Contains(pk))
                command += pk.ToLower() + "_btc-";                
            });
            command = command.Remove(command.Count()-1);
            command += "?limit=1&ignore_invalid=1";
            resp = Engine.Request(UrlAPI + command);

            if (resp.Contains("Requests too often") || resp.Contains("not available") || resp.Contains("Empty pair list"))
            {
                //Price.Remove(coin);
                return;
            }

            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            resp = resp.Replace("_btc","");

            Dictionary<string,PriceLiqui> pl = Engine.DeserializeToPriceLiqui(resp);
            CurrentPrice pr;
            if (!pl.Keys.Equals(null))
            {
                Price.Keys.ToList().ForEach(pk=> 
                {
                    if (pl.Keys.Contains(pk.ToLower()))
                    {
                        pr.ask = pl[pk.ToLower()].asks.Count!=0?pl[pk.ToLower()].asks[0]:0;
                        pr.bid = pl[pk.ToLower()].bids.Count!=0? pl[pk.ToLower()].bids[0]:0;
                        Price[pk] = pr;
                    }
                });
                
            }
        }

        public override string GetUrl(string coin)
        {
            return Url + coin + "_BTC";
        }
    }
}
