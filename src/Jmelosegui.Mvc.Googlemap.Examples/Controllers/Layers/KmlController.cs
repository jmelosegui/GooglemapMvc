namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;

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
            this.Url = new Uri("https://googlearchive.github.io/js-v2-samples/ggeoxml/cta.kml");
        }

        public bool Clickable { get; set; }

        public bool PreserveViewport { get; set; }

        public bool ScreenOverlays { get; set; }

        public bool SuppressInfoWindows { get; set; }

        public Uri Url { get; set; }

        public int ZIndex { get; set; }
    }
}