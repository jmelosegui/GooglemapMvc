using System.Web.Mvc;
using Jmelosegui.Mvc.Googlemap.Examples.App_Data;
using Jmelosegui.Mvc.Googlemap.Overlays;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult MarkerClustering(MarkerClusteringOptions options, string CustomStyles)
        {
            ViewData["MaxZoom"] = options.MaxZoom;
            ViewData["GridSize"] = options.GridSize;
            ViewData["AverageCenter"] = options.AverageCenter;
            ViewData["ZoomOnClick"] = options.ZoomOnClick;
            ViewData["HideSingleGroupMarker"] = options.HideSingleGroupMarker;
            ViewData["CustomStyles"] = CustomStyles;
            

            return View(DataContext.GetHugeAmountOfMarkers());
        }

    }
}