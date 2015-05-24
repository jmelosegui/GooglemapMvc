using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public abstract class MapObject
    {
        protected MapObject(GoogleMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            Map = map;
        }

        protected internal GoogleMap Map { get; }
    }
}