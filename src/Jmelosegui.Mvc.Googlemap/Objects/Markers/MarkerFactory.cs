using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerFactory : IHideObjectMembers 
    {
        public MarkerFactory(GoogleMap map)
        {
            if(map == null) throw new ArgumentNullException("map");
            Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public MarkerBuilder Add() 
        {
            var marker = new Marker(Map);

            Map.Markers.Add(marker);

            return new MarkerBuilder(marker);
        }
    }
}
