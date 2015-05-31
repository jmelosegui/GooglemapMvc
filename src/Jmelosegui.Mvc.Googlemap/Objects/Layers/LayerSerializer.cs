using System.Collections.Generic;
using System.Globalization;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public abstract class LayerSerializer : ISerializer
    {
        public abstract string Name { get; }

        protected abstract IDictionary<string, object> LayerSerialize();

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["name"] = Name.ToLower(CultureInfo.InvariantCulture);
            result["options"] = LayerSerialize();
            return result;
        }


    }
}