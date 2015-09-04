using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class ClientEvent
    {
        public Action CodeBlock { get; set; }

        public Func<object, object> InlineCodeBlock { get; set; }

        public string HandlerName { get; set; }

        public bool HasValue()
        {
            return CodeBlock != null || InlineCodeBlock != null || HandlerName.HasValue();
        }
    }
}
