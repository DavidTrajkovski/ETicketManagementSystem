#pragma checksum "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbe9f3baf922321fde4fb6ab4b1b304796a6bdc8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Details), @"mvc.1.0.view", @"/Views/Order/Details.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\_ViewImports.cshtml"
using TicketEShop.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\_ViewImports.cshtml"
using TicketEShop.Domain.DomainModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbe9f3baf922321fde4fb6ab4b1b304796a6bdc8", @"/Views/Order/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0f91fa64d9f3ec85c8e182208e4a61c7447c7c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketEShop.Domain.DomainModels.Order>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n\n");
            WriteLiteral("\n<div class=\"container\">\n\n    <p>\n        <a class=\"btn btn-warning\">");
#nullable restore
#line 13 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                              Write(Model.User.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral(" - ");
#nullable restore
#line 13 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                  Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 13 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                                        Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n    </p>\n\n");
#nullable restore
#line 16 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
     for (int i = 0; i < Model.TicketInOrders.Count(); i++)
    {
        var item = Model.TicketInOrders.ElementAt(i);

        if (i % 3 == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("<div class=\"row\">\n");
#nullable restore
#line 23 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
            }


#line default
#line hidden
#nullable disable
            WriteLiteral("                  <div class=\"col-md-3 m-4\">\n                      <div class=\"card\" style=\"width: 15rem; height: 25rem;\">\n                          <div class=\"card-header\">\n                              <h3>");
#nullable restore
#line 28 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                             Write(item.Ticket.MovieName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n                          </div>\n\n                          <div class=\"card-body\">\n                              <h4 class=\"card-title\">Date: ");
#nullable restore
#line 32 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                      Write(item.Ticket.DatePremiere);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n                              <p class=\"card-text\">Time: ");
#nullable restore
#line 33 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                    Write(item.Ticket.TimePremiere);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                              <p class=\"card-text\">Seat: ");
#nullable restore
#line 34 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                    Write(item.Ticket.SeatNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                              <p class=\"card-text\">Genre: ");
#nullable restore
#line 35 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                     Write(item.Ticket.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n                              <h6 class=\"pt-3\">Price: $");
#nullable restore
#line 37 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                                  Write(item.Ticket.TicketPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                              <h6>Quantity: ");
#nullable restore
#line 38 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                              <h6>Total: $");
#nullable restore
#line 39 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
                                      Write(item.Ticket.TicketPrice * item.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\n                          </div>\n                      </div>\n                  </div>\n");
#nullable restore
#line 43 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"


            if (i % 3 == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\n");
#nullable restore
#line 48 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Order\Details.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicketEShop.Domain.DomainModels.Order> Html { get; private set; }
    }
}
#pragma warning restore 1591
