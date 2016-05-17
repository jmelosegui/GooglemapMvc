// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Web;
    using System.Web.Mvc;

    public class MapBuilder : IHtmlString
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private readonly ScriptRegistrar scriptRegistrar;
        private Map component;

        public MapBuilder(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            this.ViewContext = viewContext;
            this.scriptRegistrar = (ScriptRegistrar)viewContext.HttpContext.Items[Key] ?? new ScriptRegistrar(viewContext);
        }

        public ViewContext ViewContext { get; private set; }

        protected internal Map Component
        {
            get
            {
                if (this.component == null)
                {
                    this.component = new Map(this);
                    this.scriptRegistrar.AddComponent(this.component);
                }

                return this.component;
            }
        }

        public MapBuilder ApiKey(string value)
        {
            this.Component.ApiKey = value;
            return this;
        }

        public IHtmlNode Build()
        {
            // TODO: Implement .Attributes(Component.HtmlAttributes);
            var content = new HtmlElement("div")
                .AddClass("googlemap")
                .Attribute("id", this.Component.Id);

            if (this.Component.Width != 0)
            {
                content.Css("width", this.Component.Width + "px");
            }

            if (this.Component.Height != 0)
            {
                content.Css("height", this.Component.Height + "px");
            }
            else
            {
                content.Css("height", "100%");
            }

            return content;
        }

        public MapBuilder Center(Action<CenterFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new CenterFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder Circles(Action<CircleFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new CircleFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder Culture(CultureInfo value)
        {
            this.Component.Culture = value;
            return this;
        }

        public MapBuilder DisableDoubleClickZoom(bool disabled)
        {
            this.Component.DisableDoubleClickZoom = disabled;
            return this;
        }

        public MapBuilder Draggable(bool enabled)
        {
            this.Component.Draggable = enabled;
            return this;
        }

        public MapBuilder EnableMarkersClustering()
        {
            return this.EnableMarkersClustering(null);
        }

        public MapBuilder EnableMarkersClustering(Action<MarkerClusteringOptionsFactory> action)
        {
            this.Component.EnableMarkersClustering = true;
            if (action != null)
            {
                var options = new MarkerClusteringOptionsFactory(this.Component);
                action(options);
            }

            return this;
        }

        public MapBuilder FitToMarkersBounds(bool value)
        {
            this.Component.FitToMarkersBounds = value;
            return this;
        }

        public MapBuilder Height(int value)
        {
            this.Component.Height = value;
            return this;
        }

        public MapBuilder ImageMapTypes(Action<ImageMapTypeFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new ImageMapTypeFactory(this.Component);
            action(factory);
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public MapBuilder Latitude(double value)
        {
            this.Component.Latitude = value;
            return this;
        }

        [Obsolete("This method is obsolete, use the Center method instead")]
        public MapBuilder Longitude(double value)
        {
            this.Component.Longitude = value;
            return this;
        }

        public MapBuilder Layers(Action<LayerFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new LayerFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder MapTypeId(MapType value)
        {
            this.Component.MapTypeId = value.ToClientSideString();
            return this;
        }

        public MapBuilder MapTypeId(string value)
        {
            this.Component.MapTypeId = value;
            return this;
        }

        public MapBuilder MarkersGeocoding(bool value)
        {
            this.Component.MarkersGeocoding = value;
            return this;
        }

        public MapBuilder MapTypeControlPosition(ControlPosition value)
        {
            this.Component.MapTypeControlPosition = value;
            return this;
        }

        public MapBuilder MapTypeControlVisible(bool visible)
        {
            this.Component.MapTypeControlVisible = visible;
            return this;
        }

        public MapBuilder MapTypeControlStyle(MapTypeControlStyle value)
        {
            this.Component.MapTypeControlStyle = value;
            return this;
        }

        public MapBuilder Markers(Action<MarkerFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new MarkerFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder MaxZoom(int value)
        {
            this.Component.MaxZoom = value;
            return this;
        }

        public MapBuilder MinZoom(int value)
        {
            this.Component.MinZoom = value;
            return this;
        }

        public MapBuilder Name(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.Component.Id = value;
            return this;
        }

        public MapBuilder PanControlPosition(ControlPosition controlPosition)
        {
            this.Component.PanControlPosition = controlPosition;
            return this;
        }

        public MapBuilder PanControlVisible(bool visible)
        {
            this.Component.PanControlVisible = visible;
            return this;
        }

        public MapBuilder OverviewMapControlOpened(bool opened)
        {
            this.Component.OverviewMapControlOpened = opened;
            return this;
        }

        public MapBuilder OverviewMapControlVisible(bool visible)
        {
            this.Component.OverviewMapControlVisible = visible;
            return this;
        }

        public MapBuilder Polygons(Action<PolygonFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new PolygonFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder Polylines(Action<PolylineFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new PolylineFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder ScaleControlVisible(bool visible)
        {
            this.Component.ScaleControlVisible = visible;
            return this;
        }

        public MapBuilder ScrollWheel(bool enabled)
        {
            this.Component.ScrollWheel = enabled;
            return this;
        }

        public MapBuilder StreetViewControlVisible(bool visible)
        {
            this.Component.StreetViewControlVisible = visible;
            return this;
        }

        public MapBuilder StreetViewControlPosition(ControlPosition controlPosition)
        {
            this.Component.StreetViewControlPosition = controlPosition;
            return this;
        }

        public MapBuilder StyledMapTypes(Action<StyledMapTypeFactory> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var factory = new StyledMapTypeFactory(this.Component);
            action(factory);
            return this;
        }

        public MapBuilder Version(string value)
        {
            this.Component.Version = value;
            return this;
        }

        public MapBuilder Width(int value)
        {
            this.Component.Width = value;
            return this;
        }

        public MapBuilder Zoom(int value)
        {
            this.Component.Zoom = value;
            return this;
        }

        public MapBuilder ZoomControlPosition(ControlPosition controlPosition)
        {
            this.Component.ZoomControlPosition = controlPosition;
            return this;
        }

        public MapBuilder ZoomControlVisible(bool visible)
        {
            this.Component.ZoomControlVisible = visible;
            return this;
        }

        public MapBuilder ZoomControlStyle(ZoomControlStyle controlStyle)
        {
            this.Component.ZoomControlStyle = controlStyle;
            return this;
        }

        public MapBuilder Libraries(string[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            this.Component.Libraries = value;
            return this;
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public MapBuilder BindTo<T, TMapObject>(IEnumerable<T> dataSource, Action<MapObjectBindingFactory<TMapObject>> itemDataBound)
            where TMapObject : MapObject
        {
            this.Component.BindTo(dataSource, itemDataBound);
            return this;
        }

        public MapBuilder ClientEvents(Action<MapClientEventsBuilder> eventsBuilder)
        {
            if (eventsBuilder == null)
            {
                throw new ArgumentNullException(nameof(eventsBuilder));
            }

            eventsBuilder(new MapClientEventsBuilder(this.Component.ClientEvents));

            return this;
        }

        public MapBuilder MarkerEvents(Action<MarkerEventsBuilder> eventsBuilder)
        {
            if (eventsBuilder == null)
            {
                throw new ArgumentNullException(nameof(eventsBuilder));
            }

            eventsBuilder(new MarkerEventsBuilder(this.Component.MarkerClientEvents));

            return this;
        }

        public ScriptRegistrarBuilder ScriptRegistrar()
        {
            return new ScriptRegistrarBuilder(this.scriptRegistrar);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public ScriptRegistrarBuilder ScriptRegistrar(Action<IList<string>> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            action(this.scriptRegistrar.FixedScriptCollection);
            return new ScriptRegistrarBuilder(this.scriptRegistrar);
        }

        public virtual void Render()
        {
            this.Component.Render();
        }

        public string ToHtmlString()
        {
            return this.Component.ToHtmlString();
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }
    }
}