#pragma checksum "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc42fbb51ff9e4b8b1a8049782e3c98a352bf690"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TableButtonPartial), @"mvc.1.0.view", @"/Views/Shared/_TableButtonPartial.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_TableButtonPartial.cshtml", typeof(AspNetCore.Views_Shared__TableButtonPartial))]
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
#line 1 "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\_ViewImports.cshtml"
using GraniteHouse;

#line default
#line hidden
#line 2 "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\_ViewImports.cshtml"
using GraniteHouse.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc42fbb51ff9e4b8b1a8049782e3c98a352bf690", @"/Views/Shared/_TableButtonPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"add87ae52faa7df67fbebca5d3c39a845d0e03fe", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TableButtonPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(132, 120, true);
            WriteLiteral("\r\n\r\n<td style=\"width:150px\">\r\n    <div class=\"btn-group\" role=\"group\">\r\n        <a type=\"button\" class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 252, "\"", 285, 1);
#line 8 "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 259, Url.Action("Edit/"+Model), 259, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(286, 106, true);
            WriteLiteral(">\r\n            <i class=\"fas fa-edit\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-success\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 392, "\"", 428, 1);
#line 11 "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 399, Url.Action("Details/"+Model), 399, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(429, 109, true);
            WriteLiteral(">\r\n            <i class=\"fas fa-list-alt\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-danger\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 538, "\"", 573, 1);
#line 14 "F:\Visual Studio Repositories\GraniteHouse\GraniteHouse\Views\Shared\_TableButtonPartial.cshtml"
WriteAttributeValue("", 545, Url.Action("Delete/"+Model), 545, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(574, 82, true);
            WriteLiteral(">\r\n            <i class=\"fas fa-trash-alt\"></i>\r\n        </a>\r\n    </div>\r\n</td>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591