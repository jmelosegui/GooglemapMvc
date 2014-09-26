using System;

namespace Jmelosegui.Mvc.Googlemap
{
    static class UrlHelper
    {
        public static void AssertVirtualPath(string parameter, string parameterName)
        {
            if (!parameter.HasValue())
            {
                throw new ArgumentNullException(parameterName, "can not be null or empty");
            }

            if (!parameter.StartsWith("~/", StringComparison.Ordinal))
            {
                throw new ArgumentException("Source must be a virtual path which should starts with tile and slash", parameterName);
            }
        }
        

    }
}
