// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class CenterFactory
    {
        public CenterFactory(Map map)
        {
            this.Map = map;
        }

        protected Map Map { get; private set; }

        public CenterFactory UseCurrentPosition()
        {
            this.Map.UseCurrentPosition = true;
            return this;
        }

        public CenterFactory Latitude(double value)
        {
            this.Map.Latitude = value;
            return this;
        }

        public CenterFactory Longitude(double value)
        {
            this.Map.Longitude = value;
            return this;
        }

        public void Address(string value)
        {
            this.Map.Address = value;
        }
    }
}
