﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicketEShop.Domain.DomainModels
{
    public class AddRoleModel
    {
        public string Username { get; set; }
        public List<string> usernames { get; set; }
        public List<string> roles { get; set; }
        public string SelectedRole { get; set; }
    }
}
