using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    struct PricePoloniex
    {
        public List<object> Bids { get; set; }
        public List<object> Asks { get; set; }
        public object isFrozen { get; set; }
        public object seq { get; set; }
    }

    struct CurrencyBittrex
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

    struct CurrencyLiqui
    {
        public int server_time { get; set; }
        public Dictionary<string,object> pairs { get; set; }
    }

    struct PriceLiqui
    {
        public Dictionary<string, List<double>> coin { get; set; }
    }

    struct CurrencyKraken
    {
        public object[] error { get; set; }
        public Dictionary<string, Dictionary<string,object>> result { get; set; }
    }

    struct PriceKraken
    {
        public Dictionary<string, List<double>> coin { get; set; }
    }

}
