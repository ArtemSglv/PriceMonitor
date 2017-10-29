using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Data
    {
        public int id { get; set; }
        public string name { get; set; }
        public string txFee { get; set; }
        public int minConf { get; set; }
        public object depositAddress { get; set; }
        public int disabled { get; set; }
        public int delisted { get; set; }
        public int frozen { get; set; }
    }
    class Coin
    {
        public string Name { get; set; }
        public Data data{get;set;}
    }
}
