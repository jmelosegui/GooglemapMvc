namespace Jmelosegui.Mvc.Googlemap
{
    public enum ElementType
    {
        [ClientSideEnumValue("'all'")]
        All,
        [ClientSideEnumValue("'geometry'")]
        Geometry,
        [ClientSideEnumValue("'geometry.fill'")]
        GeometryFill,
        [ClientSideEnumValue("'geometry.stroke'")]
        GeometryStroke,
        [ClientSideEnumValue("'labels'")]
        Labels,
        [ClientSideEnumValue("'labels.icon'")]
        LabelsIcon,
        [ClientSideEnumValue("'labels.text'")]
        LabelsText,
        [ClientSideEnumValue("'labels.text.fill'")]
        LabelsTextFill,
        [ClientSideEnumValue("'labels.text.stroke'")]
        LabelsTextStroke
    }
}
