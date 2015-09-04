using System;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class MapObjectBindingFactory<TMapObject> where TMapObject : MapObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public MapObjectBindingFactory<TMapObject> For<TDataItem>(Action<MapObjectBindingBuilder<TMapObject, TDataItem>> action)
        {
            if(action == null) throw new ArgumentNullException("action");
            
            Binder = new MapObjectBinding<TMapObject, TDataItem>();
            var builder = new MapObjectBindingBuilder<TMapObject, TDataItem>((MapObjectBinding<TMapObject, TDataItem>)Binder);
            action(builder);

            return this;
        }

        public IMapObjectBinding<TMapObject> Binder { get; private set; }
    }
}
