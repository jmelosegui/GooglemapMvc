// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MapClientEventsBuilder : IHideObjectMembers
    {
        public MapClientEventsBuilder(MapClientEvents clientEvents)
        {
            if (clientEvents == null)
            {
                throw new ArgumentNullException(nameof(clientEvents));
            }

            this.ClientEvents = clientEvents;
        }

        protected MapClientEventsBuilder(MapClientEventsBuilder builder)
            : this(PassThroughNonNull(builder).ClientEvents)
        {
        }

        protected MapClientEvents ClientEvents { get; private set; }

        public MapClientEventsBuilder OnMapBoundChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapBoundChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapCenterChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapCenterChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapClick(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDoubleClick(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapDoubleClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapRightClick(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapRightClick.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDrag(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapDrag.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDragEnd(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapDragEnd.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapDragStart(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapDragStart.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapHeadingChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapHeadingChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapIdle(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapIdle.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapTypeIdChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapTypeIdChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseMove(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMouseMove.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseOut(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMouseOut.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMouseOver(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMouseOver.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapProjectionChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapProjectionChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnResize(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnResize.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnTilesLoaded(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnTilesLoaded.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnTiltChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnTiltChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnZoomChanged(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnZoomChanged.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMapLoaded(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMapLoaded.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMarkersGeocodingCompleted(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMarkersGeocodingCompleted.HandlerName = handlerName;

            return this;
        }

        public MapClientEventsBuilder OnMarkersGeocodingProgress(string handlerName)
        {
            if (string.IsNullOrEmpty(handlerName))
            {
                throw new ArgumentNullException(nameof(handlerName));
            }

            this.ClientEvents.OnMarkersGeocodingProgress.HandlerName = handlerName;

            return this;
        }

        private static MapClientEventsBuilder PassThroughNonNull(MapClientEventsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
