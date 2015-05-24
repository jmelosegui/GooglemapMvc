using System.Web.Mvc;
using Jmelosegui.Mvc.Googlemap.Objects;

namespace Jmelosegui.Mvc.Googlemap.Examples.Controllers
{
    public partial class MarkerController
    {
        public ActionResult MarkerClustering(MarkerClusteringOptions options, string customStyles)
        {
            ViewData["MaxZoom"] = options.MaxZoom;
            ViewData["GridSize"] = options.GridSize;
            ViewData["AverageCenter"] = options.AverageCenter;
            ViewData["ZoomOnClick"] = options.ZoomOnClick;
            ViewData["HideSingleGroupMarker"] = options.HideSingleGroupMarker;
            ViewData["CustomStyles"] = customStyles;


            return View(App_Data.DataContext.GetHugeAmountOfMarkers());
        }

    }
}