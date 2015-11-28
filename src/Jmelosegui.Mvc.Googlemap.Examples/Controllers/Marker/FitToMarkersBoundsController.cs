namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

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