namespace Jmelosegui.Mvc.Googlemap
{
    public class StyledMapTypeFactory : IHideObjectMembers 
    {
        public StyledMapTypeFactory(GoogleMap map)
        {
            Map = map;
        }

        protected GoogleMap Map { get; private set; }

        public StyledMapTypeBuilder Add()
        {
            var maptype = new StyledMapType();

            Map.StyledMapTypes.Add(maptype);

            return new StyledMapTypeBuilder(maptype);
        }
    }
}