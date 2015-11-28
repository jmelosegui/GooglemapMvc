namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class MarkerController
    {
        public ActionResult ExternalReference()
        {
            return this.View(App_Data.DataContext.GetRegions());
        }
    }
}