namespace Jmelosegui.Mvc.Googlemap.Objects
{
    public abstract class Layer : MapObject
    {
        internal protected Layer(GoogleMap map) : base(map)
        {
            
        }

        public abstract ISerializer CreateSerializer();
    }
}