using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceMonitor
{
    class Poloniex:StockExchange
    {
        public override object[] GetAssets()
        {
            var respStr = Engine.Request("https://poloniex.com/public?command=returnCurrencies");
            return Engine.DeserializeFromJSON<string, object>(respStr).Keys.ToArray();
            //return new object[5];
        }

        public override string GetPrice()
        {
            return "";
        }
    }
}
