namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class LayersController
    {
        public ActionResult Kml(KmlModel model)
        {
            return this.View(model);
        }
    }

#pragma warning disable SA1402 // File may only contain a single class
    public class KmlModel
#pragma warning restore SA1402 // File may only contain a single class
    {
        public KmlModel()
        {
            this.Clickable = true;
            this.ScreenOverlays = true;
            this.Url = "http://gmaps-samples.googlecode.com/svn/trunk/ggeoxml/cta.kml";
        }

        public bool Clickable { get; set; }

        public bool PreserveViewport { get; set; }

        public bool ScreenOverlays { get; set; }

        public bool SuppressInfoWindows { get; set; }

        public string Url { get; set; }

        public int ZIndex { get; set; }
    }
}