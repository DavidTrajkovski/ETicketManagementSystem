#pragma checksum "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Account\AddRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "426a5b495f90da988afff475ca150ef817e78db2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_AddRole), @"mvc.1.0.view", @"/Views/Account/AddRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"426a5b495f90da988afff475ca150ef817e78db2", @"/Views/Account/AddRole.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0f91fa64d9f3ec85c8e182208e4a61c7447c7c8", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_AddRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TicketEShop.Domain.DomainModels.AddRoleModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Account\AddRole.cshtml"
 using (Html.BeginForm("AddRole", "Account"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group w-50\">\r\n        ");
#nullable restore
#line 7 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Account\AddRole.cshtml"
   Write(Html.DropDownListFor(x => x.Username, new SelectList(Model.usernames), new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"form-group w-50\">\r\n        ");
#nullable restore
#line 10 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Account\AddRole.cshtml"
   Write(Html.DropDownListFor(x => x.SelectedRole, new SelectList(Model.roles), new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <button type=\"submit\" class=\"btn btn-outline-secondary\">Save</button>\r\n");
#nullable restore
#line 13 "C:\Users\david\source\repos\CinemaTicketsApp\TicketEShop\TicketEShop.Web\Views\Account\AddRole.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TicketEShop.Domain.DomainModels.AddRoleModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
