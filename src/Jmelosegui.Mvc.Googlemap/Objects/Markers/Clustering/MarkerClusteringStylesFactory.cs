// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringStylesFactory : MapObject
    {
        public MarkerClusteringStylesFactory(Map map)
            : base(map)
        {
        }

        public MarkerClusteringStylesBuilder Add()
        {
            var clusteringStyle = new MarkerClusteringStyles();

            this.Map.MarkerClusteringOptions.CustomStyles.Add(clusteringStyle);

            return new MarkerClusteringStylesBuilder(clusteringStyle);
        }
    }
}
