using System.Web.Mvc;
using Jmelosegui.Mvc.Googlemap.Examples.App_Data;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class ShapesController
    {
        public ActionResult DataBindingToModel()
        {
            return View(DataContext.GetRegions());
        }
    }
}