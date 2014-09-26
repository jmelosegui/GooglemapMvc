using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class BasicController
    {
        public ActionResult Language(string mapLanguage)
        {
            return View((object)(mapLanguage ?? "ru"));
        }

    }
}