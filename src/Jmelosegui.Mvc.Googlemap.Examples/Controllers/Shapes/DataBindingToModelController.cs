namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class ShapesController
    {
        public ActionResult DataBindingToModel()
        {
            return this.View(App_Data.DataContext.GetRegions());
        }
    }
}