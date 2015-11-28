// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Web;

    public class ScriptRegistrarBuilder : IHtmlString
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

        public override string ToString()
        {
            return this.ToHtmlString();
        }

        public string ToHtmlString()
        {
            return this.ScriptRegistrar.ToHtmlString();
        }

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
    }
}