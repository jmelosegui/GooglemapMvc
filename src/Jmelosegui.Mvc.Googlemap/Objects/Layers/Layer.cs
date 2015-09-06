namespace Jmelosegui.Mvc.GoogleMap
{
    public class Layer : MapObject
    {
        internal protected Layer(string name, Map map) : base(map)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public virtual LayerSerializer CreateSerializer()
        {
            return new LayerSerializer(this);
        }
    
    }
}