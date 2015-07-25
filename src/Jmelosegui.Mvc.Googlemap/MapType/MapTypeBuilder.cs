namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeBuilder<TMapType> where TMapType : MapType
    {
        protected MapTypeBuilder(MapTypeBuilder<TMapType> builder)
            : this(builder.MapType)
        {
        }

        public MapTypeBuilder(TMapType mapType)
        {
            this.MapType = mapType;
        }

        protected TMapType MapType { get; private set; }

        public MapTypeBuilder<TMapType> MapTypeAltName(string mapTypeAltName)
        {
            MapType.MapTypeAltName = mapTypeAltName;
            return this;
        }

        public MapTypeBuilder<TMapType> MaxZoom(int maxZoom)
        {
            MapType.MaxZoom = maxZoom;
            return this;
        }

        public MapTypeBuilder<TMapType> MinZoom(int minZoom)
        {
            MapType.MinZoom = minZoom;
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
    }
}