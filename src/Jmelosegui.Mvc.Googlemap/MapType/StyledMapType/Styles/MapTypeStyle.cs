using System.Collections.Generic;
using System.Linq;

namespace Jmelosegui.Mvc.Googlemap
{
    public class MapTypeStyle : ISerializer
    {
        public MapTypeStyle()
        {
            Stylers = new List<object>();
        }

        public ElementType? ElementType { get; set; }

        public FeatureType? FeatureType { get; set; }

        public List<object> Stylers { get; set; }

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("elementType", ElementType != null ? ElementType.ToClientSideString() : null, () => ElementType != null)
                .Add("featureType", FeatureType != null ? FeatureType.ToClientSideString() : null, () => FeatureType != null)
                .Add("stylers", Stylers, () => Stylers.Any());

            return result;
        }
    }
}