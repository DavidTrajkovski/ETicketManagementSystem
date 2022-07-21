using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TicketEShop.Repository;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Domain.Identity;
using TicketEShop.Domain.Relations;
using TicketEShop.Service.Interface;
using Stripe;

namespace TicketEShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(_shoppingCartService.getShoppingCartInfo(userId));
        }

        public IActionResult DeleteFromShoppingCart(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.deleteTicketFromSoppingCart(userId, id);

            if (result)
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
            else
            {
                return RedirectToAction("Index", "ShoppingCart");
            }
        }

        public Boolean Order()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _shoppingCartService.order(userId);

            return result;
        }

        public IActionResult PayOrder(string stripeEmail, string stripeToken)
        {
            var customerService = new CustomerService();
            var chargeService = new ChargeService();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var order = _shoppingCartService.getShoppingCartInfo(userId);

            var customer = customerService.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = chargeService.Create(new ChargeCreateOptions
            {
                Amount = (Convert.ToInt32(order.TotalPrice) * 100),
                Description = "TicketEShop Application Payment",
                Currency = "usd",
                Customer = customer.Id
            });

            if (charge.Status == "succeeded")
            {
                var result = this.Order();

                if (result)
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
                else
                {
                    return RedirectToAction("Index", "ShoppingCart");
                }
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
