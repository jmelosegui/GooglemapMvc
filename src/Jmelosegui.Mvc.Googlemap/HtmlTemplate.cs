// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Text.Encodings.Web;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;

    public class HtmlTemplate
    {
        private string html;
        private Func<object> inlineTemplate;
        private Action<TagBuilder> binder;

        public HtmlTemplate()
        {
        }

        public string Html
        {
            get
            {
                return this.html;
            }

            set
            {
                this.html = value;

                this.binder = (node) => node.InnerHtml.AppendHtml(this.html);
                this.inlineTemplate = null;
            }
        }

        [JsonIgnore]
        public Func<object> InlineTemplate
        {
            get
            {
                return this.inlineTemplate;
            }

            set
            {
                this.inlineTemplate = value;
                this.binder = (node) =>
                {
                    var result = this.InlineTemplate();
                    var helperResult = result as IHtmlContent;
                    if (helperResult != null)
                    {
                        node.InnerHtml.AppendHtml(helperResult);
                        return;
                    }

                    if (result != null)
                    {
                        node.InnerHtml.AppendHtml(result.ToString());
                        return;
                    }
                };

                this.html = null;
            }
        }

        public void Apply(TagBuilder node)
        {
            if (this.HasValue())
            {
                this.binder(node);
            }
        }

        public bool HasValue()
        {
            return this.Html.HasValue() || this.InlineTemplate != null;
        }
    }
}
