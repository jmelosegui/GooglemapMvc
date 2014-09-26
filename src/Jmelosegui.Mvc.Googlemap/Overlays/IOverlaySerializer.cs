using System.Collections.Generic;

namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public interface IOverlaySerializer
    {
        IDictionary<string, object> Serialize();
    }
}
