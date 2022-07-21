using TicketEShop.Domain.DomainModels;
using ExcelDataReader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketEShop.Domain.Identity;

namespace EShopAdminApplication.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet("[action]")]
        public IActionResult ImportUsers()
        {
            return View();
        }

    }
}
