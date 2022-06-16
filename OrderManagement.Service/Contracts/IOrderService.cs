using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Core.Models;

namespace OrderManagement.Service.Contracts
{
    public  interface IOrderService
    {
        Task<List<OrderDto>> GetOrders(string userId);

        Task<OrderDto> GetOrderById(string orderId);

        Task<List<OrderDto>> DeleteOrderById(string orderId,string userId);

        Task<List<OrderDto>> UpdateOrderById(OrderDto order);

        Task<List<OrderDto>> CreateOrder(OrderDto order);
    }
}
