using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap
{
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