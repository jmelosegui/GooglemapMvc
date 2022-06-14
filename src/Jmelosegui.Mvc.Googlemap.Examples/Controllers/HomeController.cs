namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class HomeController : Controller
    {
        private static readonly Regex ForbiddenExtensions = new Regex("dll|config", RegexOptions.IgnoreCase);
        private readonly IWebHostEnvironment webHostEnvironment;
        
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        
        public ActionResult FirstLook()
        {
            return this.View();
        }

        public ActionResult CodeFile(string file)
        {   
            string filePath = Path.Combine(this.webHostEnvironment.ContentRootPath, file);

            if (!System.IO.File.Exists(filePath) || ForbiddenExtensions.IsMatch(filePath))
            {
                return new EmptyResult();
            }

            return this.PartialView((object)System.IO.File.ReadAllText(file));
        }
    }
}