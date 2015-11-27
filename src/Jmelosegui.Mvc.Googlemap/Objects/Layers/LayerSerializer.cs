// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;
    using System.Globalization;

    public class LayerSerializer : ISerializer
    {
        internal LayerSerializer(Layer layer)
        {
            this.Layer = layer;
        }

        public Layer Layer { get; private set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();
            result["name"] = this.Layer.Name.ToLower(CultureInfo.InvariantCulture);
            result["options"] = this.LayerSerialize();
            return result;
        }

        protected virtual IDictionary<string, object> LayerSerialize()
        {
            return new Dictionary<string, object>();
        }
    }
}