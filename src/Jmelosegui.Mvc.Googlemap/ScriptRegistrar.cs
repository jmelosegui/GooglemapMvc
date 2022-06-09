// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ScriptRegistrar
    {
        public static readonly string Key = typeof(ScriptRegistrar).AssemblyQualifiedName;
        private bool hasRendered;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "ScriptRegistrar", Justification = "Need to specify the actual name")]
        public ScriptRegistrar(ViewContext viewContext)
        {
            if (viewContext == null)
            {
                throw new ArgumentNullException(nameof(viewContext));
            }

            if (viewContext.HttpContext.Items[Key] != null)
            {
                throw new InvalidOperationException("Only one ScriptRegistrar is allowed in a single request");
            }

            this.Components = new Collection<Map>();
            this.FixedScriptCollection = new List<string>();
            viewContext.HttpContext.Items[Key] = this;
            this.BasePath = "/js";
            this.ViewContext = viewContext;
        }

        public string BasePath { get; set; }

        internal List<string> FixedScriptCollection { get; }

        protected Collection<Map> Components { get; }

        protected ViewContext ViewContext
        {
            get;
        }

        public void Render()
        {
            if (this.hasRendered)
            {
                throw new InvalidOperationException("Cannot call render more than once.");
            }

            TextWriter writer = this.ViewContext.Writer;
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            this.WriteHtml(writer);

            this.hasRendered = true;
        }

        internal void AddComponent(Map component)
        {
            if (component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            this.Components.Add(component);
        }

        protected internal virtual void WriteHtml(TextWriter writer)
        {
            this.WriteScriptSources(writer);
            this.WriteScriptStatements(writer);
        }

        private static string CombinePath(string directory, string fileName)
        {
            const string slash = "/";

            string path = (directory.EndsWith(slash, StringComparison.Ordinal) ? directory : directory + slash) +
                          (fileName.StartsWith(slash, StringComparison.Ordinal) ? fileName.Substring(1) : fileName);

            return path;
        }

        private void WriteScriptSources(TextWriter writer)
        {
            var scripts = this.Components.SelectMany(c => c.ScriptFileNames)
                              .Union(this.FixedScriptCollection)
                              .Distinct()
                              .ToList();

            foreach (var scriptFileName in scripts)
            {
                string scriptPath = null;
                if (scriptFileName.IndexOf("://", StringComparison.Ordinal) == -1)
                {
                    scriptPath = CombinePath(this.BasePath, scriptFileName);
                }
                else
                {
                    scriptPath = scriptFileName;
                }

                var scriptTag = @$"<script src=""{scriptPath}""></script>";
                writer.WriteLine(scriptTag);
            }
        }

        private void WriteScriptStatements(TextWriter writer)
        {
            if (!this.Components.Any())
            {
                return;
            }

            writer.WriteLine("<script type=\"text/javascript\">{0}//<![CDATA[", Environment.NewLine);
            writer.WriteLine(this.ViewContext.HttpContext.Request.IsAjaxRequest()
                ? this.GetAjaxScriptStart()
                : "document.addEventListener('DOMContentLoaded', function(event) {");

            foreach (var component in this.Components)
            {
                component.WriteInitializationScript(writer);
                writer.WriteLine();
            }

            writer.WriteLine(this.ViewContext.HttpContext.Request.IsAjaxRequest()
               ? this.GetAjaxScriptEnd()
               : "});");
            writer.Write("//]]>{0}</script>", Environment.NewLine);
        }

        private bool ShouldLoadScripts()
        {
            return this.Components.FirstOrDefault(m => m.LoadScripts) != null;
        }

        private string GetAjaxScriptStart()
        {
            if (this.ShouldLoadScripts())
            {
                return "function executeAsync(){";
            }

            return "(function (){";
        }

        private string GetAjaxScriptEnd()
        {
            if (this.ShouldLoadScripts())
            {
                return "}";
            }

            return "})();";
        }
    }
}