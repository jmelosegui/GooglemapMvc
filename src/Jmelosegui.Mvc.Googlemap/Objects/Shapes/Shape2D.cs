// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;

    public abstract class Shape2D : Shape
    {
        private double fillOpacity;

        protected Shape2D(Map map)
            : base(map)
        {
            this.fillOpacity = 0.5D;
            this.FillColor = Color.Red;
        }

        public Color FillColor { get; set; }

        public double FillOpacity
        {
            get
            {
                return this.fillOpacity;
            }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "The fill opacity between 0.0 and 1.0");
                }

                this.fillOpacity = value;
            }
        }
    }
}
