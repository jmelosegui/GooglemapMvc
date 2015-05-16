using System;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public abstract class Overlay
    {
        private readonly GoogleMap map;

        protected Overlay(GoogleMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            this.map = map;
        }

        protected internal GoogleMap Map
        {
            get { return this.map; }
        }
    }
}