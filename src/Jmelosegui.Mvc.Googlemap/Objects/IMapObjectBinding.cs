using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public sealed class MapObjectBinding<TMapObject, TDataItem> : IMapObjectBinding<TMapObject> where TMapObject : MapObject
    {

        public Action<TMapObject, TDataItem> ItemDataBound
        {
            get;
            set;
        }

        void IMapObjectBinding<TMapObject>.ItemDataBound(TMapObject item, object value)
        {
            ItemDataBound(item, (TDataItem)value);
        }

    }

    public interface IMapObjectBinding<in TMapObject> where TMapObject : MapObject
    {
        void ItemDataBound(TMapObject item, object value);
    }
}
