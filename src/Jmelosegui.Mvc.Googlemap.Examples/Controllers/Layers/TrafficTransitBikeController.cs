namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class LayersController
    {
        public ActionResult TrafficTransitBike(LayerViewModel model)
        {
            return this.View(model);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single class", Justification = "This allows to see the model type in the sample view")]
    public class LayerViewModel
    {
        public bool ShowTrafficLayer { get; set; }

        public bool ShowBicyclingLayer { get; set; }

        public bool ShowTransitLayer { get; set; }
    }
}