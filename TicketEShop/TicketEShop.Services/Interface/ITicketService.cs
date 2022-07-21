using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace TicketEShop.Service.Interface
{
    public interface ITicketService
    {
        List<Ticket> GetAllTickets();
        List<Ticket> GetAllTicketsWithGenre(string Genre);
        List<Ticket> GetAllTicketsByDate(DateTime date);
        Ticket GetDetailsForTicket(Guid? id);
        void CreateNewTicket(Ticket t);
        void UpdateExistingTicket(Ticket t);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteTicket(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
