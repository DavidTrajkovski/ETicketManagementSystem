using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace TicketEShop.Domain.Identity
{
    public class ETicketAppUser : IdentityUser

    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
