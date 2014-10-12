namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeBuilder<TMapType> where TMapType : MapType
    {
        private readonly TMapType mapType;

        public MapTypeBuilder(TMapType mapType)
        {
            this.mapType = mapType;
        }

        public MapTypeBuilder<TMapType> MapTypeAltName(string mapTypeAltName)
        {
            mapType.MapTypeAltName = mapTypeAltName;
            return this;
        }

        public MapTypeBuilder<TMapType> MaxZoom(int maxZoom)
        {
            mapType.MaxZoom = maxZoom;
            return this;
        }

        public MapTypeBuilder<TMapType> MinZoom(int minZoom)
        {
            mapType.MinZoom = minZoom;
            return this;
        }

        public MapTypeBuilder<TMapType> MapTypeName(string name)
        {
            mapType.MapTypeName = name;
            return this;
        }

        public MapTypeBuilder<TMapType> Opacity(int value)
        {
            mapType.Opacity = value;
            return this;
        }

        public MapTypeBuilder<TMapType> Radius(int value)
        {
            mapType.Radius = value;
            return this;
        }
    }
}