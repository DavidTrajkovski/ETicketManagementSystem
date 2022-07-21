using TicketEShop.Domain;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Domain.Identity;
using TicketEShop.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;

namespace TicketEShop.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ETicketAppUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminController(IOrderService orderService, UserManager<ETicketAppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _orderService = orderService;
            _userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet("[action]")]
        public List<Order> GetOrders()
        {
            var result = _orderService.getAllOrders();
            return result;
        }

        [HttpPost("[action]")]
        public Order GetDetailsForOrder(BaseEntity model)
        {
            var result = _orderService.getOrderDetails(model);
            return result;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> ImportAllUsers(IFormFile file)
        {
            //make a copy to upload the file in the desired directory folder, dva pati \ za escape
            string pathToUpload = $"{Directory.GetCurrentDirectory()}\\files\\{file.FileName}";

            //zapis na sodrzina od file vo taa pateka i flush posle
            using (FileStream fileStream = System.IO.File.Create(pathToUpload))
            {
                file.CopyTo(fileStream);

                fileStream.Flush();
            }

            //read data from uploaded file

            List<ETicketAppUser> users = getUsersFromExcelFile(file.FileName);

            bool status = true;
            string[] roleNames = { "Regular" };

            foreach (var item in users)
            {
                var userCheck = _userManager.FindByEmailAsync(item.Email).Result;
                if (userCheck == null)
                {
                    var user = new ETicketAppUser
                    {
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        UserName = item.Email,
                        NormalizedUserName = item.Email,
                        Email = item.Email,
                        Password = item.Password,
                        Role = item.Role,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        PhoneNumber = item.PhoneNumber,
                        UserCart = new ShoppingCart()
                    };

                    var roleExist = await roleManager.RoleExistsAsync(item.Role);
                    if (!roleExist)
                    {
                        await roleManager.CreateAsync(new IdentityRole(item.Role));
                    }

                    var result = _userManager.CreateAsync(user, item.Password).Result;
                    await _userManager.AddToRoleAsync(user, item.Role);

                    status = status & result.Succeeded;
                }
                else
                {
                    continue;
                }
            }

            return RedirectToAction("Index", "Order");
        }

        //od excel da se zeme lista na users
        private List<ETicketAppUser> getUsersFromExcelFile(string fileName)
        {
            //pateka da se zeme
            string pathToFile = $"{Directory.GetCurrentDirectory()}\\files\\{fileName}";

            //encoder da se instancira
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            List<ETicketAppUser> userList = new List<ETicketAppUser>();

            //citanje na podatoci
            using (var stream = System.IO.File.Open(pathToFile, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        userList.Add(new ETicketAppUser
                        {
                            Email = reader.GetValue(0).ToString(),
                            Password = reader.GetValue(1).ToString(),
                            Role = reader.GetValue(2).ToString()
                        });
                    }
                }
            }
            //se cita po redovi, getValue(1) da se zeme vrednost od prva kolona
            return userList;

        }

    }
}
