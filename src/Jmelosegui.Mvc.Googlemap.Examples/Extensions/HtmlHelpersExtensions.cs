namespace Jmelosegui.Mvc.GoogleMap.Examples
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;

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

        public static IHtmlString Raw(this string value)
        {
            return new HtmlString(value);
        }
    }
}
