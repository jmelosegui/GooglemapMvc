namespace Jmelosegui.Mvc.Googlemap.Objects
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