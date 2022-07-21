using ClosedXML.Excel;
using GemBox.Document;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TicketEShop.Domain.DomainModels;

namespace EShopAdminApplication.Controllers
{
    public class OrderController : Controller
    {

        public OrderController()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44376/api/Admin/GetOrders";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var result = response.Content.ReadAsAsync<List<Order>>().Result;

            return View(result);
        }

        public IActionResult Details(Guid id)
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44376/api/Admin/GetDetailsForOrder";

            var model = new
            {
                Id = id
            };


            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");


            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Order>().Result;

            return View(result);
        }

        //so pdf
        public IActionResult CreateInvoice(Guid id)
        {
            HttpClient client = new HttpClient();

            string URL = "https://localhost:44376/api/Admin/GetDetailsForOrder";

            var model = new
            {
                Id = id
            };

            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Order>().Result;
            //zemi rezultat od toj response dobien

            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Invoice.docx");
            //zemi pateka od word template dokument koj e popolnet so polinja koi treba da bidat zameneti so vistinski podatoci

            var document = DocumentModel.Load(templatePath);
            //vcitaj dokument od taa pateka

            //pristapi do sodrzina na dokumentot i zameni gi tie delovi so result
            document.Content.Replace("{{OrderNumber}}", result.Id.ToString());
            document.Content.Replace("{{UserName}}", result.User.Email);

            StringBuilder sb = new StringBuilder();

            var total = 0.0;
            //da dobieme za sekoj produkt so negova kolicina vkupno i posle total
            foreach (var item in result.TicketInOrders)
            {
                total += item.Quantity * item.Ticket.TicketPrice;
                sb.AppendLine(item.Ticket.MovieName + " with quantity of: " + item.Quantity + " and price of: $" + item.Ticket.TicketPrice);
            }

            document.Content.Replace("{{TicketList}}", sb.ToString());
            document.Content.Replace("{{TotalPrice}}", "$" + total.ToString());

            var stream = new MemoryStream();
            //kreiran na stream preku koj bi gi pratile ovie podatoci

            document.Save(stream, new PdfSaveOptions());
            //zacuvuanje na dokumentot kako pdf

            //return so stream, contentType i ime na pdf
            return File(stream.ToArray(), new PdfSaveOptions().ContentType, "ExportInvoice.pdf");
        }
        //za da se zacuva kako word dokument namesto PdfSaveOptions() imame DocxSaveOptions()


        //export vo excel
        public FileContentResult ExportAllOrders(Guid id)
        {
            HttpClient client = new HttpClient(); //klient

            string URL = "https://localhost:44376/api/Admin/GetOrders"; //url

            HttpResponseMessage response = client.GetAsync(URL).Result; //response

            var result = response.Content.ReadAsAsync<List<Order>>().Result; //result so site orders

            string fileName = "Orders.xlsx"; //ime na excel file i content
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            using (var workBook = new XLWorkbook()) //popolnuvanje na kolona
            {   //naslov na ova
                IXLWorksheet worksheet = workBook.Worksheets.Add("All Orders");

                //se dodava vo kjelija (1,1) site informacii i ovie se kako header
                worksheet.Cell(1, 1).Value = "Order Id";
                worksheet.Cell(1, 2).Value = "Customer Name";
                worksheet.Cell(1, 3).Value = "Customer Last Name";
                worksheet.Cell(1, 4).Value = "Customer Email";

                //vnesuvanje na informacii za sekoja naracka zaedno so produkti
                for (int i = 1; i <= result.Count(); i++)
                {
                    var item = result[i - 1];

                    worksheet.Cell(i + 1, 1).Value = item.Id.ToString();
                    worksheet.Cell(i + 1, 2).Value = item.User.FirstName;
                    worksheet.Cell(i + 1, 3).Value = item.User.LastName;
                    worksheet.Cell(i + 1, 4).Value = item.User.Email;

                    for (int t = 1; t <= item.TicketInOrders.Count(); t++)
                    {
                        worksheet.Cell(1, t + 4).Value = "Ticket -" + (t + 1);
                        worksheet.Cell(i + 1, t + 4).Value = item.TicketInOrders.ElementAt(t - 1).Ticket.MovieName;
                    }

                }

                //zacuvuvanje na file vo streamot 
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(content, contentType, fileName);
                }
            }

        }
    }
}
