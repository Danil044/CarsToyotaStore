#pragma checksum "D:\Программирование\ASP.NET CORE\WebApplicationCarStore\WebApplicationCarStore\Views\Home\Cars.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6057050a52a4d7844dde373dce7751375a5d907b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Cars), @"mvc.1.0.view", @"/Views/Home/Cars.cshtml")]
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
#line 1 "D:\Программирование\ASP.NET CORE\WebApplicationCarStore\WebApplicationCarStore\Views\_ViewImports.cshtml"
using WebApplicationCarStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Программирование\ASP.NET CORE\WebApplicationCarStore\WebApplicationCarStore\Views\_ViewImports.cshtml"
using WebApplicationCarStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6057050a52a4d7844dde373dce7751375a5d907b", @"/Views/Home/Cars.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2918ba0cff33f9416b4d220778719a7223260cd5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Cars : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Программирование\ASP.NET CORE\WebApplicationCarStore\WebApplicationCarStore\Views\Home\Cars.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Cars</h1>
</div>

<div>

</div>

<div>
    <div id=""navModels"">
        Tyt cars
    </div>

    <div id=""imgModels"">

    </div>
</div>


<div>
    <div id=""mainModels"">
        Tyt activite model
    </div>

    <div style=""display: flex; margin-top: 3rem;"">
        <div style=""margin-right: 25%; margin-left: 20%"" id=""imgMainModels"">

        </div>

        <div id=""mainModifications"">
            Tyt modifications
        </div>
    </div>
    
    
</div>




