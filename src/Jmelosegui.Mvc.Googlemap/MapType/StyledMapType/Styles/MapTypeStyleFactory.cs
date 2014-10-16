namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeStyleFactory : IHideObjectMembers 
    {
        private readonly StyledMapType mapType;

        public MapTypeStyleFactory(StyledMapType mapType)
        {
            this.mapType = mapType;
        }

        public MapTypeStyleBuilder Add()
        {
            var style = new MapTypeStyle();

            mapType.Styles.Add(style);

            return new MapTypeStyleBuilder(style);
        }
    }
}