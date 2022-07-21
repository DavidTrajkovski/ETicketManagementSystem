using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketEShop.Service.Interface
{
    public interface IOrderService
    {
        public List<Order> getAllOrders();
        public Order getOrderDetails(BaseEntity model);
    }
}
