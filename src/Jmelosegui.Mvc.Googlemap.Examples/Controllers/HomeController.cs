using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public class HomeController : Controller
    {
        private static readonly Regex ForbiddenExtensions = new Regex("dll|config", RegexOptions.IgnoreCase);

        public ActionResult FirstLook()
        {
            return View();
        }

        public ActionResult CodeFile(string file)
        {
            if (!file.StartsWith("~", StringComparison.OrdinalIgnoreCase))
            {
                return new EmptyResult();
            }

            file = Server.MapPath(file);
            string extension = Path.GetExtension(file);

            if (!System.IO.File.Exists(file) || ForbiddenExtensions.IsMatch(extension))
            {
                return new EmptyResult();
            }

            return PartialView((object)System.IO.File.ReadAllText(file));
        }
    }
}