using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI;

namespace Jmelosegui.Mvc.Googlemap.Examples
{
    public static class HtmlHelpersExtensions
    {
        public static ExampleConfigurator Configurator(this HtmlHelper instance, string title)
        {
            return new ExampleConfigurator(instance).Title(title);
        }

        public static IHtmlString CheckBox(this HtmlHelper html, string id, bool isChecked, string labelText)
        {
            return (html.CheckBox(id, isChecked) + new HtmlElement("label").Attribute("for", id).Html(labelText).ToString()).Raw();
        }

        public static System.Web.IHtmlString Raw(this string value)
        {
            return new System.Web.HtmlString(value);
        }

    }

    public class ExampleConfigurator : IDisposable
    {
        public const string CssClass = "configurator";

        private HtmlTextWriter writer;
        private HtmlHelper htmlHelper;
        private string title;
        private MvcForm form;

        public ExampleConfigurator(HtmlHelper htmlHelper)
        {
            this.htmlHelper = htmlHelper;
            this.writer = new HtmlTextWriter(htmlHelper.ViewContext.Writer);
        }

        public ExampleConfigurator Title(string title)
        {
            this.title = title;

            return this;
        }

        public ExampleConfigurator Begin()
        {
            this.writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
            this.writer.RenderBeginTag(HtmlTextWriterTag.Div);

            this.writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass + "-legend");
            this.writer.RenderBeginTag(HtmlTextWriterTag.H3);
            this.writer.Write(this.title);
            this.writer.RenderEndTag();

            return this;
        }

        public ExampleConfigurator End()
        {
            this.writer.RenderEndTag();

            if (this.form != null)
            {
                this.form.EndForm();
            }

            return this;
        }

        public void Dispose()
        {
            this.End();
        }

        public ExampleConfigurator PostTo(string action, string controller)
        {
            form = htmlHelper.BeginForm(action, controller);
            return this;
        }
    }
}
