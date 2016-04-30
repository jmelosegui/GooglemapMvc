namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class BasicController
    {
        public ActionResult UIControls(UIControlViewModel model)
        {
            return this.View(model);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single class", Justification = "This allows to see the model type in the sample view")]
    public class UIControlViewModel
    {
        public UIControlViewModel()
        {
            this.ShowScaleControl = true;

            this.ShowPanControl = true;
            this.PanControlPosition = ControlPosition.TopLeft;

            this.ShowZoomControl = true;
            this.ZoomControlPosition = ControlPosition.TopLeft;
            this.ZoomControlStyle = ZoomControlStyle.Default;
            this.ScrollWheel = true;

            this.ShowStreetViewControl = true;
            this.StreetViewControlPosition = ControlPosition.TopLeft;

            this.ShowOverviewMapControl = true;
            this.OverviewMapControlOpened = true;

            this.ShowMapType = true;
            this.MapTypeControl = MapType.Roadmap;
            this.MapTypeControlStyle = MapTypeControlStyle.Default;
            this.MapTypeControlPosition = ControlPosition.TopRight;
        }

        public bool ShowScaleControl { get; set; }

        public bool ShowPanControl { get; set; }

        public ControlPosition PanControlPosition { get; set; }

        public bool ShowMapType { get; set; }

        public MapType MapTypeControl { get; set; }

        public MapTypeControlStyle MapTypeControlStyle { get; set; }

        public ControlPosition MapTypeControlPosition { get; set; }

        public bool ShowZoomControl { get; set; }

        public ControlPosition ZoomControlPosition { get; set; }

        public ZoomControlStyle ZoomControlStyle { get; set; }

        public bool ShowStreetViewControl { get; set; }

        public ControlPosition StreetViewControlPosition { get; set; }

        public bool OverviewMapControlOpened { get; set; }

        public bool ShowOverviewMapControl { get; set; }

        public bool ScrollWheel { get; set; }
    }
}