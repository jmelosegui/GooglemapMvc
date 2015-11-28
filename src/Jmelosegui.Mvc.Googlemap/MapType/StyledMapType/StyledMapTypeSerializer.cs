// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System.Collections.Generic;
    using System.Linq;

    public class StyledMapTypeSerializer : MapTypeSerializer
    {
        private readonly StyledMapType styledMapType;

        public StyledMapTypeSerializer(StyledMapType styledMapType)
            : base(styledMapType)
        {
            this.styledMapType = styledMapType;
        }

        public override IDictionary<string, object> Serialize()
        {
            var customStyles = new List<IDictionary<string, object>>();

            if (this.styledMapType.Styles.Any())
            {
                this.styledMapType.Styles.Each(cs => customStyles.Add(cs.Serialize()));
            }

            IDictionary<string, object> result = base.Serialize();
            FluentDictionary.For(result)
                .Add("styles", customStyles, () => this.styledMapType.Styles.Any());

            return result;
        }
    }
}