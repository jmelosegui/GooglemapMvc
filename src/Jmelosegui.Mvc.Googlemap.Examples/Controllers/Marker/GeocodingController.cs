using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult Geocoding()
        {
            return View(App_Data.DataContext.GetRegions());
        }
    }
}