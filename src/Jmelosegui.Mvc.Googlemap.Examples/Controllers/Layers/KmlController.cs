using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class LayersController
    {
        public ActionResult Kml(KmlModel model)
        {
            return View(model);
        }
    }

    public class KmlModel
    {
        public KmlModel()
        {
            Clickable = true;
            ScreenOverlays = true;
            Url = "http://gmaps-samples.googlecode.com/svn/trunk/ggeoxml/cta.kml";
        }
        public bool Clickable { get; set; }

        public bool PreserveViewport { get; set; }

        public bool ScreenOverlays { get; set; }

        public bool SuppressInfoWindows { get; set; }

        public string Url { get; set; }

        public int zIndex { get; set; }
    }
}