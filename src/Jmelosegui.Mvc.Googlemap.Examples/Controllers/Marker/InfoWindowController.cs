using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult InfoWindow(InfoWindowModel infoWindow)
        {
            return View(infoWindow);
        }
    }

    public class InfoWindowModel
    {
        public InfoWindowModel()
        {
            MaxWidth = 500;
        }
        public int MaxWidth { get; set; }
        public bool DisableAutoPan { get; set; }
        public bool OpenOnRightClick { get; set; }
    }
}
