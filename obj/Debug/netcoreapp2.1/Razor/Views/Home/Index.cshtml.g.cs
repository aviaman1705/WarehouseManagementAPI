#pragma checksum "C:\www\MvcTaskManager\MvcTaskManager\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6cf471a8580ce489a81893138f58389c62f33f1"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6cf471a8580ce489a81893138f58389c62f33f1", @"/Views/Home/Index.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 37, true);
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            EndContext();
            BeginContext(37, 1658, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a463d1f2c2d94b47b025f3055d02d77a", async() => {
                BeginContext(43, 1645, true);
                WriteLiteral(@"

    <meta charset=""utf-8"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta name=""description"" content="""">
    <meta name=""author"" content="""">

    <title>SB Admin 2 - Bootstrap Admin Theme</title>

    <!-- Bootstrap Core CSS -->
    <link href=""assets/css/bootstrap.min.css"" rel=""stylesheet"">

    <!-- not use this in ltr -->
    <link href=""assets/css/bootstrap.rtl.css"" rel=""stylesheet"">

    <!-- MetisMenu CSS -->
    <!-- <link href=""assets/css/metisMenu.min.css"" rel=""stylesheet""> -->
    <link rel=""stylesheet"" href=""https://unpkg.com/metismenu/dist/metisMenu.min.css"">
    <!-- OR -->
    <link rel=""stylesheet"" href=""https://cdn.jsdelivr.net/npm/metismenu/dist/metisMenu.min.css"">

    <!-- Timeline CSS -->
    <link href=""assets/css/timeline.css"" rel=""stylesheet"">

    <!-- Custom CSS -->
    <link href=""assets/css/sb-admin-2.css"" rel=""stylesheet"">

    <!-- Morris Charts CSS -->
    ");
                WriteLiteral(@"<link href=""assets/css/morris.css"" rel=""stylesheet"">

    <!-- Custom Fonts -->
    <link href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet""
          type=""text/css"">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src=""https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js""></script>
        <script src=""https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js""></script>
    <![endif]-->

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1695, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            BeginContext(1699, 1531, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e620268060148cb86d6d45a7690bd8d", async() => {
                BeginContext(1705, 1518, true);
                WriteLiteral(@"
    <app-root></app-root>





    <!-- jQuery Version 1.11.0 -->
    <!-- <script src=""assets/js/jquery-1.11.0.js""></script> -->
    <script src=""https://unpkg.com/jquery""></script>
    <!-- OR -->
    <script src=""https://cdn.jsdelivr.net/npm/jquery""></script>

    <!-- Bootstrap Core JavaScript -->
    <script src=""assets/js/bootstrap.min.js""></script>

    <script src=""https://unpkg.com/metismenu""></script>
    <!-- OR -->
    <script src=""https://cdn.jsdelivr.net/npm/metismenu""></script>

    <!-- Morris Charts JavaScript -->
    <script src=""assets/js/raphael.min.js""></script>
    <script src=""assets/js/morris.min.js""></script>

    <!-- Custom Theme JavaScript -->
    <!-- <script src=""assets/js/sb-admin-2.js""></script> -->
    <!-- Metis Menu Plugin JavaScript -->
    <!-- <script src=""assets/js/metisMenu.min.js""></script> -->

    <script src=""runtime-es2015.js"" type=""module""></script>
    <script src=""runtime-es5.js"" nomodule defer></script>
    <script src=""polyfills");
                WriteLiteral(@"-es5.js"" nomodule defer></script>
    <script src=""polyfills-es2015.js"" type=""module""></script>
    <script src=""styles-es2015.js"" type=""module""></script>
    <script src=""styles-es5.js"" nomodule defer></script>
    <script src=""scripts.js"" defer></script>
    <script src=""vendor-es2015.js"" type=""module""></script>
    <script src=""vendor-es5.js"" nomodule defer></script>
    <script src=""main-es2015.js"" type=""module""></script>
    <script src=""main-es5.js"" nomodule defer></script>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3230, 11, true);
            WriteLiteral("\r\n\r\n</html>");
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
