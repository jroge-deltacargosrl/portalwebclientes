#pragma checksum "E:\Documentacion Trabajo\DELTA CARGO\Implementacion\portalwebclientes\Views\Home\TimeLine.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d593a84c7ce2672cb3a7b98001c29ba9ad336ce0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TimeLine), @"mvc.1.0.view", @"/Views/Home/TimeLine.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/TimeLine.cshtml", typeof(AspNetCore.Views_Home_TimeLine))]
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
#line 1 "E:\Documentacion Trabajo\DELTA CARGO\Implementacion\portalwebclientes\Views\_ViewImports.cshtml"
using PortalWebCliente;

#line default
#line hidden
#line 2 "E:\Documentacion Trabajo\DELTA CARGO\Implementacion\portalwebclientes\Views\_ViewImports.cshtml"
using PortalWebCliente.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d593a84c7ce2672cb3a7b98001c29ba9ad336ce0", @"/Views/Home/TimeLine.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b7db8ae182dab00c0ee18eda59166f764a62cf2", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TimeLine : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 1440, true);
            WriteLiteral(@"<div class=""page-content"">
    <h3 class=""steps-header"">
        Timeline de la operacion
    </h3>
    <section id=""Steps"" class=""steps-section"">
        <div class=""steps-timeline"">
            <div class=""steps-one"">
                <img class=""steps-img"" src=""http://placehold.it/50/3498DB/FFFFFF"" alt="""" />
                <h3 class=""steps-name"">
                    Semantic
                </h3>
                <p class=""steps-description"">
                    The timeline is created using negative margins and a top border.
                </p>
            </div>
            <div class=""steps-two"">
                <img class=""steps-img"" src=""http://placehold.it/50/3498DB/FFFFFF"" alt="""" />
                <h3 class=""steps-name"">
                    Relative
                </h3>
                <p class=""steps-description"">
                    All elements are positioned realtive to the parent. No absolute positioning.
                </p>
            </div>
            <div class=""");
            WriteLiteral(@"steps-three"">
                <img class=""steps-img"" src=""http://placehold.it/50/3498DB/FFFFFF"" alt="""" />
                <h3 class=""steps-name"">
                    Contained
                </h3>
                <p class=""steps-description"">
                    The timeline does not extend past the first and last elements.
                </p>
            </div>
        </div>
    </section>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
