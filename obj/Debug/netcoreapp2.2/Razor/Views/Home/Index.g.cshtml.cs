#pragma checksum "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "952348f6f2fda75d4595b291cdc621310a58751e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\_ViewImports.cshtml"
using PortalWebCliente;

#line default
#line hidden
#line 2 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\_ViewImports.cshtml"
using PortalWebCliente.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"952348f6f2fda75d4595b291cdc621310a58751e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b7db8ae182dab00c0ee18eda59166f764a62cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<PortalWebCliente.Models.ProjectModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/operation-history-icon.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("40px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin:0 2%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 498, true);
            WriteLiteral(@"
<div class=""portlet light portlet-fit "">
    <div class=""portlet-title"">
        <div class=""caption"">
            <span class=""caption-subject font-black bold uppercase"" style=""font-size:150%;"">LISTADO DE OPERACIONES</span>
        </div>
    </div>
    <div class=""portlet-body"" style=""padding:2px"">
        <div class=""mt-element-list"">
            <div class=""mt-list-container list-default""
                 style=""padding:5px"">
                <ul style=""margin:0%;padding:0%;"">
");
            EndContext();
#line 14 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\Home\Index.cshtml"
                     foreach (ProjectModel item in Model)
                    {

#line default
#line hidden
            BeginContext(631, 122, true);
            WriteLiteral("                        <li class=\"mt-list-item\"style=\"margin:0;padding:2% 0;display:flex;\">\r\n                            ");
            EndContext();
            BeginContext(753, 93, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "952348f6f2fda75d4595b291cdc621310a58751e5649", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(846, 210, true);
            WriteLiteral("\r\n                            <div class=\"list-item-content\" style=\"padding:0;float:left;margin:auto 0 0 0;\">\r\n                                <h3 class=\"uppercase bold\">\r\n                                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1056, "\"", 1079, 2);
            WriteAttributeValue("", 1063, "/Home/", 1063, 6, true);
#line 20 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\Home\Index.cshtml"
WriteAttributeValue("", 1069, item.name, 1069, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1080, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1082, 9, false);
#line 20 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\Home\Index.cshtml"
                                                          Write(item.name);

#line default
#line hidden
            EndContext();
            BeginContext(1091, 112, true);
            WriteLiteral("</a>\r\n                                </h3>\r\n                            </div>\r\n                        </li>\r\n");
            EndContext();
#line 24 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalwebclientes\Views\Home\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1226, 77, true);
            WriteLiteral("                </ul>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<PortalWebCliente.Models.ProjectModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
