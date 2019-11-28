#pragma checksum "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf646aadcd344fc7bcf496d8f3efe15da3067eb9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_HRUser_Views_JobApplication__JobApplicationList), @"mvc.1.0.view", @"/Areas/HRUser/Views/JobApplication/_JobApplicationList.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\_ViewImports.cshtml"
using HRWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\_ViewImports.cshtml"
using HRWebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\_ViewImports.cshtml"
using HRWebApplication.Areas.HRUser;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf646aadcd344fc7bcf496d8f3efe15da3067eb9", @"/Areas/HRUser/Views/JobApplication/_JobApplicationList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3d8559be2de8ff119321796a53dc477b99fb99af", @"/Areas/HRUser/Views/_ViewImports.cshtml")]
    public class Areas_HRUser_Views_JobApplication__JobApplicationList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<JobApplication>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""col-sm-12"">
    <table class=""table table-striped table-hover"" id=""JobApplications"">
        <thead class=""thead-dark"">
            <tr>
                <th scope=""col"">Full Name</th>
                <th scope=""col"">E-mail</th>
                <th scope=""col"">Phone</th>
                <th scope=""col"">Id</th>
                <th scope=""col"">Offer Id</th>
                <th scope=""col"">Actions</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 16 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
             foreach (JobApplication jobApplication in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <th scope=\"col\">");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                           Write(jobApplication.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                                                     Write(jobApplication.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 20 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                           Write(jobApplication.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 21 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                           Write(jobApplication.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 22 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                           Write(jobApplication.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                <th scope=\"col\">");
#nullable restore
#line 23 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                           Write(jobApplication.JobOfferId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</th>
                <th scope=""col"">
                    <div class=""btn-group"" role=""group"" aria-label=""Actions"">
                        <button type=""button"" class=""btn btn-outline-success""><i class=""fas fa-check-circle""></i></button>
                        <button type=""button"" class=""btn btn-outline-danger""><i class=""fas fa-times-circle""></i></button>
                        <button type=""button"" class=""btn btn-outline-primary""><i class=""fas fa-arrow-circle-right""></i></button>
                        <div class=""btn-group"" role=""group"">
                            <button");
            BeginWriteAttribute("id", " id=\"", 1537, "\"", 1565, 2);
            WriteAttributeValue("", 1542, "drop_", 1542, 5, true);
#nullable restore
#line 30 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
WriteAttributeValue("", 1547, jobApplication.Id, 1547, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" type=""button"" class=""btn btn-outline-secondary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                <i class=""fas fa-chevron-circle-down""></i>
                            </button>
                            <div class=""dropdown-menu""");
            BeginWriteAttribute("aria-labelledby", " aria-labelledby=\"", 1868, "\"", 1909, 2);
            WriteAttributeValue("", 1886, "drop_", 1886, 5, true);
#nullable restore
#line 33 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
WriteAttributeValue("", 1891, jobApplication.Id, 1891, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                                <a class=""dropdown-item"" href=""#""><i class=""fas fa-edit""></i> Edit</a>
                                <a class=""dropdown-item"" href=""#""><i class=""fas fa-file-download""></i> Download CV</a>
                                <div class=""dropdown-divider""></div>
                                <a class=""dropdown-item"" href=""#""><i class=""fas fa-trash-alt""></i> Remove</a>
                            </div>
                        </div>
                    </div>
                </th>
            </tr>
");
#nullable restore
#line 43 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<nav aria-label=\"Page navigation\">\r\n    <ul class=\"pagination justify-content-center\">\r\n");
#nullable restore
#line 50 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
         for (int i = 1; i <= @ViewBag.PagesCount; i++)
        {
            if (@ViewBag.CurrentPage == i)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item  active\">\r\n                    <a class=\"page-link\">");
#nullable restore
#line 55 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                                    Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                </li>\r\n");
#nullable restore
#line 57 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"page-item\">\r\n                    <a class=\"page-link\" href=\"#\"");
            BeginWriteAttribute("onclick", "\r\n                       onclick=\"", 2985, "\"", 3219, 5);
            WriteAttributeValue("", 3019, "getJobApplicationsList(\'", 3019, 24, true);
#nullable restore
#line 62 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
WriteAttributeValue("", 3043, Url.Action("GetJobApplications", "JobApplication", new { Area = "HRUser", sortOrder = ViewBag.CurrentSort, currentFilter = ViewBag.CurrentFilter, page = i}), 3043, 159, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3202, "\');", 3202, 3, true);
            WriteAttributeValue(" ", 3205, "return", 3206, 7, true);
            WriteAttributeValue(" ", 3212, "false;", 3213, 7, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
#nullable restore
#line 63 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
                   Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 66 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\HRUser\Views\JobApplication\_JobApplicationList.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</nav>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<JobApplication>> Html { get; private set; }
    }
}
#pragma warning restore 1591
