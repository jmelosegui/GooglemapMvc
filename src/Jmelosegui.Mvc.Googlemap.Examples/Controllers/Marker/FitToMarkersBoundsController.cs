using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        // GET: MapFir
        public ActionResult FitToMarkersBounds(bool? fitToMarkersBounds)
        {
            ViewData["FitToMarkersBounds"] = fitToMarkersBounds ?? true;
            return View();
        }
    }
}