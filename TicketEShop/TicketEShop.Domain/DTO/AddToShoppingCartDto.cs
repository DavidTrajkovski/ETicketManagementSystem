using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.DomainModels;

namespace TicketEShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Ticket SelectedTicket { get; set; }
        public Guid SelectedTicketId { get; set; }
        public int Quantity { get; set; }
    }
}
