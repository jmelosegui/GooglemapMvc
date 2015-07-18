using System;

namespace Jmelosegui.Mvc.Googlemap.Objects.Layers
{
    public class LayerBuilder<T>  : LayerBuilder where T : Layer
    {
        public LayerBuilder(T layer) : base(layer)
        {
        }

        public new T Layer
        {
            get { return base.Layer as T; }
        }
    }

    public class LayerBuilder : IHideObjectMembers
    {
        public LayerBuilder(Layer layer)
        {
            if (layer == null) throw new ArgumentNullException("layer");

            Layer = layer;
        }

        public Layer Layer { get; private set; }
    }
}
