using System.Collections.Generic;
using System.Globalization;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class LayerSerializer<T> : LayerSerializer where T : Layer
    {
        internal LayerSerializer(T layer) : base(layer)
        {
        }

        public new T Layer
        {
            get { return base.Layer as T; }
            
        }
    }

    public class LayerSerializer : ISerializer
    {
        internal LayerSerializer(Layer layer)
        {
            Layer = layer;
        }

        public Layer Layer { get; private set; }

        protected virtual IDictionary<string, object> LayerSerialize()
        {
            return new Dictionary<string, object>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["name"] = Layer.Name.ToLower(CultureInfo.InvariantCulture);
            result["options"] = LayerSerialize();
            return result;
        }

    }
}