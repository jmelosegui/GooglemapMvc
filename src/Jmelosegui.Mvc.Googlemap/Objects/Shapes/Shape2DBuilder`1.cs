// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Drawing;

    public abstract class Shape2DBuilder<TShape2D> : ShapeBuilder<TShape2D>
        where TShape2D : Shape2D
    {
        protected Shape2DBuilder(TShape2D shape2D)
            : base(shape2D)
        {
        }

        public Shape2DBuilder<TShape2D> FillColor(Color value)
        {
            this.Shape.FillColor = value;
            return this;
        }

        public Shape2DBuilder<TShape2D> FillOpacity(double value)
        {
            this.Shape.FillOpacity = value;
            return this;
        }
    }
}
