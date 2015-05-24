using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerEventsBuilder: IHideObjectMembers
    {
        private readonly MarkerClientEvents clientEvents;

        public MarkerEventsBuilder(MarkerClientEvents clientEvents)
        {
            if(clientEvents == null)throw  new ArgumentNullException("clientEvents");

            this.clientEvents = clientEvents;
        }

        public MarkerEventsBuilder OnMarkerClick(string onMarkerClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerClickHandlerName)) throw new ArgumentNullException("onMarkerClickHandlerName");

            clientEvents.OnMarkerClick.HandlerName = onMarkerClickHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDblClick(string onMarkerDblClickkHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDblClickkHandlerName)) throw new ArgumentNullException("onMarkerDblClickkHandlerName");

            clientEvents.OnMarkerDblClick.HandlerName = onMarkerDblClickkHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDragStart(string onMarkerDragStartHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragStartHandlerName)) throw new ArgumentNullException("onMarkerDragStartHandlerName");

            clientEvents.OnMarkerDragStart.HandlerName = onMarkerDragStartHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDrag(string onMarkerDragHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragHandlerName)) throw new ArgumentNullException("onMarkerDragHandlerName");

            clientEvents.OnMarkerDrag.HandlerName = onMarkerDragHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerDragEnd(string onMarkerDragEndHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerDragEndHandlerName)) throw new ArgumentNullException("onMarkerDragEndHandlerName");

            clientEvents.OnMarkerDragEnd.HandlerName = onMarkerDragEndHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerFlatChanged(string onMarkerFlatChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerFlatChangedHandlerName)) throw new ArgumentNullException("onMarkerFlatChangedHandlerName");

            clientEvents.OnMarkerFlatChanged.HandlerName = onMarkerFlatChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerIconChanged(string onMarkerIconChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerIconChangedHandlerName)) throw new ArgumentNullException("onMarkerIconChangedHandlerName");

            clientEvents.OnMarkerIconChanged.HandlerName = onMarkerIconChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseDown(string onMarkerMouseDownHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseDownHandlerName)) throw new ArgumentNullException("onMarkerMouseDownHandlerName");

            clientEvents.OnMarkerMouseDown.HandlerName = onMarkerMouseDownHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseOut(string onMarkerMouseOutHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseOutHandlerName)) throw new ArgumentNullException("onMarkerMouseOutHandlerName");

            clientEvents.OnMarkerMouseOut.HandlerName = onMarkerMouseOutHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseOver(string onMarkerMouseOverHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseOverHandlerName)) throw new ArgumentNullException("onMarkerMouseOverHandlerName");

            clientEvents.OnMarkerMouseOver.HandlerName = onMarkerMouseOverHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerMouseUp(string onMarkerMouseUpHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerMouseUpHandlerName)) throw new ArgumentNullException("onMarkerMouseUpHandlerName");

            clientEvents.OnMarkerMouseUp.HandlerName = onMarkerMouseUpHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerPositionChanged(string onMarkerPositionChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerPositionChangedHandlerName)) throw new ArgumentNullException("onMarkerPositionChangedHandlerName");

            clientEvents.OnMarkerPositionChanged.HandlerName = onMarkerPositionChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerRightClick(string onMarkerRightClickHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerRightClickHandlerName)) throw new ArgumentNullException("onMarkerRightClickHandlerName");

            clientEvents.OnMarkerRightClick.HandlerName = onMarkerRightClickHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerShapeChanged(string onMarkerShapeChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerShapeChangedHandlerName)) throw new ArgumentNullException("onMarkerShapeChangedHandlerName");

            clientEvents.OnMarkerShapeChanged.HandlerName = onMarkerShapeChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerTitleChanged(string onMarkerTitleChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerTitleChangedHandlerName)) throw new ArgumentNullException("onMarkerTitleChangedHandlerName");

            clientEvents.OnMarkerTitleChanged.HandlerName = onMarkerTitleChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerVisibleChanged(string onMarkerVisibleChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerVisibleChangedHandlerName)) throw new ArgumentNullException("onMarkerVisibleChangedHandlerName");

            clientEvents.OnMarkerVisibleChanged.HandlerName = onMarkerVisibleChangedHandlerName;

            return this;
        }

        public MarkerEventsBuilder OnMarkerzIndexChanged(string onMarkerzIndexChangedHandlerName)
        {
            if (String.IsNullOrEmpty(onMarkerzIndexChangedHandlerName)) throw new ArgumentNullException("onMarkerzIndexChangedHandlerName");

            clientEvents.OnMarkerzIndexChanged.HandlerName = onMarkerzIndexChangedHandlerName;

            return this;
        }
    }
}