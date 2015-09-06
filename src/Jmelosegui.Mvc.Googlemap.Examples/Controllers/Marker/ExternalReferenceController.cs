using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult ExternalReference()
        {
            return View(App_Data.DataContext.GetRegions());
        }
    }
}