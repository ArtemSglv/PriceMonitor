using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriceMonitor
{
    public abstract class StockExchange
    {
        public struct CurrentPrice
        {
            public double ask;
            public double bid;
            public override string ToString()
            {
                return (ask != 0.0d && bid != 0.0d) ? "asks: " + ask.ToString("F8") + "\r\nbids: " + bid.ToString("F8") : "";
            }
            public void Clear()
            {
                ask = 0.0d;
                bid = 0.0d;
            }
        }

        public string Name { get; set; }
        public string UrlAPI { get; set; }
        public List<string> AvailableCoins { get; set; }
        public CurrentPrice Price;

        public StockExchange() { }

        public abstract void GetPrice(string coin);

        public abstract List<string> GetAssets();
    }
}
