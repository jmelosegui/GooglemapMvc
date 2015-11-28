// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

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
            this.clusteringStyle.Url = new Uri(url.ToAbsoluteUrl());
            return this;
        }

        public MarkerClusteringStylesBuilder Height(int value)
        {
            this.clusteringStyle.Height = value;
            return this;
        }

        public MarkerClusteringStylesBuilder Width(int value)
        {
            this.clusteringStyle.Width = value;
            return this;
        }

        public MarkerClusteringStylesBuilder FontSize(int value)
        {
            this.clusteringStyle.FontSize = value;
            return this;
        }

        public MarkerClusteringStylesBuilder FontColor(Color value)
        {
            this.clusteringStyle.FontColor = value;
            return this;
        }
    }
}