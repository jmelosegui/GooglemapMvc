namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class MarkerController
    {
        public ActionResult InfoWindow(InfoWindowModel infoWindow)
        {
            return this.View(infoWindow);
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single class", Justification = "This allows to see the model type in the sample view")]
    public class InfoWindowModel
    {
        public InfoWindowModel()
        {
            this.MaxWidth = 500;
        }

        public int MaxWidth { get; set; }

        public bool DisableAutoPan { get; set; }

        public bool OpenOnRightClick { get; set; }
    }
}
