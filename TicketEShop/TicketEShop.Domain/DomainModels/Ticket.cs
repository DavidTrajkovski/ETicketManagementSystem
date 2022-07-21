using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TicketEShop.Domain.Enums;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Domain.DomainModels
{
    public class Ticket : BaseEntity
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        [Range(0,10000)]
        public int TicketPrice { get; set; }
        [Required]
        [Display(Name = "DatePremiere")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DatePremiere { get; set; }
        [Required]
        [Display(Name = "TimePremiere")]
        [DisplayFormat(DataFormatString = "{hh:mm}")]
        [DataType(DataType.Time)]
        public string TimePremiere { get; set; }
        [Required]
        [Range(0, 10000)]
        public int SeatNumber { get; set; }
        [Required]
        public string Genre { get; set; }

        public virtual ICollection<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public virtual ICollection<TicketInOrder> TicketInOrders { get; set; }
    }
}
