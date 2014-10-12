namespace Jmelosegui.Mvc.Googlemap
{
    public class ImageMapTypeFactory : IHideObjectMembers 
    {
        private readonly GoogleMap map;

        public ImageMapTypeFactory(GoogleMap map)
        {
            this.map = map;
        }

        public ImageMapTypeBuilder Add()
        {
            var maptype = new ImageMapType();

            map.MapTypes.Add(maptype);

            return new ImageMapTypeBuilder(maptype);
        }
    }
}
