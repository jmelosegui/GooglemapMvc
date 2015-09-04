using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap
{
    public class StyledMapType : MapTypeBase
    {
        public StyledMapType()
        {
            Styles = new List<MapTypeStyle>();
        }

        public IList<MapTypeStyle> Styles { get; private set; }

        public override ISerializer CreateSerializer()
        {
            return new StyledMapTypeSerializer(this);
        }
    }
}