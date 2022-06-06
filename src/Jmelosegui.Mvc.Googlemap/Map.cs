// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.Encodings.Web;
    using System.Threading;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class Map
    {
        private readonly MapBuilder builder;

        public Map(MapBuilder builder)
        {
            this.builder = builder;
            this.ScriptFileNames = new Collection<string>();
            this.Initialize();
        }

        public string Id { get; internal set; }

        public string Address { get; set; }

        public string ApiKey { get; internal set; }

        public MapClientEvents ClientEvents { get; private set; }

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

        public IList<Polyline> Polylines { get; private set; }

        public IList<Circle> Circles { get; private set; }

        public bool ScaleControlVisible { get; set; }

        public bool ScrollWheel { get; set; }

        public Collection<string> ScriptFileNames { get; private set; }

        public bool StreetViewControlVisible { get; set; }

        public ControlPosition StreetViewControlPosition { get; set; }

        public bool UseCurrentPosition { get; set; }

        public string Version { get; set; }

        public int Width { get; set; }

        public int Zoom { get; set; }

        public bool ZoomControlVisible { get; set; }

        public ControlPosition ZoomControlPosition { get; set; }

        public ZoomControlStyle ZoomControlStyle { get; set; }

        public string[] Libraries { get; set; }

        internal ViewContext ViewContext
        {
            get { return this.builder.ViewContext; }
        }

        internal bool LoadScripts { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public virtual void BindTo<TMapObject, TDataItem>(IEnumerable<TDataItem> dataSource, Action<MapObjectBindingFactory<TMapObject>> action)
            where TMapObject : MapObject
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new MapObjectBindingFactory<TMapObject>();
            action(factory);

            foreach (TDataItem dataItem in dataSource)
            {
                MapObject mapObject = null;

                switch (typeof(TMapObject).FullName)
                {
                    case "Jmelosegui.Mvc.GoogleMap.Marker":
                        mapObject = new Marker(this);
                        this.Markers.Add((Marker)mapObject);
                        break;
                    case "Jmelosegui.Mvc.GoogleMap.Circle":
                        mapObject = new Circle(this);
                        this.Circles.Add((Circle)mapObject);
                        break;
                    case "Jmelosegui.Mvc.GoogleMap.Polygon":
                        mapObject = new Polygon(this);
                        this.Polygons.Add((Polygon)mapObject);
                        break;
                    case "Jmelosegui.Mvc.GoogleMap.Polyline":
                        mapObject = new Polyline(this);
                        this.Polylines.Add((Polyline)mapObject);
                        break;
                }

                factory.Binder.ItemDataBound((TMapObject)mapObject, dataItem);
            }
        }

        public void Render()
        {
            this.WriteHtml(this.builder.ViewContext.Writer);
        }

        protected internal virtual void WriteInitializationScript(TextWriter writer)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            var objectWriter = new ClientSideObjectWriter(this.Id, "GoogleMap", writer);

            objectWriter.Start();

            objectWriter.Append("clientId", this.Id);
            objectWriter.Append("disableDoubleClickZoom", this.DisableDoubleClickZoom, false);
            objectWriter.Append("draggable", this.Draggable, true);
            objectWriter.Append("enableMarkersClustering", this.EnableMarkersClustering, false);
            objectWriter.Append("markersFromAddress", this.MarkersGeocoding, false);
            objectWriter.Append("fitToMarkersBounds", this.FitToMarkersBounds, false);

            if (this.Address.HasValue())
            {
                objectWriter.AppendObject("center", new { this.Address });
            }
            else
            {
                objectWriter.AppendObject("center", new { this.Latitude, this.Longitude, this.UseCurrentPosition });
            }

            objectWriter.Append("mapTypeId", this.MapTypeId);
            objectWriter.Append("mapTypeControlPosition", this.MapTypeControlPosition, ControlPosition.TopRight);
            objectWriter.Append("mapTypeControlVisible", this.MapTypeControlVisible, true);
            objectWriter.Append("mapTypeControlStyle", this.MapTypeControlStyle, MapTypeControlStyle.Default);
            objectWriter.Append("panControlPosition", this.PanControlPosition, ControlPosition.TopLeft);
            objectWriter.Append("panControlVisible", this.PanControlVisible, true);
            objectWriter.Append("overviewMapControlVisible", this.OverviewMapControlVisible, false);
            objectWriter.Append("overviewMapControlOpened", this.OverviewMapControlOpened, false);
            objectWriter.Append("streetViewControlVisible", this.StreetViewControlVisible, true);
            objectWriter.Append("scrollwheel", this.ScrollWheel, true);
            objectWriter.Append("streetViewControlPosition", this.StreetViewControlPosition, ControlPosition.TopLeft);
            objectWriter.Append("zoomControlVisible", this.ZoomControlVisible, true);
            objectWriter.Append("zoomControlPosition", this.ZoomControlPosition, ControlPosition.TopLeft);
            objectWriter.Append("zoomControlStyle", this.ZoomControlStyle, ZoomControlStyle.Default);
            objectWriter.Append("scaleControlVisible", this.ScaleControlVisible, false);
            objectWriter.Append("zoom", (this.Zoom == 0) ? 6 : this.Zoom, 6);
            objectWriter.Append("minZoom", this.MinZoom, 0);
            objectWriter.Append("maxZoom", this.MaxZoom, 0);

            this.SerializeLyers(objectWriter);
            this.SerializeMapTypes(objectWriter);
            this.SerializeMarkers(objectWriter);
            this.SerializeShapes(objectWriter);

            this.ClientEvents.SerializeTo(objectWriter);

            // TODO: Call a virtual method OnCompleting to allow derived class to inject its own json objects
            objectWriter.Complete();

            Thread.CurrentThread.CurrentCulture = currentCulture;
        }

        protected internal virtual void WriteHtml(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            IHtmlContent rootTag = this.builder.Build();
            rootTag.WriteTo(writer, HtmlEncoder.Default);

            this.PrepareScripts();

            if (this.Markers.Any(m => m.Window != null))
            {
                // Build Container for InfoWindows
                var infoWindowsRootTag = new TagBuilder("div");
                infoWindowsRootTag.Attributes["id"] = string.Format(CultureInfo.InvariantCulture, "{0}-InfoWindowsHolder", this.Id);
                infoWindowsRootTag.Attributes["style"] = "display: none";

                this.Markers.Where(m => m.Window != null).Each(m =>
                {
                    var markerInfoWindows = new TagBuilder("div");
                    markerInfoWindows.Attributes["id"] = string.Format(CultureInfo.InvariantCulture, "{0}Marker{1}", this.Id, m.Index);
                    markerInfoWindows.AddCssClass("content");

                    m.Window.Template.Apply(null, markerInfoWindows);
                    infoWindowsRootTag.InnerHtml.AppendHtml(markerInfoWindows);
                });

                infoWindowsRootTag.WriteTo(writer, HtmlEncoder.Default);
            }
        }

        private void PrepareScripts()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            List<string> libraries = new List<string>();

            var request = this.builder.ViewContext.HttpContext.Request;

            if (this.Culture != null)
            {
                parameters.Add("language", this.Culture.TwoLetterISOLanguageName);
            }

            if (this.ApiKey.HasValue())
            {
                parameters.Add("key", this.ApiKey);
            }

            if (this.Layers.Any(l => l.GetType() == typeof(HeatmapLayer)))
            {
                libraries.Add("visualization");
            }

            if (request.IsAjaxRequest())
            {
                parameters.Add("callback", "executeAsync");
            }

            if (!string.IsNullOrWhiteSpace(this.Version))
            {
                parameters.Add("v", this.Version);
            }

            /* Here starts the url composition */

            if (this.Libraries != null)
            {
                libraries.AddRange(this.Libraries);
            }

            string librariesParameterValue = string.Join(",", libraries.Select(l => l.ToLower()).Distinct().ToArray());
            if (!string.IsNullOrEmpty(librariesParameterValue))
            {
                parameters.Add("libraries", librariesParameterValue);
            }

            string queryString = string.Join("&", parameters.Select(dictionaryItem => string.Format("{0}={1}", dictionaryItem.Key, dictionaryItem.Value)));
            var mainJs = string.Format(CultureInfo.InvariantCulture, "https://maps.googleapis.com/maps/api/js?{0}", queryString);

            /* Here ends the url composition */

            this.LoadScripts = this.ShouldLoadGoogleScript();
            if (this.LoadScripts)
            {
                this.ScriptFileNames.Add(mainJs);
            }

            if (!request.IsAjaxRequest())
            {
                this.ScriptFileNames.Add("jmelosegui.googlemap-nojquery.js");

                if (this.EnableMarkersClustering)
                {
                    this.ScriptFileNames.Add("markerclusterer.js");
                }
            }
        }

        private bool ShouldLoadGoogleScript()
        {
            var request = this.builder.ViewContext.HttpContext.Request;
            if (!request.IsAjaxRequest())
            {
                return true;
            }

            if (new[] { "GET", "POST" }.All(method => method != request.Method.ToUpper(CultureInfo.InvariantCulture)))
            {
                return true;
            }

            if (request.Method.ToUpper(CultureInfo.InvariantCulture) == "GET")
            {
                bool result;
                if (bool.TryParse(request.Query["__LoadGoogleMapScript__"], out result))
                {
                    return result;
                }
            }

            if (request.Method.ToUpper(CultureInfo.InvariantCulture) == "POST")
            {
                bool result;
                if (bool.TryParse(request.Form["__LoadGoogleMapScript__"], out result))
                {
                    return result;
                }
            }

            return true;
        }

        private void SerializeLyers(ClientSideObjectWriter objectWriter)
        {
            if (this.Layers.Any())
            {
                var layers = new List<IDictionary<string, object>>();

                this.Layers.Each(l => layers.Add(l.CreateSerializer().Serialize()));

                if (layers.Any())
                {
                    objectWriter.AppendCollection("layers", layers);
                }
            }
        }

        private void SerializeMarkers(ClientSideObjectWriter objectWriter)
        {
            if (this.EnableMarkersClustering)
            {
                objectWriter.AppendObject("markerClusteringOptions", this.MarkerClusteringOptions.Serialize());
            }

            if (this.Markers.Any())
            {
                var markers = new List<IDictionary<string, object>>();
                int i = 0;
                this.Markers.Each(m =>
                {
                    if (string.IsNullOrWhiteSpace(m.Id))
                    {
                        m.Id = i.ToString(CultureInfo.InvariantCulture);
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
        }

        private void SerializeMapTypes(ClientSideObjectWriter objectWriter)
        {
            if (this.ImageMapTypes.Any())
            {
                if (!this.ImageMapTypes.Select(mt => mt.MapTypeName).Contains(this.MapTypeId))
                {
                    throw new InvalidOperationException("Cannot find the MapTypeId in the ImageMapTypes collection");
                }

                var mapTypes = new List<IDictionary<string, object>>();

                this.ImageMapTypes.Each(m => mapTypes.Add(m.CreateSerializer().Serialize()));

                if (mapTypes.Any())
                {
                    objectWriter.AppendCollection("imageMapTypes", mapTypes);
                }
            }

            if (this.StyledMapTypes.Any())
            {
                var mapTypes = new List<IDictionary<string, object>>();

                this.StyledMapTypes.Each(m => mapTypes.Add(m.CreateSerializer().Serialize()));

                if (mapTypes.Any())
                {
                    objectWriter.AppendCollection("styledMapTypes", mapTypes);
                }
            }
        }

        private void SerializeShapes(ClientSideObjectWriter objectWriter)
        {
            if (this.Polylines.Any())
            {
                var polylines = new List<IDictionary<string, object>>();

                this.Polylines.Each(p => polylines.Add(p.CreateSerializer().Serialize()));

                if (polylines.Any())
                {
                    objectWriter.AppendCollection("polylines", polylines);
                }
            }

            if (this.Polygons.Any())
            {
                var polygons = new List<IDictionary<string, object>>();

                this.Polygons.Each(p => polygons.Add(p.CreateSerializer().Serialize()));

                if (polygons.Any())
                {
                    objectWriter.AppendCollection("polygons", polygons);
                }
            }

            if (this.Circles.Any())
            {
                var circles = new List<IDictionary<string, object>>();

                this.Circles.Each(c => circles.Add(c.CreateSerializer().Serialize()));

                if (circles.Any())
                {
                    objectWriter.AppendCollection("circles", circles);
                }
            }
        }

        private void Initialize()
        {
            this.Id = "map";
            this.ClientEvents = new MapClientEvents();
            this.MarkerClientEvents = new MarkerClientEvents();
            this.DisableDoubleClickZoom = false;
            this.Draggable = true;
            this.EnableMarkersClustering = false;
            this.Latitude = 23;
            this.Longitude = -82;
            this.Layers = new List<Layer>();
            this.MapTypeId = MapType.Roadmap.ToClientSideString();
            this.MapTypeControlPosition = ControlPosition.TopRight;
            this.MapTypeControlVisible = true;
            this.ImageMapTypes = new List<ImageMapType>();
            this.StyledMapTypes = new List<StyledMapType>();
            this.Markers = new List<Marker>();
            this.MarkerClusteringOptions = new MarkerClusteringOptions();
            this.Polygons = new List<Polygon>();
            this.Polylines = new List<Polyline>();
            this.Circles = new List<Circle>();
            this.PanControlPosition = ControlPosition.TopLeft;
            this.PanControlVisible = true;
            this.OverviewMapControlVisible = false;
            this.OverviewMapControlOpened = false;
            this.StreetViewControlVisible = true;
            this.StreetViewControlPosition = ControlPosition.TopLeft;
            this.ZoomControlVisible = true;
            this.ZoomControlPosition = ControlPosition.TopLeft;
            this.ZoomControlStyle = ZoomControlStyle.Default;
            this.ScaleControlVisible = false;
            this.ScrollWheel = true;
            this.Height = 0;
            this.Width = 0;
            this.UseCurrentPosition = false;
        }
    }
}
