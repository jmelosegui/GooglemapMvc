namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class BasicController
    {
        public ActionResult Version(string version)
        {
            this.ViewData["version"] = version;
            return this.View();
        }
    }
}