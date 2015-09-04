using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MapClientEventsBuilder : IHideObjectMembers
    {
        protected MapClientEventsBuilder(MapClientEventsBuilder builder) : this(PassThroughNonNull(builder).ClientEvents)
        {
        }

        public MapClientEventsBuilder(MapClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            ClientEvents = clientEvents;
        }

        protected MapClientEvents ClientEvents { get; private set; }

        public MapClientEventsBuilder OnMapBoundChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapBoundChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapCenterChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapCenterChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDoubleClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDoubleClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapRightClick(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapRightClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDrag(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDrag.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDragEnd(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDragEnd.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDragStart(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapDragStart.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapHeadingChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapHeadingChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapIdle(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapIdle.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapTypeIdChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapTypeIdChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseMove(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseMove.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseOut(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseOut.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseOver(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMouseOver.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapProjectionChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnMapProjectionChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnResize(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnResize.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnTilesLoaded(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnTilesLoaded.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnTiltChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnTiltChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnZoomChanged(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");

            ClientEvents.OnZoomChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapLoaded(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMapLoaded.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMarkersGeocodingCompleted(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMarkersGeocodingCompleted.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMarkersGeocodingProgress(string handlerName)
        {
            if (String.IsNullOrEmpty(handlerName)) throw new ArgumentNullException("handlerName");
            ClientEvents.OnMarkersGeocodingProgress.HandlerName = handlerName;

            return this;
        }

        private static MapClientEventsBuilder PassThroughNonNull(MapClientEventsBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}
