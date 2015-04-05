using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
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
    }
}