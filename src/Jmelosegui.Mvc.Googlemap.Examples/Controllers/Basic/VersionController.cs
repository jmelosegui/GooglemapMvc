using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class BasicController
    {
        public ActionResult Version(string version)
        {
            ViewData["version"] = version;
            return View();
        }
    }
}