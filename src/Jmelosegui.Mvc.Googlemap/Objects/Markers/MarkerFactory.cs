using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerFactory : IHideObjectMembers 
    {
        public MarkerFactory(Map map)
        {
            if(map == null) throw new ArgumentNullException("map");
            Map = map;
        }

        protected Map Map { get; private set; }

        public MarkerBuilder Add() 
        {
            var marker = new Marker(Map);

            Map.Markers.Add(marker);

            return new MarkerBuilder(marker);
        }
    }
}
