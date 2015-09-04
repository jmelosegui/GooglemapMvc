using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerEventsBuilder: IHideObjectMembers
    {
        protected MarkerEventsBuilder(MarkerEventsBuilder builder) : this(PassThroughNonNull(builder).ClientEvents)
        {
        }

        public MarkerEventsBuilder(MarkerClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            ClientEvents = clientEvents;
        }

        protected MarkerClientEvents ClientEvents { get; private set; }

        public MarkerEventsBuilder OnMarkerClick(string onMarkerClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerClickHandlerName)) throw new ArgumentNullException("onMarkerClickHandlerName");

            ClientEvents.OnMarkerClick.HandlerName = onMarkerClickHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDoubleClick(string onMarkerDoubleClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDoubleClickHandlerName)) throw new ArgumentNullException("onMarkerDoubleClickHandlerName");

            ClientEvents.OnMarkerDoubleClick.HandlerName = onMarkerDoubleClickHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDragStart(string onMarkerDragStartHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragStartHandlerName)) throw new ArgumentNullException("onMarkerDragStartHandlerName");

            ClientEvents.OnMarkerDragStart.HandlerName = onMarkerDragStartHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDrag(string onMarkerDragHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragHandlerName)) throw new ArgumentNullException("onMarkerDragHandlerName");

            ClientEvents.OnMarkerDrag.HandlerName = onMarkerDragHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDragEnd(string onMarkerDragEndHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragEndHandlerName)) throw new ArgumentNullException("onMarkerDragEndHandlerName");

            ClientEvents.OnMarkerDragEnd.HandlerName = onMarkerDragEndHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerFlatChanged(string onMarkerFlatChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerFlatChangedHandlerName)) throw new ArgumentNullException("onMarkerFlatChangedHandlerName");

            ClientEvents.OnMarkerFlatChanged.HandlerName = onMarkerFlatChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerIconChanged(string onMarkerIconChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerIconChangedHandlerName)) throw new ArgumentNullException("onMarkerIconChangedHandlerName");

            ClientEvents.OnMarkerIconChanged.HandlerName = onMarkerIconChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseDown(string onMarkerMouseDownHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseDownHandlerName)) throw new ArgumentNullException("onMarkerMouseDownHandlerName");

            ClientEvents.OnMarkerMouseDown.HandlerName = onMarkerMouseDownHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseOut(string onMarkerMouseOutHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseOutHandlerName)) throw new ArgumentNullException("onMarkerMouseOutHandlerName");

            ClientEvents.OnMarkerMouseOut.HandlerName = onMarkerMouseOutHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseOver(string onMarkerMouseOverHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseOverHandlerName)) throw new ArgumentNullException("onMarkerMouseOverHandlerName");

            ClientEvents.OnMarkerMouseOver.HandlerName = onMarkerMouseOverHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseUp(string onMarkerMouseUpHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseUpHandlerName)) throw new ArgumentNullException("onMarkerMouseUpHandlerName");

            ClientEvents.OnMarkerMouseUp.HandlerName = onMarkerMouseUpHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerPositionChanged(string onMarkerPositionChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerPositionChangedHandlerName)) throw new ArgumentNullException("onMarkerPositionChangedHandlerName");

            ClientEvents.OnMarkerPositionChanged.HandlerName = onMarkerPositionChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerRightClick(string onMarkerRightClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerRightClickHandlerName)) throw new ArgumentNullException("onMarkerRightClickHandlerName");

            ClientEvents.OnMarkerRightClick.HandlerName = onMarkerRightClickHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerShapeChanged(string onMarkerShapeChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerShapeChangedHandlerName)) throw new ArgumentNullException("onMarkerShapeChangedHandlerName");

            ClientEvents.OnMarkerShapeChanged.HandlerName = onMarkerShapeChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerTitleChanged(string onMarkerTitleChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerTitleChangedHandlerName)) throw new ArgumentNullException("onMarkerTitleChangedHandlerName");

            ClientEvents.OnMarkerTitleChanged.HandlerName = onMarkerTitleChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerVisibleChanged(string onMarkerVisibleChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerVisibleChangedHandlerName)) throw new ArgumentNullException("onMarkerVisibleChangedHandlerName");

            ClientEvents.OnMarkerVisibleChanged.HandlerName = onMarkerVisibleChangedHandlerName;

            return this;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Markerz", Justification = "I meant Marker and zIndex")]
        public MarkerEventsBuilder OnMarkerzIndexChanged(string onMarkerzIndexChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerzIndexChangedHandlerName)) throw new ArgumentNullException("onMarkerzIndexChangedHandlerName");

            ClientEvents.OnMarkerZIndexChanged.HandlerName = onMarkerzIndexChangedHandlerName;

            return this;
        }

        private static MarkerEventsBuilder PassThroughNonNull(MarkerEventsBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}