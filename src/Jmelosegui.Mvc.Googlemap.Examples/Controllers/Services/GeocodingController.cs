namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class ServicesController
    {
        public ActionResult Geocoding(string address)
        {
            return this.View((object)(address ?? "Madrid, Spain"));
        }
    }
}