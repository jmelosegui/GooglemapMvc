using System;
using System.Linq;

namespace Jmelosegui.Mvc.Googlemap
{
    public static class EnumExtensions
    {
        public static string ToClientSideString(this Enum source)
        {
            if (source == null) throw new ArgumentNullException("source");

            var valueAttribute = source.GetType().GetField(source.ToString())
                                    .GetCustomAttributes(true)
                                    .OfType<ClientSideEnumValueAttribute>()
                                    .FirstOrDefault<ClientSideEnumValueAttribute>();

            if (valueAttribute == null)
            {
                throw new InvalidOperationException("You must decorate the enum value with the attribute \"ClientSideEnumValueAttribute\"");
            }

            return valueAttribute.Value.Replace("'", "");
        }
    }
}
