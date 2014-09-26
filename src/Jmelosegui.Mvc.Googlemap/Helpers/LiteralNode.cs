using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Jmelosegui.Mvc.Googlemap
{
    public class LiteralNode : IHtmlNode
    {
        private string Content
        {
            get;
            set;
        }
        public string TagName
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public string InnerHtml
        {
            get
            {
                return this.Content;
            }
        }
        public TagRenderMode RenderMode
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public IList<IHtmlNode> Children
        {
            get
            {
                throw new NotSupportedException();
            }
        }
        public LiteralNode(string content)
        {
            this.Content = content;
        }
        public IDictionary<string, string> Attributes()
        {
            throw new NotSupportedException();
        }
        public string Attribute(string key)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Attribute(string key, string value)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Attribute(string key, string value, bool replaceExisting)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> attributes)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Attributes(object attributes)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Attributes<TKey, TValue>(IDictionary<TKey, TValue> attributes, bool replaceExisting)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode AddClass(params string[] classes)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode PrependClass(params string[] classes)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode ToggleClass(string @class, bool condition)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode ToggleCss(string key, string value, bool condition)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode ToggleAttribute(string key, string value, bool condition)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Template(Action<TextWriter> value)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Css(string key, string value)
        {
            throw new NotSupportedException();
        }
        public Action<TextWriter> Template()
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Html(string value)
        {
            throw new NotSupportedException();
        }
        public IHtmlNode Text(string value)
        {
            throw new NotSupportedException();
        }
        public void WriteTo(TextWriter output)
        {
            output.Write(this.Content);
        }
        public IHtmlNode AppendTo(IHtmlNode parent)
        {
            parent.Children.Add(this);
            return this;
        }
        public override string ToString()
        {
            return this.Content;
        }
    }
}
