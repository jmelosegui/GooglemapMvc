using System;
using System.ComponentModel;

namespace Jmelosegui.Mvc.Googlemap
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
    }
}
