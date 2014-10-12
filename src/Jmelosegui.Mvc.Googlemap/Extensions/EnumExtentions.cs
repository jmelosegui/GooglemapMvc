using System;
using System.Linq;

namespace Jmelosegui.Mvc.Googlemap
{
    public static class EnumExtentions
    {
        public static string ToClientSideString(this Enum source)
        {
            var valueAttribute = source.GetType().GetField(source.ToString())
                                    .GetCustomAttributes(true)
                                    .OfType<ClientSideEnumValueAttribute>()
                                    .FirstOrDefault<ClientSideEnumValueAttribute>();

            if (valueAttribute == null)
            {
                throw new Exception("You must decorate the enum value with the attribute \"ClientSideEnumValueAttribute\"");
            }

            return valueAttribute.Value.Replace("'", "");
        }
    }
}
