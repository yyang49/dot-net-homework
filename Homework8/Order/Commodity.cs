using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    [Serializable]
    public class Commodity
    {
        public string no, name;
        public double price;
        public Commodity(string no, string name, double price)
        {
            this.no = no;
            this.name = name;
            this.price = price;
        }
        public Commodity() { }
        public override string ToString()
        {
            return $"{no}\t{name}\t{price}元/件";
        }
    }
}
