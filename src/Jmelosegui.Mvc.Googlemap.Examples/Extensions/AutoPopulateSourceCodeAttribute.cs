namespace Jmelosegui.Mvc.GoogleMap.Examples
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Microsoft.Extensions.Configuration;

    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AutoPopulateSourceCodeAttribute : Attribute, IResultFilter
    {
        private const string ViewPath = "Views";
        private const string ControllerPath = "Controllers";
        private const string DescriptionPath = "content";
        private const string LayoutPagePath = ViewPath + @"/Shared/_Layout.cshtml";
        private const string LayoutExamplesPagePath = ViewPath + @"/Shared/_LayoutExamples.cshtml";
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;

        public AutoPopulateSourceCodeAttribute(
            IWebHostEnvironment webHostEnvironment, 
            IConfiguration configuration)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }
        
        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult != null)
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];

                string viewName =
                    !string.IsNullOrEmpty(viewResult.ViewName)
                        ? viewResult.ViewName
                        : (string)filterContext.RouteData.Values["action"];

                const string baseViewPath = ViewPath;
                const string viewExtension = ".cshtml";
                string currentViewPath = baseViewPath + Path.AltDirectorySeparatorChar + controllerName + Path.AltDirectorySeparatorChar + viewName + viewExtension;

                string exampleControllerPath = ControllerPath + Path.AltDirectorySeparatorChar + controllerName + Path.AltDirectorySeparatorChar + viewName + "Controller.cs";
                string contentRootPath = this.webHostEnvironment.WebRootPath;
                
                string descriptionPath = Path.Combine(contentRootPath, DescriptionPath, controllerName, @$"Descriptions{Path.AltDirectorySeparatorChar}{viewName}.html");

                var viewData = viewResult.ViewData;

                if (File.Exists(descriptionPath))
                {
                    var descriptionText = File.ReadAllText(descriptionPath);
                    viewData["Description"] = new HtmlString(descriptionText);
                }

                var codeFiles = new Dictionary<string, string>
                {
                    ["View"] = currentViewPath,
                    ["Controller"] = exampleControllerPath
                };
                this.RegisterLayoutPages(filterContext, codeFiles);

                viewData["codeFiles"] = codeFiles;

                var additionalFiles = new Dictionary<string, string>();
                switch (viewName)
                {
                    case "AjaxPartialView":
                        additionalFiles["_GooglemapPartialView.cshtml"] = baseViewPath + Path.AltDirectorySeparatorChar + "Basic" + Path.AltDirectorySeparatorChar + "_GooglemapPartialView" + viewExtension;
                        break;
                }

                viewData["aditionalFiles"] = additionalFiles;

                viewData["GoogleMapApiKey"] = configuration.GetValue<string>("GoogleMapApiKey");
            }
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Do Nothing
        }

        private void RegisterLayoutPages(ResultExecutingContext filterContext, Dictionary<string, string> codeFiles)
        {
            codeFiles["_LayoutExamples.cshtml"] = LayoutExamplesPagePath;
            codeFiles["_Layout.cshtml"] = LayoutPagePath;
        }
    }
}