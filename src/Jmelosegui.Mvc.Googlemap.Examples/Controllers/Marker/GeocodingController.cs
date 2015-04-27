using System.Web.Mvc;
using Jmelosegui.Mvc.Googlemap.Examples.App_Data;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult Geocoding()
        {
            return View(DataContext.GetRegions());
        }
    }
}