using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    [Serializable]
    public class OrderDetails
    {
        public Commodity goods;
        public int quantity { get; set; }
        public string goodsNo { get => goods.no; set { goods.no = value; } }
        public string goodsName { get => goods.name; set { goods.name = value; } }
        public double goodsPrice { get=>goods.price; set { goods.price = value; } }
        public OrderDetails(Commodity goods,int quantity)
        {
            this.goods = goods;
            this.quantity = quantity;
        }
        public OrderDetails()
        {
            this.goods = new Commodity();
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
            if (goods.no == null) return -1;
            return int.Parse(goods.no);
        }
    }
}
