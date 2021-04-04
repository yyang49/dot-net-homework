using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Order
{
    public class OrderService
    {
        public List<Order> orderList = new List<Order>();
        public void AddOrder(int orderNo, Customer customer, params OrderDetails[] orderDetails)
        {
            Order order = new Order(orderNo, customer, orderDetails);
            if (!orderList.Contains(order))
            {
                orderList.Add(order);
            }
        }
        public void DeleteOrder(int orderNo)
        {
            var orderQuery = from s in orderList where s.orderNo == orderNo select s;
            Order deleteOrder = null;
            foreach (Order order in orderQuery)
            {
                deleteOrder = order;
            }
            int index = orderList.IndexOf(deleteOrder);
            if (index == -1)
            {
                throw new Exception("错误：订单不存在");
            }
            else
            {
                orderList.RemoveAt(index);
            }
        }
        public void EditOrder(int orderNo, Order newOrder)
        {
            var orderQuery = from s in orderList where s.orderNo == orderNo select s;
            Order oldOrder = null;
            foreach (Order order in orderQuery)
            {
                oldOrder = order;
            }
            int index = orderList.IndexOf(oldOrder);
            if (index == -1)
            {
                throw new Exception("错误：订单不存在");
            }
            else
            {
                orderList[index]=newOrder;
            }
        }
        public IEnumerable<Order> SelectOrder(int selectType, string selectParam)
        {
            IEnumerable<Order> orderQuery = null;
            switch (selectType)
            {
                case 1:
                    //订单号
                    orderQuery = from s in orderList where s.orderNo == int.Parse(selectParam) select s;
                    if (!orderQuery.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 2:
                    //商品名
                    orderQuery = from s in orderList from n in s.orderDetails where n.goods.name == selectParam select s;
                    if (!orderQuery.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 3:
                    //客户名
                    orderQuery = from s in orderList where s.customer.name == selectParam select s;
                    if (!orderQuery.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 4:
                    //金额
                    orderQuery = from s in orderList where s.total == double.Parse(selectParam) select s;
                    if (!orderQuery.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery)
                    {
                        Console.WriteLine(order);
                    }
                    break;
            }
            return orderQuery;
        }
        public void Sort()
        {
            orderList.Sort();
        }
        public void Sort(Comparison<Order> comparison)
        {
            orderList.Sort(comparison);
        }
        public void ShowOrder()
        {
            foreach (Order order in orderList)
            {
                Console.WriteLine(order);
            }
        }
        public void Export(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, orderList);
            }
        }
        public void Import(String path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                orderList = (List<Order>)xmlSerializer.Deserialize(fs);
            }
        }
    }
}
