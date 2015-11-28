// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class ClientEvent
    {
        public Action CodeBlock { get; set; }

        public Func<object, object> InlineCodeBlock { get; set; }

        public string HandlerName { get; set; }

        public bool HasValue()
        {
            return this.CodeBlock != null || this.InlineCodeBlock != null || this.HandlerName.HasValue();
        }
    }
}
