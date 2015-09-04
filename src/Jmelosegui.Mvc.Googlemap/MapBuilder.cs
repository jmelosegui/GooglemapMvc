using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MapBuilder : IHtmlString
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private readonly ScriptRegistrar scriptRegistrar;
        private Map component;

        public MapBuilder(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException("viewContext");
            }

            this.ViewContext = viewContext;
            scriptRegistrar = (ScriptRegistrar)viewContext.HttpContext.Items[Key] ?? new ScriptRegistrar(viewContext);
        }

        protected internal Map Component
        {
            get
            {
                if (component == null)
                {
                    component = new Map(this);
                    scriptRegistrar.AddComponent(component);
                }
                return component;
            }
        }

        public ViewContext ViewContext { get; private set; }

        #region Public Methods

        public MapBuilder ApiKey(string value)
        {
            Component.ApiKey = value;
            return this;
        }

        public IHtmlNode Build()
        {
            var content = new HtmlElement("div")
                .AddClass("googlemap")
                .Attribute("id", Component.Id);
            //TODO: Implementar
            //.Attributes(Component.HtmlAttributes);

            if (Component.Width != 0)
            {
                content.Css("width", Component.Width + "px");
            }

            if (Component.Height != 0)
            {
                content.Css("height", Component.Height + "px");
            }
            else
            {
                content.Css("height", "100%");
            }

            return content;
        }

        public MapBuilder Center(Action<CenterFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new CenterFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder Circles(Action<CircleFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new CircleFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder Culture(CultureInfo value)
        {
            Component.Culture = value;
            return this;
        }

        public MapBuilder DisableDoubleClickZoom(bool disabled)
        {
            Component.DisableDoubleClickZoom = disabled;
            return this;
        }

        public MapBuilder Draggable(bool enabled)
        {
            Component.Draggable = enabled;
            return this;
        }

        public MapBuilder EnableMarkersClustering()
        {
            return EnableMarkersClustering(null);
        }

        public MapBuilder EnableMarkersClustering(Action<MarkerClusteringOptionsFactory> action)
        {
            Component.EnableMarkersClustering = true;
            if (action != null)
            {
                var options = new MarkerClusteringOptionsFactory(Component);
                action(options);
            }
            return this;
        }

        public MapBuilder FitToMarkersBounds(bool value)
        {
            Component.FitToMarkersBounds = value;
            return this;
        }

        public MapBuilder Height(int value)
        {
            Component.Height = value;
            return this;
        }

        public MapBuilder ImageMapTypes(Action<ImageMapTypeFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new ImageMapTypeFactory(Component);
            action(factory);
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public MapBuilder Latitude(double value)
        {
            Component.Latitude = value;
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public MapBuilder Longitude(double value)
        {
            Component.Longitude = value;
            return this;
        }

        public MapBuilder Layers(Action<LayerFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new LayerFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder MapTypeId(MapType value)
        {
            Component.MapTypeId = value.ToClientSideString();
            return this;
        }

        public MapBuilder MapTypeId(string value)
        {
            Component.MapTypeId = value;
            return this;
        }

        public MapBuilder MarkersGeocoding(bool value)
        {
            Component.MarkersGeocoding = value;
            return this;
        }

        public MapBuilder MapTypeControlPosition(ControlPosition value)
        {
            Component.MapTypeControlPosition = value;
            return this;
        }

        public MapBuilder MapTypeControlVisible(bool visible)
        {
            Component.MapTypeControlVisible = visible;
            return this;
        }

        public MapBuilder MapTypeControlStyle(MapTypeControlStyle value)
        {
            Component.MapTypeControlStyle = value;
            return this;
        }

        public MapBuilder Markers(Action<MarkerFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new MarkerFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder MaxZoom(int value)
        {
            Component.MaxZoom = value;
            return this;
        }

        public MapBuilder MinZoom(int value)
        {
            Component.MinZoom = value;
            return this;
        }

        public MapBuilder Name(string value)
        {
            if (value == null) throw new ArgumentNullException("value");
            Component.Id = value;
            return this;
        }

        public MapBuilder PanControlPosition(ControlPosition controlPosition)
        {
            Component.PanControlPosition = controlPosition;
            return this;
        }

        public MapBuilder PanControlVisible(bool visible)
        {
            Component.PanControlVisible = visible;
            return this;
        }

        public MapBuilder OverviewMapControlOpened(bool opened)
        {
            Component.OverviewMapControlOpened = opened;
            return this;
        }

        public MapBuilder OverviewMapControlVisible(bool visible)
        {
            Component.OverviewMapControlVisible = visible;
            return this;
        }

        public MapBuilder Polygons(Action<PolygonFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new PolygonFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder ScaleControlVisible(bool visible)
        {
            Component.ScaleControlVisible = visible;
            return this;
        }

        public MapBuilder StreetViewControlVisible(bool visible)
        {
            Component.StreetViewControlVisible = visible;
            return this;
        }

        public MapBuilder StreetViewControlPosition(ControlPosition controlPosition)
        {
            Component.StreetViewControlPosition = controlPosition;
            return this;

        }

        public MapBuilder StyledMapTypes(Action<StyledMapTypeFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new StyledMapTypeFactory(Component);
            action(factory);
            return this;
        }

        public MapBuilder Version(string value)
        {
            Component.Version = value;
            return this;
        }

        public MapBuilder Width(int value)
        {
            Component.Width = value;
            return this;
        }

        public MapBuilder Zoom(int value)
        {
            Component.Zoom = value;
            return this;
        }

        public MapBuilder ZoomControlPosition(ControlPosition controlPosition)
        {
            Component.ZoomControlPosition = controlPosition;
            return this;
        }

        public MapBuilder ZoomControlVisible(bool visible)
        {
            Component.ZoomControlVisible = visible;
            return this;
        }

        public MapBuilder ZoomControlStyle(ZoomControlStyle controlStyle)
        {
            Component.ZoomControlStyle = controlStyle;
            return this;
        }

        #endregion

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public MapBuilder BindTo<T, TMapObject>(IEnumerable<T> dataSource, Action<MapObjectBindingFactory<TMapObject>> itemDataBound) where TMapObject : MapObject
        {
            Component.BindTo(dataSource, itemDataBound);
            return this;
        }

        public MapBuilder ClientEvents(Action<MapClientEventsBuilder> eventsBuilder)
        {
            if (eventsBuilder == null) throw new ArgumentNullException("eventsBuilder");

            eventsBuilder(new MapClientEventsBuilder(Component.ClientEvents));

            return this;
        }

        public MapBuilder MarkerEvents(Action<MarkerEventsBuilder> eventsBuilder)
        {
            if (eventsBuilder == null) throw new ArgumentNullException("eventsBuilder");

            eventsBuilder(new MarkerEventsBuilder(Component.MarkerClientEvents));

            return this;
        }

        public ScriptRegistrarBuilder ScriptRegistrar()
        {
            return new ScriptRegistrarBuilder(scriptRegistrar);
        }

        public virtual void Render()
        {
            Component.Render();
        }

        public string ToHtmlString()
        {
            return Component.ToHtmlString();
        }

        public override string ToString()
        {
            return ToHtmlString();
        }
    }
}