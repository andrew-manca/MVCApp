#pragma checksum "C:\Users\anmanca\source\repos\MVCApp\MVCApp\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6691a47864bc056f70df3f5ad60cdb37dddf35d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
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
#line 1 "C:\Users\anmanca\source\repos\MVCApp\MVCApp\Views\_ViewImports.cshtml"
using MVCApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\anmanca\source\repos\MVCApp\MVCApp\Views\_ViewImports.cshtml"
using MVCApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6691a47864bc056f70df3f5ad60cdb37dddf35d", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffc2c33a2db2f5e09931edba2ebdc432ae0da8c9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\anmanca\source\repos\MVCApp\MVCApp\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>");
#nullable restore
#line 4 "C:\Users\anmanca\source\repos\MVCApp\MVCApp\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h1>

<p>Use this page to detail your site's privacy policy.</p>

<button id=""test"" onclick=""testFunction()"">Test</button>

<script type=""text/javascript"">
        function testFunction() {
        console.log(""IN the function"");
        $.ajax({
            url: 'https://accounts.google.com/o/oauth2/v2/auth/oauthchooseaccount?response_type=code&client_id=573070539905-5d2e3i06pc7a9jfp9gm29vc4m93ubni4.apps.googleusercontent.com&redirect_uri=https%3A%2F%2Fcorstestnoor.azurewebsites.net%2F.auth%2Flogin%2Fgoogle%2Fcallback&scope=openid%20profile%20email&state=redir%3D%252F%26nonce%3D74e1a1e771f24f0ab8afb78ddfc2eefd_20200731175044&flowName=GeneralOAuthFlow',
            type: 'GET',
            contentType: 'application/x-www-form-urlencoded; charset=utf-8',
            success: function (result) {
                console.log(""successful call"");
            },
            error: function (result) {
                console.log(""An Error Occured"");
            }
        });
    };
</script>
");
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
