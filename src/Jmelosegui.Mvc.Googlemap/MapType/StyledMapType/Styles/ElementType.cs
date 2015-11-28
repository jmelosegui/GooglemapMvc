// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
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
