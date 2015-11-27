// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using Newtonsoft.Json;

    public class HtmlTemplate : HtmlTemplate<object>
    {
        private Action content;

        [JsonIgnore]
        public Action Content
        {
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
                if (value != null)
                {
                    this.CodeBlockTemplate = obj => this.content();
                }
                else
                {
                    this.CodeBlockTemplate = null;
                }
            }
        }

        public void Apply(IHtmlNode node)
        {
            this.Apply(null, node);
        }
    }
}
