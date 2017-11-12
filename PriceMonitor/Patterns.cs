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
        public List<double> bids { get; set; }
        public List<double> asks { get; set; }
    }

    struct CurrencyKraken
    {
        public object[] error { get; set; }
        public Dictionary<string, Dictionary<string,object>> result { get; set; }
    }

    struct PriceKraken
    {
        public List<object> error { get; set; }
        public Dictionary<string, PriceKrakenResult> result { get; set; }
    }
    struct PriceKrakenResult
    {
        public List<double> a { get; set; }
        public List<double> b { get; set; }
        public List<double> v { get; set; }
        public List<double> c { get; set; }
        public List<double> p { get; set; }
        public List<double> t { get; set; }
        public List<double> l { get; set; }
        public List<double> h { get; set; }
        public double o { get; set; }
    }

}
