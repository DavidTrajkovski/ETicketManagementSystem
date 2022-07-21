using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public ETicketAppUser Owner { get; set; }
        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
    }
}
