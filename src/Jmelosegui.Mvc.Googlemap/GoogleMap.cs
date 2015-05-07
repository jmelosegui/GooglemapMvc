using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.UI;
using Jmelosegui.Mvc.Googlemap.Overlays;

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

        public int Width { get; set; }

        public int Zoom { get; set; }

        public bool ZoomControlVisible { get; set; }

        public ControlPosition ZoomControlPosition { get; set; }

        public ZoomControlStyle ZoomControlStyle { get; set; }

        public bool UseCurrentPosition { get; set; }

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

            objectWriter.Append("height", Height);

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
            objectWriter.Append("width", Width, 0);
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

                Markers.Each(m => markers.Add(m.CreateSerializer().Serialize()));

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

            var mainJs = String.Format("https://maps.googleapis.com/maps/api/js?v=3.exp{0}{1}", key, languaje);
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
        
        public virtual void BindTo<TGoogleMapOverlay, TDataItem>(IEnumerable<TDataItem> dataSource, Action<OverlayBindingFactory<TGoogleMapOverlay>> action)
            where TGoogleMapOverlay : Overlay
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new OverlayBindingFactory<TGoogleMapOverlay>();
            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                Overlay overlay = null;

                switch (typeof(TGoogleMapOverlay).FullName)
                {
                    case "Jmelosegui.Mvc.Googlemap.Overlays.Marker":
                        overlay = new Marker(this);
                        Markers.Add((Marker)overlay);
                        break;
                    case "Jmelosegui.Mvc.Googlemap.Overlays.Circle":
                        overlay = new Circle(this);
                        Circles.Add((Circle)overlay);
                        break;
                    case "Jmelosegui.Mvc.Googlemap.Overlays.Polygon":
                        overlay = new Polygon(this);
                        Polygons.Add((Polygon)overlay);
                        break;
                }

                factory.Binder.ItemDataBound((TGoogleMapOverlay)overlay, dataItem);
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
