using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    public partial class BasicController
    {
        public ActionResult Language(string mapLanguage)
        {
            return View((object)(mapLanguage ?? "ru"));
        }

    }
}