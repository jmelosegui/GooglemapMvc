using System.Web.Mvc;
using Jmelosegui.Mvc.Googlemap.Examples.App_Data;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult DataBindingToModel()
        {
            return View(DataContext.GetRegions());
        }
    }
}