namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class MarkerController
    {
        // GET: MapFir
        public ActionResult FitToMarkersBounds(bool? fitToMarkersBounds)
        {
            this.ViewData["FitToMarkersBounds"] = fitToMarkersBounds ?? true;
            return this.View();
        }
    }
}