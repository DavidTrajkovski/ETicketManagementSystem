using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;

namespace TicketEShop.Repository
{
    public class ApplicationDbContext : IdentityDbContext<ETicketAppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketInShoppingCart> TicketInShoppingCarts { get; set; }
        public virtual DbSet<EmailMessage> EmailMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<TicketInShoppingCart>()
                .HasKey(z => new { z.TicketId, z.ShoppingCartId });

            builder.Entity<TicketInShoppingCart>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.TicketInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartId);

            builder.Entity<TicketInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.TicketInShoppingCarts)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<ShoppingCart>()
                .HasOne<ETicketAppUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerId);

            builder.Entity<TicketInOrder>()
                .HasKey(z => new { z.TicketId, z.OrderId });

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.TicketInOrders)
                .HasForeignKey(z => z.TicketId);

            builder.Entity<TicketInOrder>()
                .HasOne(z => z.Order)
                .WithMany(z => z.TicketInOrders)
                .HasForeignKey(z => z.OrderId);
        }
    }
}
