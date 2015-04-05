using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using Jmelosegui.Mvc.Googlemap.Overlays;

namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMapBuilder : IHtmlString
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private readonly ScriptRegistrar scriptRegistrar;

        public GoogleMapBuilder(GoogleMap component)
        {
            Component = component;
            scriptRegistrar = (ScriptRegistrar) component.ViewContext.HttpContext.Items[Key] ?? new ScriptRegistrar(Component);
        }

        public GoogleMap Component { get; private set; }

        #region Public Methods

        public GoogleMapBuilder ApiKey(string apiKey)
        {
            Component.ApiKey = apiKey;
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

            return content;
        }

        public GoogleMapBuilder Center(Action<CenterFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");

            var factory = new CenterFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder Circles(Action<CircleFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            
            var factory = new CircleFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder Culture(CultureInfo culture)
        {
            Component.Culture = culture;
            return this;
        }

        public GoogleMapBuilder DisableDoubleClickZoom(bool disabled)
        {
            Component.DisableDoubleClickZoom = disabled;
            return this;
        }

        public GoogleMapBuilder Draggable(bool enabled)
        {
            Component.Draggable = enabled;
            return this;
        }

        public GoogleMapBuilder EnableMarkersClustering()
        {
            return EnableMarkersClustering(null);
        }

        public GoogleMapBuilder EnableMarkersClustering(Action<MarkerClusteringOptionsFactory> action)
        {
            Component.EnableMarkersClustering = true;
            if(action != null){
                var options = new MarkerClusteringOptionsFactory(Component);
                action(options);
            }
            return this;
        }

        public GoogleMapBuilder Height(int value)
        {
            Component.Height = value;
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public GoogleMapBuilder Latitude(double value)
        {
            Component.Latitude = value;
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public GoogleMapBuilder Longitude(double value)
        {
            Component.Longitude = value;
            return this;
        }

        public GoogleMapBuilder MapTypeId(MapTypes value)
        {
            Component.MapTypeId = value.ToClientSideString();
            return this;
        }

        public GoogleMapBuilder MapTypeId(string value)
        {
            Component.MapTypeId = value;
            return this;
        }

        public GoogleMapBuilder ImageMapTypes(Action<ImageMapTypeFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new ImageMapTypeFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder StyledMapTypes(Action<StyledMapTypeFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new StyledMapTypeFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder MapTypeControlPosition(ControlPosition controlPosition)
        {
            Component.MapTypeControlPosition = controlPosition;
            return this;
        }

        public GoogleMapBuilder MapTypeControlVisible(bool visible)
        {
            Component.MapTypeControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder MapTypeControlStyle(MapTypeControlStyle value)
        {
            Component.MapTypeControlStyle = value;
            return this;
        }

        public GoogleMapBuilder Markers(Action<MarkerFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new MarkerFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder MaxZoom(int value)
        {
            Component.MaxZoom = value;
            return this;
        }

        public GoogleMapBuilder MinZoom(int value)
        {
            Component.MinZoom = value;
            return this;
        }

        public GoogleMapBuilder Name(string name)
        {
            if (name == null) throw new ArgumentNullException("name");
            Component.Id = name;
            return this;
        }

        public GoogleMapBuilder PanControlPosition(ControlPosition controlPosition)
        {
            Component.PanControlPosition = controlPosition;
            return this;
        }

        public GoogleMapBuilder PanControlVisible(bool visible)
        {
            Component.PanControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder OverviewMapControlOpened(bool opened)
        {
            Component.OverviewMapControlOpened = opened;
            return this;
        }

        public GoogleMapBuilder OverviewMapControlVisible(bool visible)
        {
            Component.OverviewMapControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder Polygons(Action<PolygonFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new PolygonFactory(Component);
            action(factory);
            return this;
        }

        public GoogleMapBuilder ScaleControlVisible(bool visible)
        {
            Component.ScaleControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder StreetViewControlVisible(bool visible)
        {
            Component.StreetViewControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder StreetViewControlPosition(ControlPosition controlPosition)
        {
            Component.StreetViewControlPosition = controlPosition;
            return this;
            
        }

        public GoogleMapBuilder Width(int value)
        {
            Component.Width = value;
            return this;
        }

        public GoogleMapBuilder Zoom(int value)
        {
            Component.Zoom = value;
            return this;
        }

        public GoogleMapBuilder ZoomControlPosition(ControlPosition controlPosition)
        {
            Component.ZoomControlPosition = controlPosition;
            return this;
        }

        public GoogleMapBuilder ZoomControlVisible(bool visible)
        {
            Component.ZoomControlVisible = visible;
            return this;
        }

        public GoogleMapBuilder ZoomControlStyle(ZoomControlStyle controlStyle)
        {
            Component.ZoomControlStyle = controlStyle;
            return this;
        }

        #endregion

        public GoogleMapBuilder BindTo<T, TOverlay>(IEnumerable<T> dataSource, Action<OverlayBindingFactory<TOverlay>> itemDataBound) where TOverlay : Overlay
        {
            Component.BindTo(dataSource, itemDataBound);
            return this;
        }

        public GoogleMapBuilder ClientEvents(Action<GoogleMapClientEventsBuilder> eventsBuilder)
        {
            if (eventsBuilder == null) throw new ArgumentNullException("eventsBuilder");

            eventsBuilder(new GoogleMapClientEventsBuilder(Component.ClientEvents));

            return this;
        }

        public GoogleMapBuilder MarkerEvents(Action<MarkerEventsBuilder> eventsBuilder)
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