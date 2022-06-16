using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Core.Entities;

namespace OrderManagement.Data.Repository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders(string userId);

        Task<Order> GetOrderById(string orderId);

        Task<List<Order>> DeleteOrderById(string orderId,string userId);

        Task<List<Order>> UpdateOrderById(Order order);

        Task<List<Order>> CreateOrder(Order order);

    }
}
