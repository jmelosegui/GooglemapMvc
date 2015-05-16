using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult DataBindingToModel()
        {
            return View(App_Data.DataContext.GetRegions());
        }
    }
}