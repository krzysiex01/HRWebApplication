#pragma checksum "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "76f15839e343778a75ef34220802416daa71aef8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Company_Create), @"mvc.1.0.view", @"/Areas/Admin/Views/Company/Create.cshtml")]
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
#line 1 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using HRWebApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using HRWebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\_ViewImports.cshtml"
using HRWebApplication.Areas.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76f15839e343778a75ef34220802416daa71aef8", @"/Areas/Admin/Views/Company/Create.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"136e83c133af18f9d0d4dfb66f0d4fef515311a7", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Company_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Company>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("placeholder", new global::Microsoft.AspNetCore.Html.HtmlString("Enter full description"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12\">\r\n        <h2>Add new company</h2>\r\n");
#nullable restore
#line 9 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
         using (Html.BeginForm("Create", "Company", new { Area = "Admin" }))
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 13 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.LabelFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 14 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.EditorFor(m => m.Name, new { htmlAttributes = new { @class = "form-control", placeholder = "Full name of the company" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 15 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 18 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.LabelFor(m => m.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.EditorFor(m => m.Location, new { htmlAttributes = new { @class = "form-control", placeholder = "Location" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 20 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Location));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 23 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.LabelFor(m => m.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("textarea", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76f15839e343778a75ef34220802416daa71aef87360", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.TextAreaTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper);
#nullable restore
#line 24 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Description);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_TextAreaTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                ");
#nullable restore
#line 25 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
           Write(Html.ValidationMessageFor(m => m.Description, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Save</button>\r\n");
#nullable restore
#line 28 "C:\Users\Lenovo\source\repos\HR App\HR App\HRWebApplication\Areas\Admin\Views\Company\Create.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Company> Html { get; private set; }
    }
}
#pragma warning restore 1591
