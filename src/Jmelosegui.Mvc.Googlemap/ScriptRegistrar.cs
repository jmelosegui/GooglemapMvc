using System;
using System.IO;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI;
using Microsoft.Ajax.Utilities;

namespace Jmelosegui.Mvc.Googlemap
{
    public class ScriptRegistrar
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private bool hasRendered;
        private readonly GoogleMap component;

        public ScriptRegistrar(GoogleMap component)
        {
            ViewContext viewContext = component.ViewContext;

            if (viewContext.HttpContext.Items[Key] != null)
            {
                throw new InvalidOperationException("Only one ScriptRegistrar is allowed in a single request");
            }

            this.component = component;
            viewContext.HttpContext.Items[Key] = this;
            BasePath = "~/Scripts";
            ViewContext = viewContext;
        }

        public string BasePath { get; set; }

        protected ViewContext ViewContext
        {
            get;
            private set;
        }

        public void Render()
        {
            if (hasRendered)
            {
                throw new InvalidOperationException("cannot call render more than once");
            }
            TextWriter writer = ViewContext.Writer;
            using (new HtmlTextWriter(writer))
            {
                Write(writer);
            }
            hasRendered = true;
        }

        protected virtual void Write(TextWriter writer)
        {
            WriteScriptSources(writer);
            WriteScriptStatements(writer);
        }

        private void WriteScriptSources(TextWriter writer)
        {
            const string bundlePath = "~/jmelosegui/googlemap";
            var bundle = new ScriptBundle(bundlePath);

            foreach (var scriptFileName in component.ScriptFileNames)
            {
                var localScriptFileName = scriptFileName;
                
                if (scriptFileName.IndexOf("://", StringComparison.Ordinal) == -1)
                {
                    localScriptFileName = CombinePath(BasePath, scriptFileName);
                    bundle.Include(localScriptFileName);
                }
                else
                {
                   writer.WriteLine(Scripts.Render(localScriptFileName).ToHtmlString());    
                }
            }
            BundleTable.Bundles.Add(bundle);

            writer.WriteLine(Scripts.Render(bundlePath).ToHtmlString());
        }

        private void WriteScriptStatements(TextWriter writer)
        {
            writer.WriteLine("<script type=\"text/javascript\">{0}//<![CDATA[", Environment.NewLine);

            writer.WriteLine("jQuery(document).ready(function(){");
            component.WriteInitializationScript(writer);
            writer.WriteLine();
            writer.WriteLine("});");

            writer.Write("//]]>{0}</script>", Environment.NewLine);
        }

        public string ToHtmlString()
        {
            string result;
            using (var stringWriter = new StringWriter())
            {
                Write(stringWriter);
                result = stringWriter.ToString();
            }
            return result;
        }

        public static string CombinePath(string directory, string fileName)
        {
            const string slash = "/";

            string path = (directory.EndsWith(slash, StringComparison.Ordinal) ? directory : directory + slash) +
                          (fileName.StartsWith(slash, StringComparison.Ordinal) ? fileName.Substring(1) : fileName);

            return path;
        }
    }
}