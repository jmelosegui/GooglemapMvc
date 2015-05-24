using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MapObjectBinding<TMapObject, TDataItem> : IMapOpjectBinding<TMapObject> where TMapObject : MapObject
    {

        public Action<TMapObject, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void IMapOpjectBinding<TMapObject>.ItemDataBound(TMapObject item, object value)
        {
            ItemDataBound(item, (TDataItem)value);
        }

    }

    public interface IMapOpjectBinding<in TMapObject> where TMapObject : MapObject
    {
        void ItemDataBound(TMapObject item, object value);
    }
}
