using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine6
{
    public class Item
    {
        private string _name;
        private decimal _price;
        private int _count;
        public Item(string Name, decimal Price, int Count)
        {
            _name = Name;
            _price = Price;
            _count = Count;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
