namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private static readonly Regex ForbiddenExtensions = new Regex("dll|config", RegexOptions.IgnoreCase);

        public ActionResult FirstLook()
        {
            return this.View();
        }

        public ActionResult CodeFile(string file)
        {
            if (!file.StartsWith("~", StringComparison.OrdinalIgnoreCase))
            {
                return new EmptyResult();
            }

            file = this.Server.MapPath(file);
            string extension = Path.GetExtension(file);

            if (!System.IO.File.Exists(file) || ForbiddenExtensions.IsMatch(extension))
            {
                return new EmptyResult();
            }

            return this.PartialView((object)System.IO.File.ReadAllText(file));
        }
    }
}