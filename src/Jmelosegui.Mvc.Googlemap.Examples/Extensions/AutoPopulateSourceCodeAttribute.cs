using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples
{
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class AutoPopulateSourceCodeAttribute : FilterAttribute, IResultFilter
    {
        private const string ViewPath = "~/Views/";
        private const string ControllerPath = "~/Controllers/";
        private const string DescriptionPath = "~/Content/";
        private const string LayoutPagePath = ViewPath + "Shared/_Layout.cshtml";
        private const string LayoutExamplesPagePath = ViewPath + "Shared/_LayoutExamples.cshtml";


        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResult;

            if (viewResult != null)
            {
                HttpServerUtilityBase server = filterContext.HttpContext.Server;

                string controllerName = filterContext.RouteData.GetRequiredString("controller");

                string viewName =
                    !string.IsNullOrEmpty(viewResult.ViewName)
                        ? viewResult.ViewName
                        : filterContext.RouteData.GetRequiredString("action");

                const string baseViewPath = ViewPath;
                const string viewExtension = ".cshtml";
                string currentViewPath = baseViewPath + controllerName + Path.AltDirectorySeparatorChar + viewName + viewExtension;

                string exampleControllerPath = ControllerPath + controllerName + Path.AltDirectorySeparatorChar + viewName + "Controller.cs";

                string descriptionPath =
                    server.MapPath(DescriptionPath + Path.AltDirectorySeparatorChar + controllerName +
                    Path.AltDirectorySeparatorChar + "Descriptions" +
                    Path.AltDirectorySeparatorChar + viewName + ".html");

                var viewData = filterContext.Controller.ViewData;

                if (File.Exists(descriptionPath))
                {
                    var descriptionText = System.IO.File.ReadAllText(descriptionPath);
                    viewData["Description"] = new HtmlString(descriptionText);
                }

                var codeFiles = new Dictionary<string, string>();
                codeFiles["View"] = currentViewPath;
                codeFiles["Controller"] = exampleControllerPath;
                RegisterLayoutPages(filterContext, codeFiles);

                viewData["codeFiles"] = codeFiles;

                var additionalFiles = new Dictionary<string, string>();
                switch (viewName)
                {
                    case "AjaxPartialView":
                        additionalFiles["_GooglemapPartialView.cshtml"] = baseViewPath + "Basic" + Path.AltDirectorySeparatorChar + "_GooglemapPartialView" + viewExtension;
                        break;
                }
                viewData["aditionalFiles"] = additionalFiles;
            }
        }

        private void RegisterLayoutPages(ResultExecutingContext filterContext, Dictionary<string, string> codeFiles)
        {
            codeFiles["_LayoutExamples.cshtml"] = LayoutExamplesPagePath;
            codeFiles["_Layout.cshtml"] = LayoutPagePath;
        }

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            // Do Nothing
        }
    }
}