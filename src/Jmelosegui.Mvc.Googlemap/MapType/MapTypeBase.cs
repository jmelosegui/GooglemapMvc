// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public abstract class MapTypeBase : IHideObjectMembers
    {
        protected MapTypeBase()
        {
            this.Radius = 6378137;
            this.Opacity = 100;
        }

        public string MapTypeAltName { get; set; }

        public int MaxZoom { get; set; }

        public int MinZoom { get; set; }

        public string MapTypeName { get; set; }

        public int Opacity { get; set; }

        public int Radius { get; set; }

        public abstract ISerializer CreateSerializer();
    }
}