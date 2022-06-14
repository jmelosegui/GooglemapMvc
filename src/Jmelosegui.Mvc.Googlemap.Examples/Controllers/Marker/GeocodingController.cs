namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class MarkerController
    {
        public ActionResult Geocoding()
        {
            return this.View(App_Data.DataContext.GetRegions());
        }
    }
}