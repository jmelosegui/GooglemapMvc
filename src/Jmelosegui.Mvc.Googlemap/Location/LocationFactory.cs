// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class LocationFactory<TILocationContainer>
        where TILocationContainer : ILocationContainer
    {
        private readonly TILocationContainer locationContainer;

        public LocationFactory(TILocationContainer locationContainer)
        {
            this.locationContainer = locationContainer;
        }

        public void Add(double latitude, double longitude)
        {
            var loc = new Location(latitude, longitude);
            this.locationContainer.AddPoint(loc);
        }
    }
}
