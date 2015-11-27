// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public abstract class ShapeBuilder<TShape>
        where TShape : Shape
    {
        protected ShapeBuilder(ShapeBuilder<TShape> builder)
            : this(PassThroughNonNull(builder).Shape)
        {
        }

        protected ShapeBuilder(TShape shape)
        {
            this.Shape = shape;
        }

        protected TShape Shape { get; }

        public ShapeBuilder<TShape> Clickable(bool enabled)
        {
            this.Shape.Clickable = enabled;
            return this;
        }

        public ShapeBuilder<TShape> StrokeColor(Color value)
        {
            this.Shape.StrokeColor = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeOpacity(double value)
        {
            this.Shape.StrokeOpacity = value;
            return this;
        }

        public ShapeBuilder<TShape> StrokeWeight(int value)
        {
            this.Shape.StrokeWeight = value;
            return this;
        }

        public ShapeBuilder<TShape> ZIndex(int value)
        {
            this.Shape.ZIndex = value;
            return this;
        }

        private static ShapeBuilder<TShape> PassThroughNonNull(ShapeBuilder<TShape> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}
