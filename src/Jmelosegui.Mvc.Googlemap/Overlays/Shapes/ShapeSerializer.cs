using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public class ShapeSerializer<TShape>: ISerializer where TShape : Shape
    {
        private readonly TShape shape;

        public ShapeSerializer(TShape shape)
        {
            this.shape = shape;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if(shape.Clickable)
                result["Clickable"] = shape.Clickable;
            result["FillColor"] = shape.FillColor.ToHtml();
            result["FillOpacity"] = shape.FillOpacity;
            result["StrokeColor"] = shape.StrokeColor.ToHtml();
            result["StrokeOpacity"] = shape.StrokeOpacity;
            result["StrokeWeight"] = shape.StrokeWeight;

            return result;
        }
    }
}
