namespace Jmelosegui.Mvc.GoogleMap
{
    internal enum LayerType
    {
        [ClientSideEnumValue("'Traffic'")]
        Traffic,
        [ClientSideEnumValue("'Transit'")]
        Transit,
        [ClientSideEnumValue("'Bicycling'")]
        Bicycling
    }
}