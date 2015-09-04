using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class MarkerController
    {
        // GET: MapFir
        public ActionResult FitToMarkersBounds(bool? fitToMarkersBounds)
        {
            ViewData["FitToMarkersBounds"] = fitToMarkersBounds ?? true;
            return View();
        }
    }
}