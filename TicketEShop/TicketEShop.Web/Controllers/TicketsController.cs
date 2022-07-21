using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketEShop.Repository;
using TicketEShop.Domain.DomainModels;
using TicketEShop.Domain.DTO;
using TicketEShop.Domain.Relations;
using TicketEShop.Service.Interface;
using ClosedXML.Excel;
using System.IO;

namespace TicketEShop.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            return View(this._ticketService.GetAllTickets());
        }

        // GET: Tickets
        [HttpPost]
        public IActionResult Index(DateTime FilterDate)
        {
            if (FilterDate == null || FilterDate.Equals(new DateTime()))
            {
                return View(_ticketService.GetAllTickets());
            }
            else
            {
                return View(_ticketService.GetAllTicketsByDate(FilterDate));
            }

        }

        public ActionResult AddTicketToCart(Guid? id)
        {
            /*            var ticket = await _context.Tickets.Where(z => z.Id.Equals(id)).FirstOrDefaultAsync();
                        AddToShoppingCartDto model = new AddToShoppingCartDto
                        {
                            SelectedTicket = ticket,
                            SelectedTicketId = ticket.Id,
                            Quantity = 1
                        };
                        return View(model);*/
            var result = _ticketService.GetShoppingCartInfo(id);

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTicketToCart(AddToShoppingCartDto item)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = _ticketService.AddToShoppingCart(item, userId);

            if (result)
            {
                return RedirectToAction("Index", "Tickets");
            }
            return View(item);
        }


        [HttpPost]
        public FileContentResult ExportTickets(string Genre)
        {
           
            string fileName = "Tickets.xlsx";
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            List<Ticket> tickets = new List<Ticket>();

            if (Genre is null || Genre.Length == 0 || Genre.Equals(""))
            {
                tickets = _ticketService.GetAllTickets();
            }
            else
            {
                tickets = _ticketService.GetAllTicketsWithGenre(Genre);
            }

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add("All Tickets");
                worksheet.Cell(1, 1).Value = "Movie";
                worksheet.Cell(1, 2).Value = "Genre";
                worksheet.Cell(1, 3).Value = "Date";
                worksheet.Cell(1, 4).Value = "Time";
                worksheet.Cell(1, 5).Value = "Price";
                worksheet.Cell(1, 6).Value = "Seat";

                for (int i = 1; i <= tickets.Count(); i++)
                {
                    var item = tickets[i - 1];

                    worksheet.Cell(i + 1, 1).Value = item.MovieName.ToString();
                    worksheet.Cell(i + 1, 2).Value = item.Genre.ToString();
                    worksheet.Cell(i + 1, 3).Value = item.DatePremiere.ToShortDateString().ToString();
                    worksheet.Cell(i + 1, 4).Value = item.TimePremiere.ToString();
                    worksheet.Cell(i + 1, 5).Value = item.TicketPrice.ToString();
                    worksheet.Cell(i + 1, 6).Value = item.SeatNumber.ToString();
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }

            }
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,MovieName,TicketPrice,DatePremiere,TimePremiere,SeatNumber,Genre")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                _ticketService.CreateNewTicket(ticket);
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id);

            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Id,MovieName,TicketPrice,DatePremiere,TimePremiere,SeatNumber,Genre")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.UpdateExistingTicket(ticket);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = _ticketService.GetDetailsForTicket(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _ticketService.DeleteTicket(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _ticketService.GetDetailsForTicket(id) != null;
        }
    }
}
