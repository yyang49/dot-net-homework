using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Homework12.Models;
using System.Text.Json;

namespace Homework12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext context;

        public OrderController(OrderContext context)
        {
            this.context = context;
        }

        //增加
        [HttpPost]
        public ActionResult<Order> AddOrder(string order)
        {
            try
            {
                Order newOrder=JsonSerializer.Deserialize<Order>(order);
                context.Orders.Add(newOrder);
                context.SaveChanges();
                return newOrder;
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        //删除
        [HttpDelete("{orderNo}")]
        public ActionResult<Order> DeleteOrder(int orderNo)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        //修改
        [HttpPut("{orderNo}")]
        public ActionResult<Order> PutOrder(int orderNo, string order)
        {
            try
            {
                var newOrder = JsonSerializer.Deserialize<Order>(order);
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
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }

        //订单号查询
        [HttpGet("{orderNo}")]
        public ActionResult<List<Order>> SelectByOrderNo(int orderNo)
        {
            List<Order> selectedList = context.Orders.Include(order => order.OrderDetails).ThenInclude(orderDetail => orderDetail.goods).Include(order => order.customer).Where(order => order.orderNo == orderNo).ToList();
            selectedList.Sort();
            return selectedList;
        }
    }
}