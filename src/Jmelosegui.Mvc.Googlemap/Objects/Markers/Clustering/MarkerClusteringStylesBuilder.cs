using System;
using System.Drawing;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MarkerClusteringStylesBuilder
    {
        private readonly MarkerClusteringStyles clusteringStyle;

        public MarkerClusteringStylesBuilder(MarkerClusteringStyles clusteringStyle)
        {
            this.clusteringStyle = clusteringStyle;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
        public MarkerClusteringStylesBuilder ImageUrl(string url)
        {
            clusteringStyle.Url = new Uri(url.ToAbsoluteUrl());
            return this;
        }

        public MarkerClusteringStylesBuilder Height(int value)
        {
            clusteringStyle.Height = value;
            return this;
        }

        public MarkerClusteringStylesBuilder Width(int value)
        {
            clusteringStyle.Width = value;
            return this;
        }

        public MarkerClusteringStylesBuilder FontSize(int value)
        {
            clusteringStyle.FontSize = value;
            return this;
        }

        public MarkerClusteringStylesBuilder FontColor(Color value)
        {
            clusteringStyle.FontColor = value;
            return this;
        }
    }
}