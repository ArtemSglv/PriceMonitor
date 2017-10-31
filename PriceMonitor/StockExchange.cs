using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriceMonitor
{
    public abstract class StockExchange
    {
        public string Name { get; set; }
        public string UrlAPI { get; set; }
        public List<string> AvailableCoins { get; set; }

        public StockExchange() {  }

        public abstract string GetPrice(string coin);

        public abstract List<string> GetAssets();
    }
}
