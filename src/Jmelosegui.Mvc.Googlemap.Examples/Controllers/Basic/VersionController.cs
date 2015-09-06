using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
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