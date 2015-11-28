namespace Jmelosegui.Mvc.GoogleMap.Examples.Controllers
{
    using System.Web.Mvc;

    public partial class MarkerController
    {
        public ActionResult MarkerClustering(MarkerClusteringOptions options, string customStyles)
        {
            this.ViewData["MaxZoom"] = options.MaxZoom;
            this.ViewData["GridSize"] = options.GridSize;
            this.ViewData["AverageCenter"] = options.AverageCenter;
            this.ViewData["ZoomOnClick"] = options.ZoomOnClick;
            this.ViewData["HideSingleGroupMarker"] = options.HideSingleGroupMarker;
            this.ViewData["CustomStyles"] = customStyles;

            return this.View(App_Data.DataContext.GetHugeAmountOfMarkers());
        }
    }
}