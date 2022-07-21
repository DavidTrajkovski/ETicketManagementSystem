using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Repository.Interface;
using TicketEShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketEShop.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Order> getAllOrders()
        {
            return _orderRepository.getAllOrders();
        }

        public Order getOrderDetails(BaseEntity model)
        {
            return _orderRepository.getOrderDetails(model);
        }
    }
}
