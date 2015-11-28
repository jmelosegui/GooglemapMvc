// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MarkerClientEvents : IClientEventObject
    {
        public MarkerClientEvents()
        {
            this.OnMarkerAnimationChanged = new ClientEvent();
            this.OnMarkerClick = new ClientEvent();
            this.OnMarkerClickableChanged = new ClientEvent();
            this.OnMarkerCursorChanged = new ClientEvent();
            this.OnMarkerDoubleClick = new ClientEvent();
            this.OnMarkerDragStart = new ClientEvent();
            this.OnMarkerDrag = new ClientEvent();
            this.OnMarkerDragEnd = new ClientEvent();
            this.OnMarkerFlatChanged = new ClientEvent();
            this.OnMarkerIconChanged = new ClientEvent();
            this.OnMarkerMouseDown = new ClientEvent();
            this.OnMarkerMouseOut = new ClientEvent();
            this.OnMarkerMouseOver = new ClientEvent();
            this.OnMarkerMouseUp = new ClientEvent();
            this.OnMarkerPositionChanged = new ClientEvent();
            this.OnMarkerRightClick = new ClientEvent();
            this.OnMarkerShapeChanged = new ClientEvent();
            this.OnMarkerTitleChanged = new ClientEvent();
            this.OnMarkerVisibleChanged = new ClientEvent();
            this.OnMarkerZIndexChanged = new ClientEvent();
        }

        public ClientEvent OnMarkerAnimationChanged { get; }

        public ClientEvent OnMarkerClick { get; }

        public ClientEvent OnMarkerClickableChanged { get; }

        public ClientEvent OnMarkerCursorChanged { get; }

        public ClientEvent OnMarkerDoubleClick { get; }

        public ClientEvent OnMarkerDragStart { get; }

        public ClientEvent OnMarkerDrag { get; }

        public ClientEvent OnMarkerDragEnd { get; }

        public ClientEvent OnMarkerFlatChanged { get; }

        public ClientEvent OnMarkerIconChanged { get; }

        public ClientEvent OnMarkerMouseDown { get; }

        public ClientEvent OnMarkerMouseOut { get; }

        public ClientEvent OnMarkerMouseOver { get; }

        public ClientEvent OnMarkerMouseUp { get; }

        public ClientEvent OnMarkerPositionChanged { get; }

        public ClientEvent OnMarkerRightClick { get; }

        public ClientEvent OnMarkerShapeChanged { get; }

        public ClientEvent OnMarkerTitleChanged { get; }

        public ClientEvent OnMarkerVisibleChanged { get; }

        public ClientEvent OnMarkerZIndexChanged { get; private set; }

        public void SerializeTo(ClientSideObjectWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.AppendClientEvent("animation_changed", this.OnMarkerAnimationChanged);
            writer.AppendClientEvent("click", this.OnMarkerClick);
            writer.AppendClientEvent("clickable_changed", this.OnMarkerClickableChanged);
            writer.AppendClientEvent("cursor_changed", this.OnMarkerCursorChanged);
            writer.AppendClientEvent("dblclick", this.OnMarkerDoubleClick);
            writer.AppendClientEvent("dragstart", this.OnMarkerDragStart);
            writer.AppendClientEvent("drag", this.OnMarkerDrag);
            writer.AppendClientEvent("dragend", this.OnMarkerDragEnd);
            writer.AppendClientEvent("flat_changed", this.OnMarkerFlatChanged);
            writer.AppendClientEvent("icon_changed", this.OnMarkerIconChanged);
            writer.AppendClientEvent("mousedown", this.OnMarkerMouseDown);
            writer.AppendClientEvent("mouseout", this.OnMarkerMouseOut);
            writer.AppendClientEvent("mouseover", this.OnMarkerMouseOver);
            writer.AppendClientEvent("mouseup", this.OnMarkerMouseUp);
            writer.AppendClientEvent("position_changed", this.OnMarkerPositionChanged);
            writer.AppendClientEvent("rightclick", this.OnMarkerRightClick);
            writer.AppendClientEvent("shape_changed", this.OnMarkerShapeChanged);
            writer.AppendClientEvent("title_changed", this.OnMarkerTitleChanged);
            writer.AppendClientEvent("visible_changed", this.OnMarkerVisibleChanged);
            writer.AppendClientEvent("zindex_changed", this.OnMarkerZIndexChanged);
        }
    }
}