namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MarkerClusteringStylesFactory : MapObject
    {
        public MarkerClusteringStylesFactory(GoogleMap map) : base(map)
        {
        }

        public MarkerClusteringStylesBuilder Add()
        {
            var clusteringStyle = new MarkerClusteringStyles();

            Map.MarkerClusteringOptions.CustomStyles.Add(clusteringStyle);

            return new MarkerClusteringStylesBuilder(clusteringStyle);
        }
    }
}
