#pragma checksum "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1771247728b570073d11c1a7f53978eae79fe8fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FeedbackMasters_Details), @"mvc.1.0.view", @"/Views/FeedbackMasters/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FeedbackMasters/Details.cshtml", typeof(AspNetCore.Views_FeedbackMasters_Details))]
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
#line 1 "C:\Users\goner\Desktop\MVCcore\Views\_ViewImports.cshtml"
using MVCcore;

#line default
#line hidden
#line 2 "C:\Users\goner\Desktop\MVCcore\Views\_ViewImports.cshtml"
using MVCcore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1771247728b570073d11c1a7f53978eae79fe8fd", @"/Views/FeedbackMasters/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f87ebf22de92e15d3c35a90fbc397839fe96dab", @"/Views/_ViewImports.cshtml")]
    public class Views_FeedbackMasters_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<canteen_management_system.Models.FeedbackMaster>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(148, 128, true);
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>FeedbackMaster</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(277, 44, false);
#line 15 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Feedback));

#line default
#line hidden
            EndContext();
            BeginContext(321, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(365, 40, false);
#line 18 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.Feedback));

#line default
#line hidden
            EndContext();
            BeginContext(405, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(449, 50, false);
#line 21 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CreateDatetime));

#line default
#line hidden
            EndContext();
            BeginContext(499, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(543, 46, false);
#line 24 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.CreateDatetime));

#line default
#line hidden
            EndContext();
            BeginContext(589, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(633, 50, false);
#line 27 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.UpdateDatetime));

#line default
#line hidden
            EndContext();
            BeginContext(683, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(727, 46, false);
#line 30 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.UpdateDatetime));

#line default
#line hidden
            EndContext();
            BeginContext(773, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(817, 44, false);
#line 33 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(861, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(905, 40, false);
#line 36 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
            EndContext();
            BeginContext(945, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(989, 44, false);
#line 39 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsDelete));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1077, 40, false);
#line 42 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsDelete));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1161, 40, false);
#line 45 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.User));

#line default
#line hidden
            EndContext();
            BeginContext(1201, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1245, 46, false);
#line 48 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
       Write(Html.DisplayFor(model => model.User.FirstName));

#line default
#line hidden
            EndContext();
            BeginContext(1291, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1338, 62, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e5c93a3352eb4860b8e26a726eb66a77", async() => {
                BeginContext(1392, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\goner\Desktop\MVCcore\Views\FeedbackMasters\Details.cshtml"
                           WriteLiteral(Model.FeedbackId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1400, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1408, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "231f901f1eed4512898d85cb0c133700", async() => {
                BeginContext(1430, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1446, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<canteen_management_system.Models.FeedbackMaster> Html { get; private set; }
    }
}
#pragma warning restore 1591