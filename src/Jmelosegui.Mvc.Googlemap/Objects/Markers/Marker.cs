using System;
using System.Diagnostics.CodeAnalysis;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class Marker : Overlay
    {
        private readonly int index;
        public Marker(Map map) : base(map)
        {
            if (map == null) throw new ArgumentNullException("map");
            Clickable = true;
            Draggable = false;
            index = map.Markers.Count;
        }

        public string Address { get; set; }

        public string Id { get; set; }

        public int Index
        {
            get { return index; }
        }

        public bool Clickable { get; set; }

        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Draggable")]
        public bool Draggable { get; set; }

        public MarkerImage Icon { get; set; }

        public string Title { get; set; }

        public int ZIndex { get; set; }

        public InfoWindow Window { get; set; }

        public virtual ISerializer CreateSerializer()
        {
            return new MarkerSerializer(this);
        }
    }
}
