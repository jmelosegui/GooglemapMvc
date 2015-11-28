namespace Jmelosegui.Mvc.GoogleMap.Examples
{
    using System;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using System.Web.UI;

    public class ExampleConfigurator : IDisposable
    {
        public const string CssClass = "configurator";

        private readonly HtmlTextWriter writer;
        private readonly HtmlHelper htmlHelper;
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

            this.form?.EndForm();

            return this;
        }

        public ExampleConfigurator PostTo(string action, string controller)
        {
            this.form = this.htmlHelper.BeginForm(action, controller);
            return this;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.End();
                this.writer.Dispose();
            }
        }
    }
}
