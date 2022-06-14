namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class MarkerController
    {
        public ActionResult ClientEvents(bool? clickable, bool? draggable)
        {
            this.ViewData["clickable"] = clickable ?? true;
            this.ViewData["draggable"] = draggable ?? true;
            return this.View();
        }
    }
}