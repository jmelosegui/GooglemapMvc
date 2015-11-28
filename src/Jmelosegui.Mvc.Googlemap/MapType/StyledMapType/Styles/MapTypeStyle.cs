// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class MapTypeStyle : ISerializer
    {
        public MapTypeStyle()
        {
            this.Stylers = new Collection<object>();
        }

        public ElementType? ElementType { get; set; }

        public FeatureType? FeatureType { get; set; }

        public Collection<object> Stylers { get; private set; }

        public IDictionary<string, object> Serialize()
        {
            IDictionary<string, object> result = new Dictionary<string, object>();

            FluentDictionary.For(result)
                .Add("elementType", this.ElementType?.ToClientSideString(), () => this.ElementType != null)
                .Add("featureType", this.FeatureType?.ToClientSideString(), () => this.FeatureType != null)
                .Add("stylers", this.Stylers, () => this.Stylers.Any());

            return result;
        }
    }
}