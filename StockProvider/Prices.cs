using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockProvider
{
    public class Prices
    {
        private string _symbol;
        private double _price;
        

        public Prices()
        {
        }

        public Prices(string symbol, double price)
        {
            this._symbol = symbol;
            this._price = price;
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }

        public double TradePrice
        {
            get { return _price; }
            set { _price = value; }
        }

        

    }
}
