using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    public abstract class StockExchange
    {
        public virtual string GetPrice(string str)
        {
            return "";
        }

        public virtual object[] GetAssets()
        {

            return new object[5];
        }
    }
}
