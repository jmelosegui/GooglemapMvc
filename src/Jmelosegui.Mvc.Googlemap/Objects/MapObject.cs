using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class MapObject
    {
        protected MapObject(Map map)
        {
            if (map == null) throw new ArgumentNullException("map");
            Map = map;
        }

        protected internal Map Map { get; private set; }
    }
}