using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                OrderService orderService = new OrderService();
                orderService.AddOrder(5, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1001", "商品1", 10), 3), new OrderDetails(new Commodity("1002", "商品2", 20), 1));
                orderService.AddOrder(3, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1001", "商品1", 10), 2), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
                orderService.AddOrder(1, new Customer("客户1", "666-6666"), new OrderDetails(new Commodity("1004", "商品4", 40), 1), new OrderDetails(new Commodity("1005", "商品5", 50), 4));
                orderService.AddOrder(2, new Customer("客户3", "888-8888"), new OrderDetails(new Commodity("1002", "商品2", 20), 2), new OrderDetails(new Commodity("1006", "商品6", 60), 3));
                orderService.AddOrder(4, new Customer("客户2", "777-7777"), new OrderDetails(new Commodity("1002", "商品2", 20), 1), new OrderDetails(new Commodity("1003", "商品3", 30), 2));
                orderService.ShowOrder();
                orderService.Sort();
                orderService.ShowOrder();
                orderService.DeleteOrder(1);
                orderService.ShowOrder();
                orderService.SelectOrder(1, "1");
                orderService.SelectOrder(1, "3");
                orderService.SelectOrder(2, "商品2");
                orderService.SelectOrder(3, "客户3");
                orderService.SelectOrder(4, "50");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
