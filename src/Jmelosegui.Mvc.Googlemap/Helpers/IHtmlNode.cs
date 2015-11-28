// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Mvc;

    public interface IHtmlNode
    {
        string TagName
        {
            get;
        }

        string InnerHtml
        {
            get;
        }

        TagRenderMode RenderMode
        {
            get;
        }

        IList<IHtmlNode> Children
        {
            get;
        }

        IDictionary<string, string> Attributes();

        string Attribute(string key);

        IHtmlNode Attribute(string key, string value);

        IHtmlNode Attribute(string key, string value, bool replaceExisting);

        IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> values);

        IHtmlNode Attributes(object value);

        IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> values, bool replaceExisting);

        IHtmlNode AddClass(params string[] classes);

        IHtmlNode PrependClass(params string[] classes);

        IHtmlNode ToggleClass(string cssClass, bool condition);

        IHtmlNode ToggleAttribute(string key, string value, bool condition);

        IHtmlNode ToggleCss(string key, string value, bool condition);

        IHtmlNode Template(Action<TextWriter> value);

        IHtmlNode Css(string key, string value);

        Action<TextWriter> Template();

        IHtmlNode Html(string value);

        IHtmlNode Text(string value);

        void WriteTo(TextWriter output);

        IHtmlNode AppendTo(IHtmlNode parent);
    }
}