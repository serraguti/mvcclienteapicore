#pragma checksum "C:\Users\ProfesorMCSD\Documents\Visual Studio 2019\Projects\MvcClienteApiDepartamentos\MvcClienteApiDepartamentos\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4b53f5f6ada8be46315189c7344232e016373dfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\ProfesorMCSD\Documents\Visual Studio 2019\Projects\MvcClienteApiDepartamentos\MvcClienteApiDepartamentos\Views\_ViewImports.cshtml"
using MvcClienteApiDepartamentos;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b53f5f6ada8be46315189c7344232e016373dfd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c980deec5b08da78409e42e4ad442149604f55ba", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Consumo Api Crud Departamentos</h1>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@" 
    <script>
        var urlapi = ""https://apicruddepartamentoscorepgs.azurewebsites.net/"";
        $(document).ready(function () {
            cargarDepartamentos();
            $(""#botoneliminar"").click(function () {
                var id = $(""#cajanumero"").val();
                var request = ""api/departamentos/"" + id;
                $.ajax({
                    url: urlapi + request,
                    type: ""DELETE"",
                    success: function () {
                        cargarDepartamentos();
                    }
                });
            });

            $(""#botoninsertar"").click(function () {
                var id = parseInt($(""#cajanumero"").val());
                var nombre = $(""#cajanombre"").val();
                var loc = $(""#cajalocalidad"").val();
                var departamento = new Object();
                departamento.idDepartamento = id;
                departamento.nombre = nombre;
                departamento.localidad = loc;
           ");
                WriteLiteral(@"     var json = JSON.stringify(departamento);
                var request = ""api/departamentos"";
                $.ajax({
                    url: urlapi + request,
                    type: ""POST"",
                    data: json,
                    contentType: ""application/json"",
                    success: function () {
                        cargarDepartamentos();
                    }
                });
            });

            $(""#botonmodificar"").click(function () {
                var id = parseInt($(""#cajanumero"").val());
                var nombre = $(""#cajanombre"").val();
                var localidad = $(""#cajalocalidad"").val();
                var departamento = new Object();
                departamento.idDepartamento = id;
                departamento.nombre = nombre;
                departamento.localidad = localidad;
                var json = JSON.stringify(departamento);
                var request = ""api/departamentos"";
                $.ajax({
             ");
                WriteLiteral(@"       url: urlapi + request,
                    contentType: ""application/json"",
                    type: ""PUT"",
                    data: json, 
                    success: function () {
                        cargarDepartamentos();
                    }
                });
            });
        });

        function cargarDepartamentos() {
            var request = ""api/departamentos"";
            $.ajax({
                url: urlapi + request,
                type: ""GET"",
                success: function (data) {
                    var html = """";
                    $.each(data, function (ind, dept) {
                        html += ""<tr>"";
                        html += ""<td>"" + dept.idDepartamento + ""</td>"";
                        html += ""<td>"" + dept.nombre + ""</td>"";
                        html += ""<td>"" + dept.localidad + ""</td>"";
                        html += ""</tr>"";
                    });
                    $(""#tabladepartamentos tbody"").html(html);
      ");
                WriteLiteral("          }\r\n            });\r\n        }\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4b53f5f6ada8be46315189c7344232e016373dfd6957", async() => {
                WriteLiteral(@"
    <label>Id Departamento: </label>
    <input type=""text"" id=""cajanumero"" placeholder=""Id departamento""
           class=""form-control""/><br/>
    <label>Nombre: </label>
    <input type=""text"" id=""cajanombre"" placeholder=""Nombre departamento""
           class=""form-control""/><br/>
    <label>Localidad: </label>
    <input type=""text"" id=""cajalocalidad"" placeholder=""Localidad""
           class=""form-control""/><br/>
    <div>
        <button type=""button"" id=""botoninsertar""
                class=""btn btn-success"">Insertar</button>
        <button type=""button"" id=""botonmodificar""
                class=""btn btn-info"">Modificar</button>
        <button type=""button"" id=""botoneliminar""
                class=""btn btn-danger"">Eliminar</button>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<table class=""table table-bordered table-warning"" 
       id=""tabladepartamentos"">
    <thead>
        <tr>
            <th>Id</th>
            <th>Nombre</th>
            <th>Localidad</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table> ");
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
