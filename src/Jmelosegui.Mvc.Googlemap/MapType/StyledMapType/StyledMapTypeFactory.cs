namespace Jmelosegui.Mvc.GoogleMap
{
    public class StyledMapTypeFactory : IHideObjectMembers 
    {
        public StyledMapTypeFactory(Map map)
        {
            Map = map;
        }

        protected Map Map { get; private set; }

        public StyledMapTypeBuilder Add()
        {
            var maptype = new StyledMapType();

            Map.StyledMapTypes.Add(maptype);

            return new StyledMapTypeBuilder(maptype);
        }
    }
}