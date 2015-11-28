namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class ShapesController
    {
        public ActionResult DataBindingToModel()
        {
            return this.View(App_Data.DataContext.GetRegions());
        }
    }
}