using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMapClientEventsBuilder : IHideObjectMembers
    {
        protected GoogleMapClientEventsBuilder(GoogleMapClientEventsBuilder builder) : this(PassThroughNonNull(builder).ClientEvents)
        {
        }

        public GoogleMapClientEventsBuilder(GoogleMapClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            ClientEvents = clientEvents;
        }

        protected GoogleMapClientEvents ClientEvents { get; private set; }

        public GoogleMapClientEventsBuilder OnMapBoundChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapBoundChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapCenterChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapCenterChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapClick.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDoubleClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDoubleClick.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapRightClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapRightClick.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDrag(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDrag.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragEnd(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDragEnd.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapDragStart(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDragStart.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapHeadingChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapHeadingChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapIdle(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapIdle.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapTypeIdChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapTypeIdChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseMove(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseMove.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOut(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseOut.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMouseOver(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseOver.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapProjectionChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapProjectionChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnResize(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnResize.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTilesLoaded(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnTilesLoaded.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnTiltChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnTiltChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnZoomChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnZoomChanged.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMapLoaded(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMapLoaded.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMarkersGeocodingCompleted(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMarkersGeocodingCompleted.HandlerName = handlerName;

            return this;
        }

        public GoogleMapClientEventsBuilder OnMarkersGeocodingProgress(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMarkersGeocodingProgress.HandlerName = handlerName;

            return this;
        }

        private static GoogleMapClientEventsBuilder PassThroughNonNull(GoogleMapClientEventsBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}
