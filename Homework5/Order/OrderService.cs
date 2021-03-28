using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class OrderService
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
        public void SelectOrder(int selectType, string selectParam)
        {
            switch (selectType)
            {
                case 1:
                    //订单号
                    var orderQuery1 = from s in orderList where s.orderNo == int.Parse(selectParam) select s;
                    if (!orderQuery1.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery1)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 2:
                    //商品名
                    var orderQuery2 = from s in orderList from n in s.orderDetails where n.goods.name == selectParam select s;
                    if (!orderQuery2.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery2)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 3:
                    //客户名
                    var orderQuery3 = from s in orderList where s.customer.name == selectParam select s;
                    if (!orderQuery3.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery3)
                    {
                        Console.WriteLine(order);
                    }
                    break;
                case 4:
                    //金额
                    var orderQuery4 = from s in orderList where s.total == double.Parse(selectParam) select s;
                    if (!orderQuery4.Any())
                    {
                        Console.WriteLine("未找到订单\n");
                        break;
                    }
                    foreach (Order order in orderQuery4)
                    {
                        Console.WriteLine(order);
                    }
                    break;
            }
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
    }
}
