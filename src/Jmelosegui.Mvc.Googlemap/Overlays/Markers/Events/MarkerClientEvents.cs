namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerClientEvents : IClientEventObject
    {
        public MarkerClientEvents()
        {
            OnMarkerClick = new ClientEvent();
            OnMarkerDragStart = new ClientEvent();
            OnMarkerDrag = new ClientEvent();
            OnMarkerDragEnd = new ClientEvent();
        }

        public ClientEvent OnMarkerClick { get; private set; }

        public ClientEvent OnMarkerDragStart { get; private set; }

        public ClientEvent OnMarkerDrag { get; private set; }

        public ClientEvent OnMarkerDragEnd { get; private set; }

        public void SerializeTo(ClientSideObjectWriter writer)
        {
            writer.AppendClientEvent("click", OnMarkerClick);
            writer.AppendClientEvent("dragstart", OnMarkerDragStart);
            writer.AppendClientEvent("drag", OnMarkerDrag);
            writer.AppendClientEvent("dragend", OnMarkerDragEnd);
        }
    }
}