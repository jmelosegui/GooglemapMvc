using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
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

            if(!shape.Clickable)
                result["Clickable"] = shape.Clickable;
            result["StrokeColor"] = shape.StrokeColor.ToHtml();
            result["StrokeOpacity"] = shape.StrokeOpacity;
            result["StrokeWeight"] = shape.StrokeWeight;

            var shape2D = shape as Shape2D;
            if (shape2D != null)
            {
                result["FillColor"] = shape2D.FillColor.ToHtml();
                result["FillOpacity"] = shape2D.FillOpacity;
            }

            return result;
        }
    }
}
