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

        public ActionResult GooglemapPartialView([FromBody] string payload)
        {
            var aaa = ControllerContext;
            object model = payload;
            return this.PartialView("_GooglemapPartialView", model);
        }
    }
}