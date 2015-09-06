using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class ShapesController
    {
        public ActionResult DataBindingToModel()
        {
            return View(App_Data.DataContext.GetRegions());
        }
    }
}