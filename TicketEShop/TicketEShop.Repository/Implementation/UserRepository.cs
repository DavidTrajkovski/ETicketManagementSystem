﻿using TicketEShop.Domain.Identity;
using TicketEShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicketEShop.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ETicketAppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ETicketAppUser>();
        }
        public IEnumerable<ETicketAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public ETicketAppUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.TicketInShoppingCarts")
               .Include("UserCart.TicketInShoppingCarts.Ticket")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(ETicketAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(ETicketAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(ETicketAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
