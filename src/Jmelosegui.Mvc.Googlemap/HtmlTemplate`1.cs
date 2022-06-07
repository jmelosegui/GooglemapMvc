// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Text.Encodings.Web;
    using Jmelosegui.Mvc.GoogleMap.Extensions;
    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Newtonsoft.Json;

    public class HtmlTemplate<T>
        where T : class
    {
        private readonly ViewContext viewContext;
        private string html;
        private Func<T, object> inlineTemplate;
        private Action<T, TagBuilder> binder;

        public HtmlTemplate(ViewContext viewContext)
        {
            this.viewContext = viewContext ?? throw new ArgumentNullException(nameof(viewContext));
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

                this.binder = (dataItem, node) => node.InnerHtml.AppendHtml(this.html);
                this.inlineTemplate = null;
            }
        }

        [JsonIgnore]
        public Func<T, object> InlineTemplate
        {
            get
            {
                return this.inlineTemplate;
            }

            set
            {
                this.inlineTemplate = value;
                this.binder = (dataItem, node) =>
                {
                    var result = this.InlineTemplate(dataItem);
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

        public void Apply(T dataItem, TagBuilder node)
        {
            if (this.HasValue())
            {
                this.binder(dataItem, node);
            }
        }

        public bool HasValue()
        {
            return this.Html.HasValue() || this.InlineTemplate != null;
        }
    }
}
