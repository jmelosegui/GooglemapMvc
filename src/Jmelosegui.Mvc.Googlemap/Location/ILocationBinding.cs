namespace Jmelosegui.Mvc.GoogleMap
{
    public interface ILocationBinding<in TLocationContainer> where TLocationContainer : ILocationContainer
    {
        void ItemDataBound(TLocationContainer item, object value);
    }
}