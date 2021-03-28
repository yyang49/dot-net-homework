using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderDetails
    {
        public Commodity goods;
        public int quantity;
        public OrderDetails(Commodity goods,int quantity)
        {
            this.goods = goods;
            this.quantity = quantity;
        }
        public override string ToString()
        {
            return $"{goods}\n{quantity}件\t共{goods.price*quantity}元\n";
        }
        public override bool Equals(object obj)
        {
            OrderDetails orderDetail = obj as OrderDetails;
            return orderDetail != null && goods.no == orderDetail.goods.no;
        }
        public override int GetHashCode()
        {
            return int.Parse(goods.no);
        }
    }
}
