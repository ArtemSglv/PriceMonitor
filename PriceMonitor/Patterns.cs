using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Price
    {
        public List<object> Bids { get; set; }
        public List<object> Asks {get;set;}
        public object isFrozen { get; set; }
        public object seq { get; set; }
    }
}
