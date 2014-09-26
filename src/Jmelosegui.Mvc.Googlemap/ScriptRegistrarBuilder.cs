using System;
using System.Web;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ScriptRegistrarBuilder : IHtmlString
    {
        private readonly ScriptRegistrar scriptRegistrar;

        public ScriptRegistrarBuilder(ScriptRegistrar scriptRegistrar)
        {
            this.scriptRegistrar = scriptRegistrar;
        }

        public override string ToString()
        {
            return ToHtmlString();
        }

        public string ToHtmlString()
        {
            return scriptRegistrar.ToHtmlString();
        }

        public ScriptRegistrarBuilder ScriptsBasePath(string basePath)
        {
            UrlHelper.AssertVirtualPath(basePath, "basePath");

            scriptRegistrar.BasePath = basePath;
            return this;
        }
    }
}