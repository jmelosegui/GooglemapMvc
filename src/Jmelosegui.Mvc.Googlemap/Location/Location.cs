namespace Jmelosegui.Mvc.GoogleMap
{
    public struct Location
    {
        private double longitude;
        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public double Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public Location(double latitude, double longitude) 
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }

        public static bool operator ==(Location left, Location right)
        {
            return ((left.Latitude == right.Latitude) && (left.Longitude == right.Longitude));
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
            return ((point.Latitude == Latitude) && (point.Longitude == Longitude));
        }

        public override int GetHashCode()
        {
            return (Latitude.GetHashCode() ^ Longitude.GetHashCode());
        }
    }
}
