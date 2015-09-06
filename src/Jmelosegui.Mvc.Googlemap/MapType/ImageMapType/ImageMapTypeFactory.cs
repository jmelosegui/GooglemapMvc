namespace Jmelosegui.Mvc.GoogleMap
{
    public class ImageMapTypeFactory : IHideObjectMembers 
    {
        public ImageMapTypeFactory(Map map)
        {
            this.Map = map;
        }

        protected Map Map { get; private set; }

        public ImageMapTypeBuilder Add()
        {
            var maptype = new ImageMapType();

            Map.ImageMapTypes.Add(maptype);

            return new ImageMapTypeBuilder(maptype);
        }
    }
}
