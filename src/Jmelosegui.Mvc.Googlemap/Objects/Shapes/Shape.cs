// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public abstract class Shape : MapObject
    {
        private double strokeOpacity;

        protected Shape(Map map)
            : base(map)
        {
            this.strokeOpacity = 0.8D;
            this.StrokeWeight = 2;
            this.StrokeColor = Color.DarkRed;
            this.ZIndex = 1;
            this.Clickable = true;
        }

        public bool Clickable { get; set; }

        public Color StrokeColor { get; set; }

        public double StrokeOpacity
        {
            get
            {
                return this.strokeOpacity;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The stroke opacity between 0.0 and 1.0");
                }

                this.strokeOpacity = value;
            }
        }

        public int StrokeWeight { get; set; }

        public int ZIndex { get; set; }

        public abstract ISerializer CreateSerializer();
    }
}
