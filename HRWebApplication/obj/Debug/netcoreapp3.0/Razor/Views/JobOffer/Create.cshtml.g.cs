#pragma checksum "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c60b71cc8f813f42d3ee7800ce4765bdf54785e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_JobOffer_Create), @"mvc.1.0.view", @"/Views/JobOffer/Create.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\_ViewImports.cshtml"
using HRWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\_ViewImports.cshtml"
using HRWebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c60b71cc8f813f42d3ee7800ce4765bdf54785e1", @"/Views/JobOffer/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc13186f923734eef5f30550bd02d7d070938538", @"/Views/_ViewImports.cshtml")]
    public class Views_JobOffer_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CreateJobOfferViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"row page-box\">\r\n        <div class=\"col-sm-12\">\r\n            <h2>Now Job Offer</h2>\r\n");
#nullable restore
#line 9 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
             using (Html.BeginForm("Create", "JobOffer", Model, FormMethod.Post, null, null))
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 13 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 14 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.EditorFor(m => m.Title, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 15 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.Title, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 18 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.Company));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.DropDownListFor(m => m.CompanyId,
                        Model.Companies.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }),
                        new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 22 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.CompanyId, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 26 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.EditorFor(m => m.Location, new { htmlAttributes = new { @class = "form-control" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 27 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.Location, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.SalaryFrom, "Salary"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"input-group\">\r\n                        <span class=\"input-group-addon\">PLN</span>\r\n                        ");
#nullable restore
#line 33 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
                   Write(Html.EditorFor(m => m.SalaryFrom, new { htmlAttributes = new { @class = "form-control", placeholder = "From" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span class=\"input-group-addon\">.00</span>\r\n                    </div>\r\n                    ");
#nullable restore
#line 36 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.SalaryFrom, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 39 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.SalaryTo, "Salary"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"input-group\">\r\n                        <span class=\"input-group-addon\">PLN</span>\r\n                        ");
#nullable restore
#line 42 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
                   Write(Html.EditorFor(m => m.SalaryTo, new { htmlAttributes = new { @class = "form-control", placeholder = "To" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span class=\"input-group-addon\">.00</span>\r\n                    </div>\r\n                    ");
#nullable restore
#line 45 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.SalaryTo, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 48 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.ValidUntil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"input-group\">\r\n                        ");
#nullable restore
#line 50 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
                   Write(Html.EditorFor(m => m.ValidUntil, new { htmlAttributes = new { @class = "form-control", type = "Date" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <span class=\"input-group-addon\">\r\n                            <span class=\"glyphicon glyphicon-calendar\"></span>\r\n                        </span>\r\n                    </div>\r\n                    ");
#nullable restore
#line 55 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.ValidUntil, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 58 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 59 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control", placeholder = "Enter description" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    ");
#nullable restore
#line 60 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
               Write(Html.ValidationMessageFor(m => m.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <button type=\"submit\" class=\"btn btn-primary\">Create</button>\r\n                </div>\r\n");
#nullable restore
#line 65 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Views\JobOffer\Create.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateJobOfferViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
