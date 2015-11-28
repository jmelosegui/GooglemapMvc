// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class LayerBuilder<T>
        where T : Layer
    {
        public LayerBuilder(T layer)
        {
            if (layer == null)
            {
                throw new ArgumentNullException(nameof(layer));
            }

            this.Layer = layer;
        }

        protected T Layer { get; private set; }
    }
}
