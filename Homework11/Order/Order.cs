using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Order
{
    [Serializable]
    public class Order : IComparable<Order>
    {
        [Key]
        public int orderNo { get; set; }
        [Required]
        public Customer customer { get; set; }
        [NotMapped]
        public String customerName { get => customer.name; set => customer.name = value; }
        [NotMapped]
        public String customerInfo { get => customer.info; set => customer.info = value; }
        [NotMapped]
        private List<OrderDetails> orderDetails = new List<OrderDetails>();
        [Required]
        public List<OrderDetails> OrderDetails { get => orderDetails; set { orderDetails = value.Distinct().ToList(); } }
        [NotMapped]
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
        public Order(Customer customer, params OrderDetails[] orderDetails)
        {
            this.customer = customer;
            foreach(OrderDetails orderDetail in orderDetails)
            {
                if (!this.orderDetails.Contains(orderDetail))
                {
                    this.orderDetails.Add(orderDetail);
                }
            }
        }
        public Order()
        {
            customer = new Customer();
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
