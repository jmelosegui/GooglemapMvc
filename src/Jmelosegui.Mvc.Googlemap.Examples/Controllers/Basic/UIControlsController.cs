using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class BasicController
    {
        public ActionResult UIControls(UIControlViewModel model)
        {
            return View(model);
        }

    }

    public class UIControlViewModel
    {
        public UIControlViewModel()
        {
            ShowScaleControl = true;

            ShowPanControl = true;
            PanControlPosition = ControlPosition.TopLeft;

            ShowZoomControl = true;
            ZoomControlPosition = ControlPosition.TopLeft;
            ZoomControlStyle = ZoomControlStyle.Default;

            ShowStreetViewControl = true;
            StreetViewControlPosition = ControlPosition.TopLeft;

            ShowOverviewMapControl = true;
            OverviewMapControlOpened = true;

            ShowMapType = true;
            MapTypeControl = MapTypes.Roadmap;
            MapTypeControlStyle = MapTypeControlStyle.Default;
            MapTypeControlPosition = ControlPosition.TopRight;
        }

        public bool ShowScaleControl { get; set; }
        public bool ShowPanControl { get; set; }
        public ControlPosition PanControlPosition { get; set; }

        public bool ShowMapType { get; set; }
        public MapTypes MapTypeControl { get; set; }
        public MapTypeControlStyle MapTypeControlStyle { get; set; }
        public ControlPosition MapTypeControlPosition { get; set; }
        public bool ShowZoomControl { get; set; }
        public ControlPosition ZoomControlPosition { get; set; }
        public ZoomControlStyle ZoomControlStyle { get; set; }
        public bool ShowStreetViewControl { get; set; }
        public ControlPosition StreetViewControlPosition { get; set; }
        public bool OverviewMapControlOpened { get; set; }
        public bool ShowOverviewMapControl { get; set; }
    }
}