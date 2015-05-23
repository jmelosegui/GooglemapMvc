using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class BasicController
    {
        // GET: AjaxPartialView
        public ActionResult AjaxPartialView()
        {
            return View();
        }

        public ActionResult GooglemapPartialView()
        {
            return PartialView("_GooglemapPartialView");
        }
    }
}