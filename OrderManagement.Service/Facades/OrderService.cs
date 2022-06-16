using OrderManagement.Core.Models;
using OrderManagement.Data.Repository;
using OrderManagement.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagement.Core.Entities;
using Mapster;

namespace OrderManagement.Service.Facades
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<List<OrderDto>> CreateOrder(OrderDto order)
        {
            var response = await _orderRepository.CreateOrder(order.Adapt<Order>());
            return response.Adapt<List<OrderDto>>();
        }

        public async Task<List<OrderDto>> DeleteOrderById(string orderId, string userId)
        {
            var response = await _orderRepository.DeleteOrderById(orderId, userId);
            return response.Adapt<List<OrderDto>>();
        }

        public async Task<OrderDto> GetOrderById(string orderId)
        {
            var response = await _orderRepository.GetOrderById(orderId);
            return response.Adapt<OrderDto>();
        }

        public async Task<List<OrderDto>> GetOrders(string userId)
        {
            var response = await _orderRepository.GetOrders(userId);
            return response.Adapt<List<OrderDto>>();
        }

        public async Task<List<OrderDto>> UpdateOrderById(OrderDto order)
        {
            var response = await _orderRepository.UpdateOrderById(order.Adapt<Order>());
            return response.Adapt<List<OrderDto>>();
        }
    }
}
