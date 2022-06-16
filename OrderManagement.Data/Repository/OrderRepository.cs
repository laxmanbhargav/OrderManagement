using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace OrderManagement.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderManagementContext _orderManagementContext;
        public OrderRepository(OrderManagementContext orderManagementContext)
        {
            _orderManagementContext = orderManagementContext;
        }
        public async Task<List<Order>> CreateOrder(Order order)
        {
            try
            {
                await _orderManagementContext.AddAsync(order);
                await _orderManagementContext.SaveChangesAsync();
                return await _orderManagementContext.Orders.Where(x => x.UserId.Equals(order.UserId)).ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Order> GetOrderById(string orderId)
        {
            var response = await _orderManagementContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(orderId)));
            return response;
        }

        public async Task<List<Order>> GetOrders(string userId)
        {
            var response = await _orderManagementContext.Orders.Where(x => x.UserId.Equals(Guid.Parse(userId))).ToListAsync();
            return response;
        }


        public async Task<List<Order>> DeleteOrderById(string orderId, string userId)
        {
            var response = await _orderManagementContext.Orders.FirstOrDefaultAsync(x => x.Id.Equals(Guid.Parse(orderId)));
            if (response != null)
            {
                _orderManagementContext.Orders.Remove(response);
                await _orderManagementContext.SaveChangesAsync();
            }
            return await _orderManagementContext.Orders.Where(x => x.UserId.Equals(Guid.Parse(userId))).ToListAsync();
        }

        public async Task<List<Order>> UpdateOrderById(Order order)
        {
            try
            {
                _orderManagementContext.Orders.Update(order);
                await _orderManagementContext.SaveChangesAsync();
                return await _orderManagementContext.Orders.Where(x => x.UserId.Equals(order.UserId)).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
