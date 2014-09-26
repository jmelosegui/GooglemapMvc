using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class BasicController
    {
        public ActionResult FirstLook(int? height, int? width)
        {
            ViewData["height"] = height ?? 300;
            ViewData["width"] = width ?? 0;
            return View();
        }
    }
}