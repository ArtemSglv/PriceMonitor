using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class PricePoloniex
    {
        public List<object> Bids { get; set; }
        public List<object> Asks { get; set; }
        public object isFrozen { get; set; }
        public object seq { get; set; }
    }

    class CurrencyBittrex
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Dictionary<string, object>> result { get; set; }
    }

    struct PriceBittrex
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Dictionary<string, double> result { get; set; }
    }

}
