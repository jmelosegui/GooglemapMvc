// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.IO;
    using System.Text.Encodings.Web;
    using Microsoft.AspNetCore.Html;

    public class ScriptRegistrarBuilder : IHtmlContent
    {
        public ScriptRegistrarBuilder(ScriptRegistrar scriptRegistrar)
        {
            if (scriptRegistrar == null)
            {
                throw new ArgumentNullException(nameof(scriptRegistrar));
            }

            this.ScriptRegistrar = scriptRegistrar;
        }

        protected ScriptRegistrarBuilder(ScriptRegistrarBuilder builder)
            : this(PassThroughNonNull(builder).ScriptRegistrar)
        {
        }

        protected ScriptRegistrar ScriptRegistrar { get; }

        public ScriptRegistrarBuilder ScriptsBasePath(string basePath)
        {
            UrlHelper.AssertVirtualPath(basePath, nameof(basePath));

            this.ScriptRegistrar.BasePath = basePath;
            return this;
        }

        public ScriptRegistrarBuilder Add(string scriptFileName)
        {
            if (string.IsNullOrWhiteSpace(scriptFileName))
            {
                throw new ArgumentNullException(nameof(scriptFileName));
            }

            this.ScriptRegistrar.FixedScriptCollection.Add(scriptFileName);
            return this;
        }

        private static ScriptRegistrarBuilder PassThroughNonNull(ScriptRegistrarBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }

        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            this.ScriptRegistrar.WriteHtml(writer);
        }
    }
}