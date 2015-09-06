using System.Collections.Generic;

namespace Jmelosegui.Mvc.GoogleMap
{
    public interface ISerializer
    {
        IDictionary<string, object> Serialize();
    }
}
