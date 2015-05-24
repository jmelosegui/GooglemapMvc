using System;

namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public class MapObjectBindingBuilder<TMapObject, TDataItem> where TMapObject : MapObject
    {
        readonly MapObjectBinding<TMapObject, TDataItem> bindingComponent;

        public MapObjectBindingBuilder(MapObjectBinding<TMapObject, TDataItem> mapObjectBinding)
        {
            bindingComponent = mapObjectBinding;
        }

        public MapObjectBindingBuilder<TMapObject, TDataItem> ItemDataBound(Action<TMapObject, TDataItem> action)
        {
            bindingComponent.ItemDataBound = action;
            return this;
        }
    }

}