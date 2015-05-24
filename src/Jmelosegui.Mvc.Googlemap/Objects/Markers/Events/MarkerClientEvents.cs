namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerClientEvents : IClientEventObject
    {
        public MarkerClientEvents()
        {
            OnMarkerAnimationChanged = new ClientEvent();
            OnMarkerClick = new ClientEvent();
            OnMarkerClickableChanged = new ClientEvent();
            OnMarkerCursorChanged = new ClientEvent();
            OnMarkerDblClick = new ClientEvent();
            OnMarkerDragStart = new ClientEvent();
            OnMarkerDrag = new ClientEvent();
            OnMarkerDragEnd = new ClientEvent();
            OnMarkerFlatChanged = new ClientEvent();
            OnMarkerIconChanged = new ClientEvent();
            OnMarkerMouseDown = new ClientEvent();
            OnMarkerMouseOut = new ClientEvent();
            OnMarkerMouseOver = new ClientEvent();
            OnMarkerMouseUp = new ClientEvent();
            OnMarkerPositionChanged = new ClientEvent();
            OnMarkerRightClick = new ClientEvent();
            OnMarkerShapeChanged = new ClientEvent();
            OnMarkerTitleChanged = new ClientEvent();
            OnMarkerVisibleChanged = new ClientEvent();
            OnMarkerzIndexChanged = new ClientEvent();
        }

        public ClientEvent OnMarkerAnimationChanged { get; private set; }

        public ClientEvent OnMarkerClick { get; private set; }

        public ClientEvent OnMarkerClickableChanged { get; private set; }

        public ClientEvent OnMarkerCursorChanged { get; private set; }

        public ClientEvent OnMarkerDblClick { get; private set; }

        public ClientEvent OnMarkerDragStart { get; private set; }

        public ClientEvent OnMarkerDrag { get; private set; }

        public ClientEvent OnMarkerDragEnd { get; private set; }

        public ClientEvent OnMarkerFlatChanged { get; private set; }

        public ClientEvent OnMarkerIconChanged { get; private set; }

        public ClientEvent OnMarkerMouseDown { get; private set; }

        public ClientEvent OnMarkerMouseOut { get; private set; }

        public ClientEvent OnMarkerMouseOver { get; private set; }

        public ClientEvent OnMarkerMouseUp { get; private set; }

        public ClientEvent OnMarkerPositionChanged { get; private set; }

        public ClientEvent OnMarkerRightClick { get; private set; }

        public ClientEvent OnMarkerShapeChanged { get; private set; }

        public ClientEvent OnMarkerTitleChanged { get; private set; }

        public ClientEvent OnMarkerVisibleChanged { get; private set; }

        public ClientEvent OnMarkerzIndexChanged { get; private set; }

        public void SerializeTo(ClientSideObjectWriter writer)
        {
            writer.AppendClientEvent("animation_changed", OnMarkerAnimationChanged);
            writer.AppendClientEvent("click", OnMarkerClick);
            writer.AppendClientEvent("clickable_changed", OnMarkerClickableChanged);
            writer.AppendClientEvent("cursor_changed", OnMarkerCursorChanged);
            writer.AppendClientEvent("dblclick", OnMarkerDblClick);
            writer.AppendClientEvent("dragstart", OnMarkerDragStart);
            writer.AppendClientEvent("drag", OnMarkerDrag);
            writer.AppendClientEvent("dragend", OnMarkerDragEnd);
            writer.AppendClientEvent("flat_changed", OnMarkerFlatChanged);
            writer.AppendClientEvent("icon_changed", OnMarkerIconChanged);
            writer.AppendClientEvent("mousedown", OnMarkerMouseDown);
            writer.AppendClientEvent("mouseout", OnMarkerMouseOut);
            writer.AppendClientEvent("mouseover", OnMarkerMouseOver);
            writer.AppendClientEvent("mouseup", OnMarkerMouseUp);
            writer.AppendClientEvent("position_changed", OnMarkerPositionChanged);
            writer.AppendClientEvent("rightclick", OnMarkerRightClick);
            writer.AppendClientEvent("shape_changed", OnMarkerShapeChanged);
            writer.AppendClientEvent("title_changed", OnMarkerTitleChanged);
            writer.AppendClientEvent("visible_changed", OnMarkerVisibleChanged);
            writer.AppendClientEvent("zindex_changed", OnMarkerzIndexChanged);
        }
    }
}