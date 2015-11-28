// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public class Layer : MapObject
    {
        internal protected Layer(string name, Map map)
            : base(map)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public virtual LayerSerializer CreateSerializer()
        {
            return new LayerSerializer(this);
        }
    }
}