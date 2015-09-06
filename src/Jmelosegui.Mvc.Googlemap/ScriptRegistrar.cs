using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.UI;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class ScriptRegistrar
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private bool hasRendered;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ScriptRegistrar", Justification = "Need to specify the actual name")]
        public ScriptRegistrar(ViewContext viewContext)
        {
            if(viewContext == null) throw new ArgumentNullException("viewContext");
            if (viewContext.HttpContext.Items[Key] != null)
            {
                throw new InvalidOperationException("Only one ScriptRegistrar is allowed in a single request");
            }

            Components = new Collection<Map>();
            FixedScriptCollection = new List<string>();
            viewContext.HttpContext.Items[Key] = this;
            BasePath = "~/Scripts";
            ViewContext = viewContext;
        }

        public string BasePath { get; set; }

        protected Collection<Map> Components { get; private set; }

        internal List<string> FixedScriptCollection { get; private set; }

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

        internal void AddComponent(Map component)
        {
            if(component == null) throw new ArgumentNullException("component");

            Components.Add(component);
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

            var scripts = Components.SelectMany(c => c.ScriptFileNames)
                                    .Union(FixedScriptCollection).Distinct().ToList();
            foreach (var scriptFileName in scripts)
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
            if (!Components.Any()) return;

            writer.WriteLine("<script type=\"text/javascript\">{0}//<![CDATA[", Environment.NewLine);
            writer.WriteLine(ViewContext.HttpContext.Request.IsAjaxRequest()
                ? GetAjaxScriptStart()
                : "jQuery(document).ready(function(){");

            foreach (var component in Components)
            {
                component.WriteInitializationScript(writer);
                writer.WriteLine();
            }
            writer.WriteLine(ViewContext.HttpContext.Request.IsAjaxRequest()
               ? GetAjaxScriptEnd()
               : "});");
            writer.Write("//]]>{0}</script>", Environment.NewLine); 
        }

        public string ToHtmlString()
        {
            string result;
            using (var stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                Write(stringWriter);
                result = stringWriter.ToString();
            }
            return result;
        }

        private static string CombinePath(string directory, string fileName)
        {
            const string slash = "/";

            string path = (directory.EndsWith(slash, StringComparison.Ordinal) ? directory : directory + slash) +
                          (fileName.StartsWith(slash, StringComparison.Ordinal) ? fileName.Substring(1) : fileName);

            return path;
        }

        private bool ShouldLoadScripts()
        {
            return Components.FirstOrDefault(m => m.LoadScripts) != null;
        }

        private string GetAjaxScriptStart()
        {
            if (ShouldLoadScripts())
            {
                return "function executeAsync(){";
            }
            return "(function (){";
        }

        private string GetAjaxScriptEnd()
        {
            if (ShouldLoadScripts())
            {
                return "}";
            }
            return "})();";
        }
    }
}