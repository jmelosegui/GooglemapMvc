// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class LayerSerializer<T> : LayerSerializer
        where T : Layer
    {
        internal LayerSerializer(T layer)
            : base(layer)
        {
        }

        public new T Layer
        {
            get { return base.Layer as T; }
        }
    }
}