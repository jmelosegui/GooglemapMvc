using System;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeBuilder<TMapType> where TMapType : MapTypeBase
    {
        protected MapTypeBuilder(MapTypeBuilder<TMapType> builder) : this(PassThroughNonNull(builder).MapType)
        {
        }

        public MapTypeBuilder(TMapType mapType)
        {
            this.MapType = mapType;
        }

        protected TMapType MapType { get; private set; }

        public MapTypeBuilder<TMapType> MapTypeAltName(string value)
        {
            MapType.MapTypeAltName = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MaxZoom(int value)
        {
            MapType.MaxZoom = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MinZoom(int value)
        {
            MapType.MinZoom = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MapTypeName(string name)
        {
            MapType.MapTypeName = name;
            return this;
        }

        public MapTypeBuilder<TMapType> Opacity(int value)
        {
            MapType.Opacity = value;
            return this;
        }

        public MapTypeBuilder<TMapType> Radius(int value)
        {
            MapType.Radius = value;
            return this;
        }

        private static MapTypeBuilder<TMapType> PassThroughNonNull(MapTypeBuilder<TMapType> builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}