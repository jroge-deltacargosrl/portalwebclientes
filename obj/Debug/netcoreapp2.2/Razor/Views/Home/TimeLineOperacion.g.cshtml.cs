#pragma checksum "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ec8214e8c1f9264ae6aa1e844c4c8d6a57c1bf33"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TimeLineOperacion), @"mvc.1.0.view", @"/Views/Home/TimeLineOperacion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TimeLineOperacion.cshtml", typeof(AspNetCore.Views_Home_TimeLineOperacion))]
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
#line 1 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\_ViewImports.cshtml"
using PortalWebCliente;

#line default
#line hidden
#line 2 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\_ViewImports.cshtml"
using PortalWebCliente.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ec8214e8c1f9264ae6aa1e844c4c8d6a57c1bf33", @"/Views/Home/TimeLineOperacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b7db8ae182dab00c0ee18eda59166f764a62cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TimeLineOperacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PortalWebCliente.Models.ProyectoModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("now"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/camionDelta.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(0, 129, true);
            WriteLiteral("<!--row y col-lg-4 en bootstrap.min-->\r\n<div class=\"row\">\r\n    <div class=\"col-lg-4\">\r\n        <div class=\"container-timeline\">\r\n");
            EndContext();
            BeginContext(188, 36, true);
            WriteLiteral("            <!-- BEGIN CONTENT -->\r\n");
            EndContext();
#line 7 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
              
                int distanciaPorEtapa = 200, porcentajePorEtapa = 820 / 4;
                int c = 1, cantidadTareasTerminadasDeLaEtapaAnterior = 0,
                caminoRecorrido, caminoFaltante, porcentajeRecorrido = 0;
                string state, canUpload;
            

#line default
#line hidden
            BeginContext(523, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 13 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
             if (Model.stages.Count == 5)
            {
                distanciaPorEtapa = 160; porcentajePorEtapa = 820 / 5;
            }

#line default
#line hidden
            BeginContext(668, 41, true);
            WriteLiteral("            <h2 class=\"titulo-operacion\">");
            EndContext();
            BeginContext(710, 10, false);
#line 17 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                    Write(Model.name);

#line default
#line hidden
            EndContext();
            BeginContext(720, 277, true);
            WriteLiteral(@"</h2>
            <div class=""Timeline"">
                <svg height=""5"" width=""0"">
                    <line x1=""0"" y1=""0"" x2=""0"" y2=""0"" style=""stroke:#ec9404;stroke-width:5"" />
                    Sorry, your browser does not support inline SVG.
                </svg>
");
            EndContext();
#line 23 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                 for (int i = 0; i < Model.stages.Count; i++)
                {
                    

#line default
#line hidden
#line 25 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                     if (c == 1)
                    {

#line default
#line hidden
            BeginContext(1136, 268, true);
            WriteLiteral(@"                        <svg height=""5"" width=""150"">
                            <line x1=""0"" y1=""0"" x2=""0"" y2=""0"" style=""stroke:#ec9404;stroke-width:5"" />
                            Sorry, your browser does not support inline SVG.
                        </svg>
");
            EndContext();
#line 31 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                    }
                    else
                    {
                        

#line default
#line hidden
#line 34 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                         if (cantidadTareasTerminadasDeLaEtapaAnterior ==
     Model.stages.ElementAt(i - 1).tasks.Count)
                        {
                            porcentajeRecorrido += porcentajePorEtapa;

#line default
#line hidden
            BeginContext(1699, 43, true);
            WriteLiteral("                            <svg height=\"5\"");
            EndContext();
            BeginWriteAttribute("width", " width=\"", 1742, "\"", 1768, 1);
#line 38 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 1750, distanciaPorEtapa, 1750, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1769, 54, true);
            WriteLiteral(">\r\n                                <line x1=\"0\" y1=\"0\"");
            EndContext();
            BeginWriteAttribute("x2", " x2=\"", 1823, "\"", 1846, 1);
#line 39 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 1828, distanciaPorEtapa, 1828, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1847, 168, true);
            WriteLiteral(" y2=\"0\" style=\"stroke:#ec9404;stroke-width:5\" />\r\n                                Sorry, your browser does not support inline SVG.\r\n                            </svg>\r\n");
            EndContext();
#line 42 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                        }
                        else
                        {
                            caminoRecorrido = (distanciaPorEtapa / Model.stages.ElementAt(i - 1).tasks.Count) *
                            cantidadTareasTerminadasDeLaEtapaAnterior;
                            caminoFaltante = distanciaPorEtapa - caminoRecorrido;

#line default
#line hidden
            BeginContext(2367, 43, true);
            WriteLiteral("                            <svg height=\"5\"");
            EndContext();
            BeginWriteAttribute("width", " width=\"", 2410, "\"", 2434, 1);
#line 48 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 2418, caminoRecorrido, 2418, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2435, 54, true);
            WriteLiteral(">\r\n                                <line x1=\"0\" y1=\"0\"");
            EndContext();
            BeginWriteAttribute("x2", " x2=\"", 2489, "\"", 2510, 1);
#line 49 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 2494, caminoRecorrido, 2494, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2511, 211, true);
            WriteLiteral(" y2=\"0\" style=\"stroke:#ec9404;stroke-width:5\" />\r\n                                Sorry, your browser does not support inline SVG.\r\n                            </svg>\r\n                            <svg height=\"5\"");
            EndContext();
            BeginWriteAttribute("width", " width=\"", 2722, "\"", 2745, 1);
#line 52 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 2730, caminoFaltante, 2730, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2746, 54, true);
            WriteLiteral(">\r\n                                <line x1=\"0\" y1=\"0\"");
            EndContext();
            BeginWriteAttribute("x2", " x2=\"", 2800, "\"", 2820, 1);
#line 53 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 2805, caminoFaltante, 2805, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2821, 165, true);
            WriteLiteral(" y2=\"0\" style=\"stroke:gray;stroke-width:5\" />\r\n                                Sorry, your browser does not support inline SVG.\r\n                            </svg>\r\n");
            EndContext();
#line 56 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                            porcentajeRecorrido += (porcentajePorEtapa / Model.stages.ElementAt(i - 1).tasks.Count) *
                            cantidadTareasTerminadasDeLaEtapaAnterior;
                        }

#line default
#line hidden
#line 58 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                         
                    }

#line default
#line hidden
            BeginContext(3227, 132, true);
            WriteLiteral("                    <div class=\"event2\">\r\n                        <div class=\"event2Bubble\">\r\n                            <label><b>");
            EndContext();
            BeginContext(3360, 30, false);
#line 62 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                 Write(Model.stages.ElementAt(i).name);

#line default
#line hidden
            EndContext();
            BeginContext(3390, 105, true);
            WriteLiteral("</b></label>\r\n                            <div class=\"eventTime\">\r\n                                <ul>\r\n");
            EndContext();
#line 65 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                      
                                        cantidadTareasTerminadasDeLaEtapaAnterior = 0;
                                    

#line default
#line hidden
            BeginContext(3662, 36, true);
            WriteLiteral("                                    ");
            EndContext();
#line 68 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                     foreach (var task in Model.stages.ElementAt(i).tasks)
                                    {
                                        

#line default
#line hidden
#line 70 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                         if (task.kanbanState == "done")
                                        {
                                            state = "check";
                                            cantidadTareasTerminadasDeLaEtapaAnterior++;
                                        }
                                        else
                                        {
                                            state = "close";
                                        }

#line default
#line hidden
            BeginContext(4299, 94, true);
            WriteLiteral("                                        <li>\r\n                                            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4393, "\"", 4412, 2);
            WriteAttributeValue("", 4401, "icon-", 4401, 5, true);
#line 80 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
WriteAttributeValue("", 4406, state, 4406, 6, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4413, 126, true);
            WriteLiteral("></div>\r\n                                            <div class=\"task-name\">\r\n                                                ");
            EndContext();
            BeginContext(4540, 9, false);
#line 82 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                           Write(task.name);

#line default
#line hidden
            EndContext();
            BeginContext(4549, 54, true);
            WriteLiteral("\r\n                                            </div>\r\n");
            EndContext();
#line 84 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                              
                                                canUpload = true ? "true" : "false";
                                            

#line default
#line hidden
            BeginContext(4784, 238, true);
            WriteLiteral("                                            <div class=\"divUpload\">\r\n                                                <input type=\"file\"/>\r\n                                            </div>\r\n                                        </li>\r\n");
            EndContext();
#line 91 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                                    }

#line default
#line hidden
            BeginContext(5061, 107, true);
            WriteLiteral("                                </ul>\r\n                            </div>\r\n                        </div>\r\n");
            EndContext();
#line 95 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                         if (c == 1 || cantidadTareasTerminadasDeLaEtapaAnterior ==
Model.stages.ElementAt(i).tasks.Count)
                        {
                            c++;

#line default
#line hidden
            BeginContext(5354, 175, true);
            WriteLiteral("                            <svg height=\"20\" width=\"20\">\r\n                                <circle cx=\"10\" cy=\"11\" r=\"5\" fill=\"#ec9404\" />\r\n                            </svg>\r\n");
            EndContext();
#line 102 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(5613, 172, true);
            WriteLiteral("                            <svg height=\"20\" width=\"20\">\r\n                                <circle cx=\"10\" cy=\"11\" r=\"5\" fill=\"gray\" />\r\n                            </svg>\r\n");
            EndContext();
#line 108 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                        }

#line default
#line hidden
            BeginContext(5812, 28, true);
            WriteLiteral("                    </div>\r\n");
            EndContext();
#line 110 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                }

#line default
#line hidden
            BeginContext(5859, 23, true);
            WriteLiteral("                <div>\r\n");
            EndContext();
#line 112 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
                      
                        int k = -890 + porcentajeRecorrido;
                    

#line default
#line hidden
            BeginContext(5990, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(6010, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ec8214e8c1f9264ae6aa1e844c4c8d6a57c1bf3318990", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "style", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 6112, "margin-left:", 6112, 12, true);
#line 116 "C:\Users\hp\Desktop\DeltaCargo\Delta Cargo SRL\portalWebClientes\Views\Home\TimeLineOperacion.cshtml"
AddHtmlAttributeValue("", 6124, k, 6124, 2, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 6126, "%;", 6126, 2, true);
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(6132, 80, true);
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PortalWebCliente.Models.ProyectoModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
