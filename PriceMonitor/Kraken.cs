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
            string command = "AssetPairs";
            return Engine.DeserializeToAssetsKraken(Engine.Request(UrlAPI + command));
        }

        public override void GetPrice()
        {
            string command = "Ticker?pair=";
            Price.Keys.ToList().ForEach(pk=>
            {
                if (AvailableCoins.Contains(pk))
                    command += pk + "XBT,";
            });
            command=command.Remove(command.Length-1);
            string resp = Engine.Request(UrlAPI + command);

            if (resp.Contains("Unknown asset pair"))
            {
                //Price.Remove(coin);
                //Price[coin].Clear();
                return;
            }
            //21
            //resp = resp.Substring(21, resp.Length - 22);
            resp = resp.Replace("[[", "[");
            resp = resp.Replace("]]", "]");
            //resp = resp.Remove(0, resp.IndexOf(':'));
            //resp = "{\"coin\"" + resp;

            PriceKraken pl = Engine.DeserializeToPriceKraken(resp); //может быть без бида или аска ответ!!!
            CurrentPrice pr;
            if (!pl.Equals(null))
            {
                Price.Keys.ToList().ForEach(pk => {
                    pl.result.Keys.ToList().ForEach(plk =>
                    {
                        if (plk.Contains(pk))
                        {
                            pr.ask = pl.result[plk].a[0];
                            pr.bid = pl.result[plk].b[0];
                            Price[pk] = pr;
                        }
                    }
                    );                    
                });
            }
        }

        public override string GetUrl(string coin)
        {
            return Url;
        }
    }
}
