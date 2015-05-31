using System;
using Newtonsoft.Json;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class InfoWindow : Overlay
    {
        
        private readonly Marker marker;

        public InfoWindow(Marker marker) : base(marker.Map)
        {
            if (marker == null) throw new ArgumentNullException("marker");
            
            this.marker = marker;
            Content = string.Format("{0}Marker{1}",marker.Map.Id,marker.Index);
        
            Template = new HtmlTemplate();
        }

        [JsonIgnore]
        public HtmlTemplate Template
        {
            get;
            private set;
        }

        public string Content { get; }

        public bool DisableAutoPan { get; set; }

        public bool OpenOnRightClick { get; set; }

        public override double? Longitude
        {
            get
            {
                if (marker != null)
                    return marker.Longitude;

                return base.Longitude;
            }
            set { base.Longitude = value; }
        }

        public override double? Latitude
        {
            get
            {
                if (marker != null)
                    return marker.Latitude;

                return base.Latitude;
            }
            set { base.Latitude = value; }
        }

        public int MaxWidth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "z")]
        public int zIndex { get; set; }
    }
}