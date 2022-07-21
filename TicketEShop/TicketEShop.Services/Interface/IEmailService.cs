using TicketEShop.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TicketEShop.Service.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(List<EmailMessage> allMails);
    }
}
