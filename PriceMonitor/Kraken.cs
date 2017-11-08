using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Kraken:StockExchange
    {
        public Kraken()
        {
            Name = "Kraken";
            UrlAPI = "https://api.kraken.com/0/public/";
            Url = "https://kraken.com/charts";
            AvailableCoins = new List<string>();
            Price = new Dictionary<string, CurrentPrice>();
        }

        public override List<string> GetAssets()
        {
            string command = "Assets";
            return Engine.DeserializeToAssetsKraken(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice(string coin)
        {
            string command = "Depth?pair=" + coin + "XBT&count=1";
            string resp = Engine.Request(UrlAPI + command);

            if (resp.Contains("Unknown asset pair") )
            {
                Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }
            //21
            resp = resp.Substring(21, resp.Length - 22);
            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            resp = resp.Remove(0,resp.IndexOf(':'));
            resp = "{\"coin\""+resp;

            PriceKraken pl = Engine.DeserializeToPriceKraken(resp); //может быть без бида или аска ответ!!!
            CurrentPrice pr;
            if (pl.coin["asks"].Count!=0 && pl.coin["bids"].Count != 0)
            {
                pr.ask = pl.coin["asks"][0];
                pr.bid = pl.coin["bids"][0];
                Price[coin] = pr;
            }
        }

        public override string GetUrl(string coin)
        {
            return Url;
        }
    }
}
