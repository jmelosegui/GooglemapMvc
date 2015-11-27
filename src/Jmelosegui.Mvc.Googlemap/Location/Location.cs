// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public struct Location
    {
        public Location(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; }

        public double Longitude { get; }

        public static bool operator ==(Location left, Location right)
        {
            return (left.Latitude == right.Latitude) && (left.Longitude == right.Longitude);
        }

        public static bool operator !=(Location left, Location right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }

            var point = (Location)obj;
            return (point.Latitude == this.Latitude) && (point.Longitude == this.Longitude);
        }

        public override int GetHashCode()
        {
            return this.Latitude.GetHashCode() ^ this.Longitude.GetHashCode();
        }
    }
}
