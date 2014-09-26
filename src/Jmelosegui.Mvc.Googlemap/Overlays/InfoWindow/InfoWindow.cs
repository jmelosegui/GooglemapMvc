using System;
using System.Web.Script.Serialization;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class InfoWindow : Overlay, IHideObjectMembers
    {
        
        private readonly Marker marker;
        private readonly string content;
        public InfoWindow(Marker marker) : base(marker.Map)
        {
            if (marker == null) throw new ArgumentNullException("marker");
            
            this.marker = marker;
            content = string.Format("{0}Marker{1}",marker.Map.Id,marker.Index);
        
            Template = new HtmlTemplate();
        }
        
        [ScriptIgnore]
        public HtmlTemplate Template
        {
            get;
            private set;
        }

        public string Content { get { return content; } }

        public bool DisableAutoPan { get; set; }

        public override double Longitude
        {
            get
            {
                if (marker != null)
                    return marker.Longitude;

                return base.Longitude;
            }
            set { base.Longitude = value; }
        }

        public override double Latitude
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