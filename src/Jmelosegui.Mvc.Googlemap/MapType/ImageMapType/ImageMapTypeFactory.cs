namespace Jmelosegui.Mvc.Googlemap
{
    public class ImageMapTypeFactory : IHideObjectMembers 
    {
        public ImageMapTypeFactory(GoogleMap map)
        {
            this.Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public ImageMapTypeBuilder Add()
        {
            var maptype = new ImageMapType();

            Map.ImageMapTypes.Add(maptype);

            return new ImageMapTypeBuilder(maptype);
        }
    }
}
