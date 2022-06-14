namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class BasicController
    {
        // GET: AjaxPartialView
        public ActionResult AjaxPartialView()
        {
            return this.View();
        }

        public ActionResult GooglemapPartialView(string payload)
        {
            string model = payload;
            return this.PartialView("_GooglemapPartialView", model);
        }
    }
}