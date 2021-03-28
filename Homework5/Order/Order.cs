using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Order : IComparable<Order>
    {
        public int orderNo;
        public Customer customer;
        public List<OrderDetails> orderDetails= new List<OrderDetails>();
        public double total
        {
            get
            {
                double total = 0;
                foreach (OrderDetails orderDetail in orderDetails)
                {
                    total += orderDetail.goods.price * orderDetail.quantity;
                }
                return total;
            }
        }
        public Order(int orderNo, Customer customer, params OrderDetails[] orderDetails)
        {
            this.orderNo = orderNo;
            this.customer = customer;
            foreach(OrderDetails orderDetail in orderDetails)
            {
                if (!this.orderDetails.Contains(orderDetail))
                {
                    this.orderDetails.Add(orderDetail);
                }
            }
        }
        public override bool Equals(object obj)
        {
            Order order = obj as Order;
            return order != null && orderNo == order.orderNo;
        }

        public override int GetHashCode()
        {
            return orderNo;
        }

        public override string ToString()
        {
            StringBuilder details = new StringBuilder();
            foreach (OrderDetails orderDetail in orderDetails)
            {
                details.Append(orderDetail);
            }
            return $"订单号：{orderNo}\n客户：{customer}\n商品：\n{details.ToString()}金额: {total}\n";
        }
        public int CompareTo(Order order)
        {
            return orderNo.CompareTo(order.orderNo);
        }
    }
}
