
namespace Jmelosegui.Mvc.Googlemap
{
    public class GoogleMapClientEvents
    {
        public GoogleMapClientEvents()
        {
            OnMapBoundChanged = new ClientEvent();
            OnMapCenterChanged = new ClientEvent();
            OnMapClick = new ClientEvent();
            OnMapDobleClick = new ClientEvent();
            OnMapRightClick = new ClientEvent();
            OnMapDrag = new ClientEvent();
            OnMapDragEnd = new ClientEvent();
            OnMapDragStart = new ClientEvent();
            OnMapHeadingChanged = new ClientEvent();
            OnMapIdle = new ClientEvent();
            OnMapTypeIdChanged = new ClientEvent();
            OnMouseMove = new ClientEvent();
            OnMouseOut = new ClientEvent();
            OnMouseOver = new ClientEvent();
            OnMapProjectionChanged = new ClientEvent();
            OnResize = new ClientEvent();
            OnTilesLoaded = new ClientEvent();
            OnTiltChanged = new ClientEvent();
            OnZoomChanged = new ClientEvent();
            OnMapLoaded = new ClientEvent();

        }

        public ClientEvent OnMapBoundChanged { get; private set; }

        public ClientEvent OnMapCenterChanged { get; private set; }

        public ClientEvent OnMapClick { get; private set; }

        public ClientEvent OnMapDobleClick { get; private set; }

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

        public void SerializeTo(ClientSideObjectWriter writer)
        {
            writer.AppendClientEvent("bounds_changed", OnMapBoundChanged);
            writer.AppendClientEvent("center_changed", OnMapCenterChanged);
            writer.AppendClientEvent("click", OnMapClick);
            writer.AppendClientEvent("dblclick", OnMapDobleClick);
            writer.AppendClientEvent("rightclick", OnMapRightClick);
            writer.AppendClientEvent("drag", OnMapDrag);
            writer.AppendClientEvent("dragend", OnMapDragEnd);
            writer.AppendClientEvent("dragstart", OnMapDragStart);
            writer.AppendClientEvent("heading_changed", OnMapHeadingChanged);
            writer.AppendClientEvent("idle", OnMapIdle);
            writer.AppendClientEvent("maptypeid_changed", OnMapTypeIdChanged);
            writer.AppendClientEvent("mousemove", OnMouseMove);
            writer.AppendClientEvent("mouseout", OnMouseOut);
            writer.AppendClientEvent("mouseover", OnMouseOver);
            writer.AppendClientEvent("projection_changed", OnMapProjectionChanged);
            writer.AppendClientEvent("resize", OnResize);
            writer.AppendClientEvent("tilesloaded", OnTilesLoaded);
            writer.AppendClientEvent("resize", OnTiltChanged);
            writer.AppendClientEvent("zoom_changed", OnZoomChanged);
            writer.AppendClientEvent("map_loaded", OnMapLoaded);
        }
    }

}
