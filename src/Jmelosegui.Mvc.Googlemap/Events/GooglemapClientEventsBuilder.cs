using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMapClientEventsBuilder : IHideObjectMembers
    {
        protected GoogleMapClientEventsBuilder(GoogleMapClientEventsBuilder builder)
            : this(builder.ClientEvents)
        {
        }

        public GoogleMapClientEventsBuilder(GoogleMapClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            this.ClientEvents = clientEvents;
        }

        protected GoogleMapClientEvents ClientEvents { get; private set; }

        public GoogleMapClientEventsBuilder OnMapBoundChanged(string onMapBoundChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapBoundChangedHandlerName)) throw new ArgumentNullException("onMapBoundChangedHandlerName");

            ClientEvents.OnMapBoundChanged.HandlerName = onMapBoundChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapCenterChanged(string onMapCenterChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapCenterChangedHandlerName)) throw new ArgumentNullException("onMapCenterChangedHandlerName");

            ClientEvents.OnMapCenterChanged.HandlerName = onMapCenterChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapClick(string onMapClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMapClickHandlerName)) throw new ArgumentNullException("onMapClickHandlerName");

            ClientEvents.OnMapClick.HandlerName = onMapClickHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDobleClick(string onMapDobleClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDobleClickHandlerName)) throw new ArgumentNullException("onMapDobleClickHandlerName");

            ClientEvents.OnMapDobleClick.HandlerName = onMapDobleClickHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapRightClick(string onMapRightClickkHandlerName)
        {
            if (String.IsNullOrEmpty(onMapRightClickkHandlerName)) throw new ArgumentNullException("onMapRightClickkHandlerName");

            ClientEvents.OnMapRightClick.HandlerName = onMapRightClickkHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDrag(string onMapDragHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragHandlerName)) throw new ArgumentNullException("onMapDragHandlerName");

            ClientEvents.OnMapDrag.HandlerName = onMapDragHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragEnd(string onMapDragEndHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragEndHandlerName)) throw new ArgumentNullException("onMapDragEndHandlerName");

            ClientEvents.OnMapDragEnd.HandlerName = onMapDragEndHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragStart(string onMapDragStartHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragStartHandlerName)) throw new ArgumentNullException("onMapDragStartHandlerName");

            ClientEvents.OnMapDragStart.HandlerName = onMapDragStartHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapHeadingChanged(string onMapHeadingChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapHeadingChangedHandlerName)) throw new ArgumentNullException("onMapHeadingChangedHandlerName");

            ClientEvents.OnMapHeadingChanged.HandlerName = onMapHeadingChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapIdle(string onMapIdleHandlerName)
        {
            if (String.IsNullOrEmpty(onMapIdleHandlerName)) throw new ArgumentNullException("onMapIdleHandlerName");

            ClientEvents.OnMapIdle.HandlerName = onMapIdleHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapTypeIdChanged(string onMapTypeIdChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapTypeIdChangedHandlerName)) throw new ArgumentNullException("onMapTypeIdChangedHandlerName");

            ClientEvents.OnMapTypeIdChanged.HandlerName = onMapTypeIdChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseMove(string onMouseMoveHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseMoveHandlerName)) throw new ArgumentNullException("onMouseMoveHandlerName");

            ClientEvents.OnMouseMove.HandlerName = onMouseMoveHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOut(string onMouseOutHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseOutHandlerName)) throw new ArgumentNullException("onMouseOutHandlerName");

            ClientEvents.OnMouseOut.HandlerName = onMouseOutHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOver(string onMouseOverHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseOverHandlerName)) throw new ArgumentNullException("onMouseOverHandlerName");

            ClientEvents.OnMouseOver.HandlerName = onMouseOverHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapProjectionChanged(string onMapProjectionChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapProjectionChangedHandlerName)) throw new ArgumentNullException("onMapProjectionChangedHandlerName");

            ClientEvents.OnMapProjectionChanged.HandlerName = onMapProjectionChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnResize(string onResizeHandlerName)
        {
            if (String.IsNullOrEmpty(onResizeHandlerName)) throw new ArgumentNullException("onResizeHandlerName");

            ClientEvents.OnResize.HandlerName = onResizeHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTilesLoaded(string onTilesLoadedHandlerName)
        {
            if (String.IsNullOrEmpty(onTilesLoadedHandlerName)) throw new ArgumentNullException("onTilesLoadedHandlerName");

            ClientEvents.OnTilesLoaded.HandlerName = onTilesLoadedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTiltChanged(string onTiltChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onTiltChangedHandlerName)) throw new ArgumentNullException("onTiltChangedHandlerName");

            ClientEvents.OnTiltChanged.HandlerName = onTiltChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnZoomChanged(string onZoomChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onZoomChangedHandlerName)) throw new ArgumentNullException("onZoomChangedHandlerName");

            ClientEvents.OnZoomChanged.HandlerName = onZoomChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapLoaded(string onMapLoad)
        {
            if (String.IsNullOrEmpty(onMapLoad)) throw new ArgumentNullException("onMapLoad");
            ClientEvents.OnMapLoaded.HandlerName = onMapLoad;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMarkersGeocodingCompleted(string onMarkersGeocodingCompleted)
        {
            if (String.IsNullOrEmpty(onMarkersGeocodingCompleted)) throw new ArgumentNullException("onMarkersGeocodingCompleted");
            ClientEvents.OnMarkersGeocodingCompleted.HandlerName = onMarkersGeocodingCompleted;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMarkersGeocodingProgress(string onMarkersGeocodingProgress)
        {
            if (String.IsNullOrEmpty(onMarkersGeocodingProgress)) throw new ArgumentNullException("onMarkersGeocodingProgress");
            ClientEvents.OnMarkersGeocodingProgress.HandlerName = onMarkersGeocodingProgress;

            return this;
        }
    }
}
