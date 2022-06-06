namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public partial class BasicController
    {
        public ActionResult Language(string mapLanguage)
        {
            return this.View((object)(mapLanguage ?? "ru"));
        }
    }
}