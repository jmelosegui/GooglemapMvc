// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;

    public class ShapeSerializer<TShape> : ISerializer
        where TShape : Shape
    {
        private readonly TShape shape;

        public ShapeSerializer(TShape shape)
        {
            this.shape = shape;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            if (!this.shape.Clickable)
            {
                result["Clickable"] = this.shape.Clickable;
            }

            result["StrokeColor"] = this.shape.StrokeColor.ToHtml();
            result["StrokeOpacity"] = this.shape.StrokeOpacity;
            result["StrokeWeight"] = this.shape.StrokeWeight;

            var shape2D = this.shape as Shape2D;
            if (shape2D != null)
            {
                result["FillColor"] = shape2D.FillColor.ToHtml();
                result["FillOpacity"] = shape2D.FillOpacity;
            }

            return result;
        }
    }
}
