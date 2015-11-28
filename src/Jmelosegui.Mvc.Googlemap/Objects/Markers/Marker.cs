// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Marker : Overlay
    {
        public Marker(Map map)
            : base(map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            this.Clickable = true;
            this.Draggable = false;
            this.Index = map.Markers.Count;
        }

        public string Address { get; set; }

        public string Id { get; set; }

        public int Index { get; }

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
