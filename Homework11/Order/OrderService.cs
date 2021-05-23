using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Data.Entity;

namespace Order
{
    public class OrderService
    {
        public void AddOrder(Customer customer, params OrderDetails[] orderDetails)
        {
            Order order = new Order(customer, orderDetails);
            using (var context= new OrderContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
        public void AddOrder(Order order)
        {
            using (var context = new OrderContext())
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
        }
        public void DeleteOrder(int orderNo)
        {
            using (var context = new OrderContext())
            {
                var deleteOrder = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).FirstOrDefault(order => order.orderNo == orderNo);
                if (deleteOrder != null)
                {
                    for (int i = deleteOrder.OrderDetails.Count-1; i >=0; i--)
                    {
                        context.Commodities.Remove(deleteOrder.OrderDetails[i].goods);
                    }
                    context.OrderDetails.RemoveRange(deleteOrder.OrderDetails);
                    context.Customers.Remove(deleteOrder.customer);
                    context.Orders.Remove(deleteOrder);
                    context.SaveChanges();
                }
            }
        }
        public void EditOrder(int orderNo, Order newOrder)
        {
            using (var context = new OrderContext())
            {
                var oldOrder = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).FirstOrDefault(order => order.orderNo == orderNo);
                if (oldOrder != null)
                {
                    Customer deleteCustomer = oldOrder.customer;
                    List<OrderDetails> deleteOrderDetails = oldOrder.OrderDetails;
                    oldOrder.OrderDetails = newOrder.OrderDetails;
                    oldOrder.customer = newOrder.customer;
                    for (int i = deleteOrderDetails.Count - 1; i >= 0; i--)
                    {
                        context.Commodities.Remove(deleteOrderDetails[i].goods);
                    }
                    context.OrderDetails.RemoveRange(deleteOrderDetails);
                    context.Customers.Remove(deleteCustomer);
                    context.SaveChanges();
                }
            }
        }
        public List<Order> SelectOrder(int selectType, string selectParam)
        {
            switch (selectType)
            {
                case 1:
                    //订单号
                    using (var context = new OrderContext())
                    {
                        int orderno;
                        int.TryParse(selectParam, out orderno);
                        List<Order> selectedList = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).Where(order => order.orderNo == orderno).ToList();
                        selectedList.Sort();
                        return selectedList;
                    }
                case 2:
                    //商品名
                    using (var context = new OrderContext())
                    {
                        List<Order> selectedList = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).Where(order => order.OrderDetails.Any(orderDetail => orderDetail.goods.name == selectParam)).ToList();
                        selectedList.Sort();
                        return selectedList;
                    }
                case 3:
                    //客户名
                    using (var context = new OrderContext())
                    {
                        List<Order> selectedList = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).Where(order => order.customer.name == selectParam).ToList();
                        selectedList.Sort();
                        return selectedList;
                    }
                default:
                    return null;
            }
        }
        public void Export(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (var db = new OrderContext())
            {
                List<Order> orderList = db.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).ToList();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    xmlSerializer.Serialize(fs, orderList);
                }
            }
        }
        public void Import(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                List<Order> importList = (List<Order>)xmlSerializer.Deserialize(fs);
                for (int i = 0; i < importList.Count; i++)
                {
                    AddOrder(importList[i]);
                }
            }
        }
        public List<Order> GetAll()
        {
            using (var context = new OrderContext())
            {
                List<Order> orderList = context.Orders.Include(order => order.OrderDetails).Include(order => order.customer).Include(order => order.OrderDetails.Select(orderDetail => orderDetail.goods)).ToList();
                orderList.Sort();
                return orderList;
            }
        }
    }
}
