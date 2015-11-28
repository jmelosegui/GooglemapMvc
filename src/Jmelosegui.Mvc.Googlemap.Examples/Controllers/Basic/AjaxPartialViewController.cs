namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class BasicController
    {
        // GET: AjaxPartialView
        public ActionResult AjaxPartialView()
        {
            return this.View();
        }

        public ActionResult GooglemapPartialView(string payload)
        {
            object model = payload;
            return this.PartialView("_GooglemapPartialView", model);
        }
    }
}