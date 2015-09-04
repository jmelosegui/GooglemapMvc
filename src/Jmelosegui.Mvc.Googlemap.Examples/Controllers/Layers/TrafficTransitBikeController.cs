using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class LayersController
    {
        public ActionResult TrafficTransitBike(LayerViewModel model)
        {
            return View(model);
        }
    }

    public class LayerViewModel
    {
        public bool ShowTrafficLayer { get; set; }

        public bool ShowBicyclingLayer { get; set; }

        public bool ShowTransitLayer { get; set; }
    }
}