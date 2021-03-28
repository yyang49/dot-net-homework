using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Customer
    {
        public string name,info;
        public Customer(string name, string info)
        {
            this.name = name;
            this.info = info;
        }
        public override string ToString()
        {
            return $"{name}\t{info}";
        }
    }
}
