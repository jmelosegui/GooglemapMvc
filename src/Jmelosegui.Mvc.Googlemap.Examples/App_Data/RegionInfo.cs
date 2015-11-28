namespace Jmelosegui.Mvc.GoogleMap.Examples.App_Data
{
    public class RegionInfo
    {
        public int Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Title { get; set; }

        public int ZIndex { get; set; }

        public string ImagePath { get; set; }

        public string InfoWindowContent { get; set; }

        public double Population { get; set; }

        public string Address
        {
            get { return this.Title + ", Spain"; }
        }
    }
}