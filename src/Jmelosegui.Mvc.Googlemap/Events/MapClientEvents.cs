// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MapClientEvents : IClientEventObject
    {
        public MapClientEvents()
        {
            this.OnMapBoundChanged = new ClientEvent();
            this.OnMapCenterChanged = new ClientEvent();
            this.OnMapClick = new ClientEvent();
            this.OnMapDoubleClick = new ClientEvent();
            this.OnMapRightClick = new ClientEvent();
            this.OnMapDrag = new ClientEvent();
            this.OnMapDragEnd = new ClientEvent();
            this.OnMapDragStart = new ClientEvent();
            this.OnMapHeadingChanged = new ClientEvent();
            this.OnMapIdle = new ClientEvent();
            this.OnMapTypeIdChanged = new ClientEvent();
            this.OnMouseMove = new ClientEvent();
            this.OnMouseOut = new ClientEvent();
            this.OnMouseOver = new ClientEvent();
            this.OnMapProjectionChanged = new ClientEvent();
            this.OnResize = new ClientEvent();
            this.OnTilesLoaded = new ClientEvent();
            this.OnTiltChanged = new ClientEvent();
            this.OnZoomChanged = new ClientEvent();
            this.OnMapLoaded = new ClientEvent();
            this.OnMarkersGeocodingCompleted = new ClientEvent();
            this.OnMarkersGeocodingProgress = new ClientEvent();
        }

        public ClientEvent OnMapBoundChanged { get; private set; }

        public ClientEvent OnMapCenterChanged { get; private set; }

        public ClientEvent OnMapClick { get; private set; }

        public ClientEvent OnMapDoubleClick { get; private set; }

        public ClientEvent OnMapRightClick { get; private set; }

        public ClientEvent OnMapDrag { get; private set; }

        public ClientEvent OnMapDragEnd { get; private set; }

        public ClientEvent OnMapDragStart { get; private set; }

        public ClientEvent OnMapHeadingChanged { get; private set; }

        public ClientEvent OnMapIdle { get; private set; }

        public ClientEvent OnMapTypeIdChanged { get; private set; }

        public ClientEvent OnMouseMove { get; private set; }

        public ClientEvent OnMouseOut { get; private set; }

        public ClientEvent OnMouseOver { get; private set; }

        public ClientEvent OnMapProjectionChanged { get; private set; }

        public ClientEvent OnResize { get; private set; }

        public ClientEvent OnTilesLoaded { get; private set; }

        public ClientEvent OnTiltChanged { get; private set; }

        public ClientEvent OnZoomChanged { get; private set; }

        public ClientEvent OnMapLoaded { get; private set; }

        public ClientEvent OnMarkersGeocodingCompleted { get; private set; }

        public ClientEvent OnMarkersGeocodingProgress { get; private set; }

        public void SerializeTo(ClientSideObjectWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.AppendClientEvent("bounds_changed", this.OnMapBoundChanged);
            writer.AppendClientEvent("center_changed", this.OnMapCenterChanged);
            writer.AppendClientEvent("click", this.OnMapClick);
            writer.AppendClientEvent("dblclick", this.OnMapDoubleClick);
            writer.AppendClientEvent("rightclick", this.OnMapRightClick);
            writer.AppendClientEvent("drag", this.OnMapDrag);
            writer.AppendClientEvent("dragend", this.OnMapDragEnd);
            writer.AppendClientEvent("dragstart", this.OnMapDragStart);
            writer.AppendClientEvent("heading_changed", this.OnMapHeadingChanged);
            writer.AppendClientEvent("idle", this.OnMapIdle);
            writer.AppendClientEvent("maptypeid_changed", this.OnMapTypeIdChanged);
            writer.AppendClientEvent("mousemove", this.OnMouseMove);
            writer.AppendClientEvent("mouseout", this.OnMouseOut);
            writer.AppendClientEvent("mouseover", this.OnMouseOver);
            writer.AppendClientEvent("projection_changed", this.OnMapProjectionChanged);
            writer.AppendClientEvent("resize", this.OnResize);
            writer.AppendClientEvent("tilesloaded", this.OnTilesLoaded);
            writer.AppendClientEvent("resize", this.OnTiltChanged);
            writer.AppendClientEvent("zoom_changed", this.OnZoomChanged);
            writer.AppendClientEvent("map_loaded", this.OnMapLoaded);
            writer.AppendClientEvent("markers_geocoding_completed", this.OnMarkersGeocodingCompleted);
            writer.AppendClientEvent("markers_geocoding_progress", this.OnMarkersGeocodingProgress);
        }
    }
}