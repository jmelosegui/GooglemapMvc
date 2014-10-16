namespace Jmelosegui.Mvc.Googlemap
{
    public class StyledMapTypeFactory : IHideObjectMembers 
    {
        private readonly GoogleMap map;

        public StyledMapTypeFactory(GoogleMap map)
        {
            this.map = map;
        }

        public StyledMapTypeBuilder Add()
        {
            var maptype = new StyledMapType();

            map.StyledMapTypes.Add(maptype);

            return new StyledMapTypeBuilder(maptype);
        }
    }
}