namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringStylesFactory : MapObject
    {
        public MarkerClusteringStylesFactory(Map map) : base(map)
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
