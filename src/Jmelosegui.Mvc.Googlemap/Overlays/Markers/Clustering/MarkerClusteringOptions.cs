using System.Collections.Generic;
using System.Linq;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class MarkerClusteringOptions : ISerializer
    {
        private readonly List<MarkerClusteringStyles> customStyles;

        public MarkerClusteringOptions()
        {
            MaxZoom = 12;
            GridSize = 60;
            HideSingleGroupMarker = true;
            ZoomOnClick = true;
            customStyles = new List<MarkerClusteringStyles>();
        }

        public int MaxZoom { get; set; }

        public int GridSize { get; set; }

        public bool AverageCenter { get; set; }

        public bool ZoomOnClick { get; set; }

        public bool HideSingleGroupMarker { get; set; }

        public List<MarkerClusteringStyles> CustomStyles
        {
            get { return customStyles; }

        }

        public IDictionary<string, object> Serialize()
        {
            var customStyles = new List<IDictionary<string, object>>();

            if (CustomStyles.Any())
            {
                CustomStyles.Each(cs => customStyles.Add(cs.CreateSerializer().Serialize()));
            }

            IDictionary<string, object> result = new Dictionary<string, object>();
            FluentDictionary.For(result)
                .Add("MaxZoom", MaxZoom)
                .Add("GridSize", GridSize)
                .Add("AverageCenter", AverageCenter)
                .Add("ZoomOnClick", ZoomOnClick, true)
                .Add("HideSingleGroupMarker", HideSingleGroupMarker)
                .Add("CustomStyles", customStyles, () => CustomStyles.Any());

            return result;
        }
    }
}