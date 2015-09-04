using System;
using System.Web;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ScriptRegistrarBuilder : IHtmlString
    {
        protected ScriptRegistrarBuilder(ScriptRegistrarBuilder builder) : this(PassThroughNonNull(builder).ScriptRegistrar)
        {
        }

        public ScriptRegistrarBuilder(ScriptRegistrar scriptRegistrar)
        {
            if (scriptRegistrar == null) throw new ArgumentNullException("scriptRegistrar");

            this.ScriptRegistrar = scriptRegistrar;
        }

        protected ScriptRegistrar ScriptRegistrar { get; private set; }

        public override string ToString()
        {
            return ToHtmlString();
        }

        public string ToHtmlString()
        {
            return ScriptRegistrar.ToHtmlString();
        }

        public ScriptRegistrarBuilder ScriptsBasePath(string basePath)
        {
            UrlHelper.AssertVirtualPath(basePath, "basePath");

            ScriptRegistrar.BasePath = basePath;
            return this;
        }

        private static ScriptRegistrarBuilder PassThroughNonNull(ScriptRegistrarBuilder builder)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            return builder;
        }
    }
}