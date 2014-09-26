using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMapClientEventsBuilder : IHideObjectMembers
    {
        private readonly GoogleMapClientEvents clientEvents;

        public GoogleMapClientEventsBuilder(GoogleMapClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            this.clientEvents = clientEvents;
        }

        public GoogleMapClientEventsBuilder OnMapBoundChanged(string onMapBoundChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapBoundChangedHandlerName)) throw new ArgumentNullException("onMapBoundChangedHandlerName");

            clientEvents.OnMapBoundChanged.HandlerName = onMapBoundChangedHandlerName;

            return this;
        }
        public GoogleMapClientEventsBuilder OnMapCenterChanged(string onMapCenterChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapCenterChangedHandlerName)) throw new ArgumentNullException("onMapCenterChangedHandlerName");

            clientEvents.OnMapCenterChanged.HandlerName = onMapCenterChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapClick(string onMapClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMapClickHandlerName)) throw new ArgumentNullException("onMapClickHandlerName");

            clientEvents.OnMapClick.HandlerName = onMapClickHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDobleClick(string onMapDobleClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDobleClickHandlerName)) throw new ArgumentNullException("onMapDobleClickHandlerName");

            clientEvents.OnMapDobleClick.HandlerName = onMapDobleClickHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapRightClick(string onMapRightClickkHandlerName)
        {
            if (String.IsNullOrEmpty(onMapRightClickkHandlerName)) throw new ArgumentNullException("onMapRightClickkHandlerName");

            clientEvents.OnMapRightClick.HandlerName = onMapRightClickkHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDrag(string onMapDragHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragHandlerName)) throw new ArgumentNullException("onMapDragHandlerName");

            clientEvents.OnMapDrag.HandlerName = onMapDragHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragEnd(string onMapDragEndHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragEndHandlerName)) throw new ArgumentNullException("onMapDragEndHandlerName");

            clientEvents.OnMapDragEnd.HandlerName = onMapDragEndHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragStart(string onMapDragStartHandlerName)
        {
            if (String.IsNullOrEmpty(onMapDragStartHandlerName)) throw new ArgumentNullException("onMapDragStartHandlerName");

            clientEvents.OnMapDragStart.HandlerName = onMapDragStartHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapHeadingChanged(string onMapHeadingChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapHeadingChangedHandlerName)) throw new ArgumentNullException("onMapHeadingChangedHandlerName");

            clientEvents.OnMapHeadingChanged.HandlerName = onMapHeadingChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapIdle(string onMapIdleHandlerName)
        {
            if (String.IsNullOrEmpty(onMapIdleHandlerName)) throw new ArgumentNullException("onMapIdleHandlerName");

            clientEvents.OnMapIdle.HandlerName = onMapIdleHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapTypeIdChanged(string onMapTypeIdChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapTypeIdChangedHandlerName)) throw new ArgumentNullException("onMapTypeIdChangedHandlerName");

            clientEvents.OnMapTypeIdChanged.HandlerName = onMapTypeIdChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseMove(string onMouseMoveHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseMoveHandlerName)) throw new ArgumentNullException("onMouseMoveHandlerName");

            clientEvents.OnMouseMove.HandlerName = onMouseMoveHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOut(string onMouseOutHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseOutHandlerName)) throw new ArgumentNullException("onMouseOutHandlerName");

            clientEvents.OnMouseOut.HandlerName = onMouseOutHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOver(string onMouseOverHandlerName)
        {
            if (String.IsNullOrEmpty(onMouseOverHandlerName)) throw new ArgumentNullException("onMouseOverHandlerName");

            clientEvents.OnMouseOver.HandlerName = onMouseOverHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapProjectionChanged(string onMapProjectionChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMapProjectionChangedHandlerName)) throw new ArgumentNullException("onMapProjectionChangedHandlerName");

            clientEvents.OnMapProjectionChanged.HandlerName = onMapProjectionChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnResize(string onResizeHandlerName)
        {
            if (String.IsNullOrEmpty(onResizeHandlerName)) throw new ArgumentNullException("onResizeHandlerName");

            clientEvents.OnResize.HandlerName = onResizeHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTilesLoaded(string onTilesLoadedHandlerName)
        {
            if (String.IsNullOrEmpty(onTilesLoadedHandlerName)) throw new ArgumentNullException("onTilesLoadedHandlerName");

            clientEvents.OnTilesLoaded.HandlerName = onTilesLoadedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTiltChanged(string onTiltChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onTiltChangedHandlerName)) throw new ArgumentNullException("onTiltChangedHandlerName");

            clientEvents.OnTiltChanged.HandlerName = onTiltChangedHandlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnZoomChanged(string onZoomChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onZoomChangedHandlerName)) throw new ArgumentNullException("onZoomChangedHandlerName");

            clientEvents.OnZoomChanged.HandlerName = onZoomChangedHandlerName;

            return this;
        }
    }
}
