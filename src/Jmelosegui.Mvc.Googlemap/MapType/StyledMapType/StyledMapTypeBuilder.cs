using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class StyledMapTypeBuilder : MapTypeBuilder<StyledMapType>
    {
        public StyledMapTypeBuilder(StyledMapType mapType) : base(mapType)
        {
        }

        public StyledMapTypeBuilder Styles(Action<MapTypeStyleFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new MapTypeStyleFactory(MapType);
            action(factory);
            return this;
        }
    }
}