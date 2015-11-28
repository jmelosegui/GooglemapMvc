// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

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
