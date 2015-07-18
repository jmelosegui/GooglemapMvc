using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.UI;
using Jmelosegui.Mvc.Googlemap.Objects;

namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMap
    {
        private readonly GoogleMapBuilder builder;

        #region Constructor

        public GoogleMap(GoogleMapBuilder builder)
        {
            this.builder = builder;
            ScriptFileNames = new List<string>();
            ScriptFileNames.AddRange(new[] { "jmelosegui.googlemap.js" });
            Initialize();
        }


        private void Initialize()
        {
            Id = "map";
            ClientEvents = new GoogleMapClientEvents();
            MarkerClientEvents = new MarkerClientEvents();
            DisableDoubleClickZoom = false;
            Draggable = true;
            EnableMarkersClustering = false;
            Latitude = 23;
            Longitude = -82;
            Layers = new List<Layer>();
            MapTypeId = MapTypes.Roadmap.ToClientSideString();
            MapTypeControlPosition = ControlPosition.TopRight;
            MapTypeControlVisible = true;
            ImageMapTypes = new List<ImageMapType>();
            StyledMapTypes = new List<StyledMapType>();
            Markers = new List<Marker>();
            MarkerClusteringOptions = new MarkerClusteringOptions();
            Polygons = new List<Polygon>();
            Circles = new List<Circle>();
            PanControlPosition = ControlPosition.TopLeft;
            PanControlVisible = true;
            OverviewMapControlVisible = false;
            OverviewMapControlOpened = false;
            StreetViewControlVisible = true;
            StreetViewControlPosition = ControlPosition.TopLeft;
            ZoomControlVisible = true;
            ZoomControlPosition = ControlPosition.TopLeft;
            ZoomControlStyle = ZoomControlStyle.Default;
            ScaleControlVisible = false;
            Height = 0;
            Width = 0;
            UseCurrentPosition = false;
        }

        #endregion

        #region Public Properties

        public string Id { get; internal set; }

        public string Address { get; set; }

        public string ApiKey { get; internal set; }

        public GoogleMapClientEvents ClientEvents { get; private set; }

        public MarkerClientEvents MarkerClientEvents { get; private set; }

        public CultureInfo Culture { get; set; }

        public bool DisableDoubleClickZoom { get; set; }

        public bool Draggable { get; set; }

        public bool EnableMarkersClustering { get; set; }

        public int Height { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public IList<Layer> Layers { get; private set; }

        public string MapTypeId { get; set; }

        public MapTypeControlStyle MapTypeControlStyle { get; set; }

        public ControlPosition MapTypeControlPosition { get; set; }

        public bool MapTypeControlVisible { get; set; }

        public IList<ImageMapType> ImageMapTypes { get; private set; }

        public IList<StyledMapType> StyledMapTypes { get; private set; }

        public IList<Marker> Markers { get; private set; }

        public bool MarkersGeocoding { get; set; }

        public bool FitToMarkersBounds { get; set; }

        public MarkerClusteringOptions MarkerClusteringOptions { get; private set; }

        public int MaxZoom { get; set; }

        public int MinZoom { get; set; }

        public ControlPosition PanControlPosition { get; set; }

        public bool PanControlVisible { get; set; }

        public bool OverviewMapControlVisible { get; set; }

        public bool OverviewMapControlOpened { get; set; }

        public IList<Polygon> Polygons { get; private set; }

        public IList<Circle> Circles { get; private set; }

        public bool ScaleControlVisible { get; set; }

        public List<string> ScriptFileNames { get; private set; }

        public bool StreetViewControlVisible { get; set; }

        public ControlPosition StreetViewControlPosition { get; set; }

        public bool UseCurrentPosition { get; set; }

        public string Version { get; set; }

        public int Width { get; set; }

        public int Zoom { get; set; }

        public bool ZoomControlVisible { get; set; }

        public ControlPosition ZoomControlPosition { get; set; }

        public ZoomControlStyle ZoomControlStyle { get; set; }

        #endregion

        #region Virtual Methods

        public virtual void WriteInitializationScript(TextWriter writer)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var objectWriter = new ClientSideObjectWriter(Id, "GoogleMap", writer);

            objectWriter.Start();

            objectWriter.Append("clientId", Id);
            objectWriter.Append("disableDoubleClickZoom", DisableDoubleClickZoom, false);
            objectWriter.Append("draggable", Draggable, true);
            objectWriter.Append("enableMarkersClustering", EnableMarkersClustering, false);
            objectWriter.Append("markersFromAddress", MarkersGeocoding, false);
            objectWriter.Append("fitToMarkersBounds", FitToMarkersBounds, false);

            if (Address.HasValue())
            {
                objectWriter.AppendObject("center", new { Address });    
            }
            else
            {
                objectWriter.AppendObject("center", new { Latitude, Longitude, UseCurrentPosition });    
            }
            
            objectWriter.Append("mapTypeId", MapTypeId);
            objectWriter.Append("mapTypeControlPosition", MapTypeControlPosition, ControlPosition.TopRight);
            objectWriter.Append("mapTypeControlVisible", MapTypeControlVisible, true);
            objectWriter.Append("mapTypeControlStyle", MapTypeControlStyle, MapTypeControlStyle.Default);

            if (Layers.Any())
            {
                var layers = new List<IDictionary<string, object>>();

                Layers.Each(l => layers.Add(l.CreateSerializer().Serialize()));

                if (layers.Any())
                {
                    objectWriter.AppendCollection("layers", layers);
                }
            }

            if (ImageMapTypes.Any())
            {
                if (!ImageMapTypes.Select(mt => mt.MapTypeName).Contains(MapTypeId))
                {
                    throw new Exception("Cannot find the MapTypeId in the ImageMapTypes collection");
                }

                var mapTypes = new List<IDictionary<string, object>>();

                ImageMapTypes.Each(m => mapTypes.Add(m.CreateSerializer().Serialize()));

                if (mapTypes.Any())
                {
                    objectWriter.AppendCollection("imageMapTypes", mapTypes);
                }
            }

            if (StyledMapTypes.Any())
            {
                var mapTypes = new List<IDictionary<string, object>>();

                StyledMapTypes.Each(m => mapTypes.Add(m.CreateSerializer().Serialize()));

                if (mapTypes.Any())
                {
                    objectWriter.AppendCollection("styledMapTypes", mapTypes);
                }
            }

            objectWriter.Append("panControlPosition", PanControlPosition, ControlPosition.TopLeft);
            objectWriter.Append("panControlVisible", PanControlVisible, true);

            objectWriter.Append("overviewMapControlVisible", OverviewMapControlVisible, false);
            objectWriter.Append("overviewMapControlOpened", OverviewMapControlOpened, false);

            objectWriter.Append("streetViewControlVisible", StreetViewControlVisible, true);
            objectWriter.Append("streetViewControlPosition", StreetViewControlPosition, ControlPosition.TopLeft);

            objectWriter.Append("zoomControlVisible", ZoomControlVisible, true);
            objectWriter.Append("zoomControlPosition", ZoomControlPosition, ControlPosition.TopLeft);
            objectWriter.Append("zoomControlStyle", ZoomControlStyle, ZoomControlStyle.Default);


            objectWriter.Append("scaleControlVisible", ScaleControlVisible, false);
            objectWriter.Append("zoom", (Zoom == 0) ? 6 : Zoom, 6);
            objectWriter.Append("minZoom", MinZoom, 0);
            objectWriter.Append("maxZoom", MaxZoom, 0);

            if (EnableMarkersClustering)
            {
                objectWriter.AppendObject("markerClusteringOptions", MarkerClusteringOptions.Serialize());
            }

            if (Markers.Any())
            {
                var markers = new List<IDictionary<string, object>>();
                int i = 0;
                Markers.Each(m =>
                {
                    if (String.IsNullOrWhiteSpace(m.Id))
                    {
                        m.Id = i.ToString();
                    }
                    markers.Add(m.CreateSerializer().Serialize());
                    i++;
                });

                if (markers.Any())
                {
                    objectWriter.AppendCollection("markers", markers);
                }

                objectWriter.AppendClientEventObject("markerEvents", this.MarkerClientEvents);
            }

            if (Polygons.Any())
            {
                var polygons = new List<IDictionary<string, object>>();

                Polygons.Each(p => polygons.Add(p.CreateSerializer().Serialize()));

                if (polygons.Any())
                {
                    objectWriter.AppendCollection("polygons", polygons);
                }
            }

            if (Circles.Any())
            {
                var circles = new List<IDictionary<string, object>>();

                Circles.Each(c => circles.Add(c.CreateSerializer().Serialize()));

                if (circles.Any())
                {
                    objectWriter.AppendCollection("circles", circles);
                }
            }

            this.ClientEvents.SerializeTo(objectWriter);

            //TODO: Call a virtual method OnCompleting to allow derived class to inject its own json objects

            objectWriter.Complete();

            Thread.CurrentThread.CurrentCulture = currentCulture;
        }

        protected virtual void WriteHtml(HtmlTextWriter writer)
        {
            if (writer == null) throw new ArgumentNullException("writer");

            IHtmlNode rootTag = builder.Build();
            rootTag.WriteTo(writer);

            var languaje = (Culture != null) ? "&language=" + Culture.TwoLetterISOLanguageName : String.Empty;
            var key = (ApiKey.HasValue()) ? "&key=" + ApiKey : String.Empty;
            var visualization = Layers.Any(l => l.GetType() == typeof (HeatmapLayer)) ? "&libraries=visualization" : "";
            var isAjax = builder.ViewContext.HttpContext.Request.IsAjaxRequest() ? "&callback=executeAsync" : "";
            var version = (String.IsNullOrWhiteSpace(Version)) ? "" : ("v=" + Version);
            var mainJs = String.Format("https://maps.googleapis.com/maps/api/js?{0}{1}{2}{3}{4}", version, key, languaje, visualization, isAjax);
                                                                                    
            ScriptFileNames.Add(mainJs);

            if (EnableMarkersClustering)
                ScriptFileNames.Add("markerclusterer.js");

            if (Markers.Any(m => m.Window != null))
            {
                //Build Container for InfoWindows
                IHtmlNode infoWindowsRootTag = new HtmlElement("div")
                    .Attribute("id", String.Format("{0}-InfoWindowsHolder", Id))
                    .Attribute("style", "display: none");

                Markers.Where(m => m.Window != null).Each(m =>
                {
                    IHtmlNode markerInfoWindows = new HtmlElement("div")
                        .Attribute("id", String.Format("{0}Marker{1}", Id, m.Index))
                        .AddClass("content");

                    m.Window.Template.Apply(markerInfoWindows);
                    infoWindowsRootTag.Children.Add(markerInfoWindows);
                });

                infoWindowsRootTag.WriteTo(writer);
            }
        }
        
        public virtual void BindTo<TMapObject, TDataItem>(IEnumerable<TDataItem> dataSource, Action<MapObjectBindingFactory<TMapObject>> action) where TMapObject : MapObject
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new MapObjectBindingFactory<TMapObject>();
            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                MapObject mapObject = null;

                switch (typeof(TMapObject).FullName)
                {
                    case "Jmelosegui.Mvc.Googlemap.Objects.Marker":
                        mapObject = new Marker(this);
                        Markers.Add((Marker)mapObject);
                        break;
                    case "Jmelosegui.Mvc.Googlemap.Objects.Circle":
                        mapObject = new Circle(this);
                        Circles.Add((Circle)mapObject);
                        break;
                    case "Jmelosegui.Mvc.Googlemap.Objects.Polygon":
                        mapObject = new Polygon(this);
                        Polygons.Add((Polygon)mapObject);
                        break;
                }

                factory.Binder.ItemDataBound((TMapObject)mapObject, dataItem);
            }
        }

        #endregion
        
        public void Render()
        {
            TextWriter writer = builder.ViewContext.Writer;
            using (HtmlTextWriter htmlTextWriter = new HtmlTextWriter(writer))
            {
                this.WriteHtml(htmlTextWriter);
            }
        }

        public string ToHtmlString()
        {
            string result;
            using (StringWriter stringWriter = new StringWriter())
            {
                this.WriteHtml(new HtmlTextWriter(stringWriter));
                result = stringWriter.ToString();
            }
            return result;
        }
    }
}
