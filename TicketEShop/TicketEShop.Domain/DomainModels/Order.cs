using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public ETicketAppUser User { get; set; }

        public virtual ICollection<TicketInOrder> TicketInOrders { get; set; }
    }
}
