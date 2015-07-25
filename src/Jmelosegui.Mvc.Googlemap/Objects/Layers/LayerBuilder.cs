using System;

namespace Jmelosegui.Mvc.Googlemap.Objects.Layers
{
    public class LayerBuilder<T> where T : Layer
    {
        public LayerBuilder(T layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");
            Layer = layer;
        }

        protected T Layer { get; private set; }
    }
}
