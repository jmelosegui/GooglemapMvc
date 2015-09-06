namespace Jmelosegui.Mvc.GoogleMap
{
    public enum MapType
    {
        [ClientSideEnumValue("'HYBRID'")]
        Hybrid,
        [ClientSideEnumValue("'ROADMAP'")]
        Roadmap,
        [ClientSideEnumValue("'SATELLITE'")]
        Satellite,
        [ClientSideEnumValue("'TERRAIN'")]
        Terrain
    }
}
