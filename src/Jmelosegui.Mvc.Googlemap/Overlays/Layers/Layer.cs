namespace Jmelosegui.Mvc.Googlemap.Overlays
{
    public abstract class Layer : Overlay
    {
        internal protected Layer(GoogleMap map) : base(map)
        {
            
        }

        public abstract ISerializer CreateSerializer();
    }
}