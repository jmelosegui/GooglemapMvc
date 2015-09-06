using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class BasicController
    {
        // GET: AjaxPartialView
        public ActionResult AjaxPartialView()
        {
            return View();
        }

        public ActionResult GooglemapPartialView(string payload)
        {
            object model = payload;
            return PartialView("_GooglemapPartialView", model);
        }
    }
}