");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>

        let apiModels = ""/api/ApiModels""
        let getModifications = ""/api/GetModifications""
        let getModificationColor = ""/api/GetModificationColors""
        let getModificationColorImg = ""/api/GetModificationColorsImg""

        function onError(err) {
            console.log(""Error"");
            console.log(err);
        }


        function getModificationColorImgs(obj, color_id) {
            console.log(obj);
            console.log(color_id);
            fetch(getModificationColorImg + ""/"" + obj)
                .then(res => {
                    if (res.status !== 200) {
                        onError(res);
                        return;
                    }
                    return res.json();
                })
                .then(models => {

                    console.log(""Сoбираюсь сменить картинку!"");

                    models.map(modification_color_img => {

                        console.log(modification_color_img);
           ");
                WriteLiteral(@"             console.log(""Должен получить картинку!"");
                        if (modification_color_img.colorId == color_id) {
                            let divModel = document.getElementById(""imgMainModels"");
                            divModel.innerHTML = """";

                            console.log(modification_color_img);

                            let img = document.createElement(""img"");

                            img.style.height = ""200px""
                            img.style.marginLeft = ""34%""
                            img.style.marginTop = ""2rem""

                            img.src = modification_color_img.imgUrl;

                            divModel.appendChild(img);
                        }
                        else {
                            console.log(""НЕТ"");
                        }
  
                    })
                })
                .catch(err => { onError(err); })
        }



        function getModificationColors(modification_id) {
");
                WriteLiteral(@"            console.log(modification_id);
            fetch(getModificationColor + ""/"" + modification_id)
                .then(res => {
                    if (res.status !== 200) {
                        onError(res);
                        return;
                    }
                    return res.json();
                })
                .then(models => {
                    let div = document.getElementById(""mainModifications"")
                    div.innerHTML = """";
                    let ul = document.createElement(""ul"");

                    ul.style.listStyleType = 'none';
                    ul.style.display = ""inline-block""
                    ul.style.backgroundColor = ""rgb(0, 0, 0, 0.2)"";
                    ul.style.paddingTop = ""1rem"";
                    ul.style.paddingBottom = ""1rem"";
                    ul.style.paddingRight = ""2rem"";
                    ul.style.marginLeft = ""3rem"";
                    ul.style.marginTop = ""2rem"";
                    ul.style.bo");
                WriteLiteral(@"rderRadius = ""7px"";
                    ul.style.border = ""2px solid black"";
          

                    models.map(modification_color => {



                        let li = document.createElement(""li"");

                        li.style.marginTop = ""15px"";
                        li.style.marginBottom = ""15px"";

                        //li.innerText = modification_color.name;
                        li.id = modification_color.id;
                        console.log(modification_color);


                        let img = document.createElement(""img"");
                        img.src = """";

                        img.style.height = ""80px""
                        img.style.borderRadius = ""50px""

                        img.src = modification_color.imgUrl;

                        li.onclick = function () {
                            console.log(""Иду за картинкой!"");
                            getModificationColorImgs(modification_id, modification_color.id);
              ");
                WriteLiteral(@"          }

                        li.appendChild(img);
                        ul.appendChild(li);

                    })
                    div.appendChild(ul);
                })
                .catch(err => { onError(err); })
        }

     

        function getModification(model_id) {
            console.log(model_id);
            fetch(getModifications + ""/"" + model_id)
                .then(res => {
                    if (res.status !== 200) {
                        onError(res);
                        return;
                    }
                    return res.json();
                })
                .then(models => {
                    let div = document.getElementById(""mainModels"");
                    let ul = document.createElement(""ul"");


                    models.map(modification => {
                        let li = document.createElement(""li"");

                        li.style.backgroundColor = ""rgb(0, 0, 0, 0.3)""
                        li.styl");
                WriteLiteral(@"e.height = ""5""
                        li.style.width = ""260px""
                        li.style.borderRadius = ""5px""
                        li.style.border = ""3px solid rgb(0, 0, 0, 0.4)""
                        li.style.marginTop = ""1rem""
                        li.style.marginLeft = ""1rem""
                        li.style.fontSize = ""26px""
                        li.style.display = ""inline-block""
                        li.style.textAlign = ""center""
                        li.style.color = ""rgb(255, 255, 255, 0.9)""
                        li.style.paddingTop = ""2px""

                        li.innerText = modification.name;
                        li.id = modification.id;
                        console.log(modification);

                        li.onclick = function () {
                            let divModel = document.getElementById(""imgMainModels"");
                            divModel.innerHTML = """";

                            console.log(modification);

                   ");
                WriteLiteral(@"         let img = document.createElement(""img"");

                            img.style.height = ""200px""
                            img.style.marginLeft = ""34%""
                            img.style.marginTop = ""2rem""


                            img.src = modification.imgUrl;

                            getModificationColors(modification.id);
                            console.log(""Получаю картинки цветов"");

                            divModel.appendChild(img);
                        }

                        ul.appendChild(li);

                    })
                    div.innerHTML = """";

                    div.appendChild(ul);

                })
                .catch(err => { onError(err); })
        }

       
        function renderModels(htmlTag) {
            console.log(htmlTag.id);
            fetch(apiModels + ""/"" + htmlTag.id)
                .then(res => {
                    if (res.status !== 200) {
                        onError(res);
           ");
                WriteLiteral(@"             return;
                    }
                    //console.log(res);
                    return res.json();
                })
                .then(model => {
                    //console.log(model);

                    let divModel = document.getElementById(""imgModels"");
                    divModel.innerHTML = """";
                    console.log(model);
                    let img = document.createElement(""img"");
                    img.style.height = ""135px""
                    img.src = model.imgUrl;

                    divModel.innerHTML = """";

                    img.onclick = function () {
                        getModification(model.id);
                    }

                    divModel.appendChild(img);

                })
                .catch(err => { onError(err) });
        }


        function renderModelsNav(models) {
            //console.log(items);
            let div = document.getElementById(""navModels"")
            div.innerHTML = """";
");
                WriteLiteral(@"
            let ul = document.createElement(""ul"");
            ul.style.listStyleType = 'none';

            /*
            for (var model of models) {
                let li = document.createElement(""li"");
                li.innerText = model.name;
                li.id = model.id;
                ul.appendChild(li);
            }
            */

            models.map(model => {
                let li = document.createElement(""li"");

                li.style.backgroundColor = ""rgb(0, 0, 0, 0.5)""
                li.style.height = ""250px""
                li.style.width = ""260px""
                li.style.borderRadius = ""5px""
                li.style.border = ""3px solid rgb(0, 0, 0, 0.8)""
                li.style.marginTop = ""1rem""
                li.style.marginLeft = ""1rem""
                li.style.fontSize = ""42px""
                li.style.display = ""inline-block""
                li.style.textAlign = ""center""
                li.style.color = ""rgb(255, 255, 255, 0.8)""
             ");
                WriteLiteral(@"   li.style.paddingTop = ""3px""

                li.innerText = model.name;
                li.id = model.id;

                let img = document.createElement(""img"");

                img.style.marginTop = ""2rem""
                img.style.height = ""105px""

                img.src = model.imgUrl;

                img.onclick = function () {
                    getModification(model.id);
                }
                li.appendChild(img);
               
                ul.appendChild(li);
            });

            div.appendChild(ul);
        }

        function getAllModels() {
            fetch(apiModels)
                .then(res => {
                    if (res.status !== 200) {
                        onError(res);
                        return;
                    }
                    //console.log(res);
                    return res.json();
                })
                .then(models => {
                    renderModelsNav(models);
                })
   ");
                WriteLiteral("             .catch(err => { onError(err) });\r\n        }\r\n\r\n        getAllModels();\r\n\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
