using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class StyledMapTypeBuilder : MapTypeBuilder<StyledMapType>
    {
        private readonly StyledMapType mapType;
        public StyledMapTypeBuilder(StyledMapType mapType) : base(mapType)
        {
            this.mapType = mapType;
        }

        public StyledMapTypeBuilder Styles(Action<MapTypeStyleFactory> action)
        {
            if (action == null) throw new ArgumentNullException("action");
            var factory = new MapTypeStyleFactory(mapType);
            action(factory);
            return this;
        }
    }
}