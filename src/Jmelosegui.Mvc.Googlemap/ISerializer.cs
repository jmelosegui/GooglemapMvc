using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap
{
    public interface ISerializer
    {
        IDictionary<string, object> Serialize();
    }
}
