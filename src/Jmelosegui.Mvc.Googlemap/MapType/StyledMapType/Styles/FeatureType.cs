// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    public enum FeatureType
    {
        [ClientSideEnumValue("'administrative'")]
        Administrative,

        [ClientSideEnumValue("'administrative.country'")]
        AdministrativeCountry,

        [ClientSideEnumValue("'administrative.land_parcel'")]
        AdministrativeLandParcel,

        [ClientSideEnumValue("'administrative.locality'")]
        AdministrativeLocality,

        [ClientSideEnumValue("'administrative.neighborhood'")]
        AdministrativeNeighborhood,

        [ClientSideEnumValue("'administrative.province'")]
        AdministrativeProvince,

        [ClientSideEnumValue("'all'")]
        All,

        [ClientSideEnumValue("'landscape'")]
        Landscape,

        [ClientSideEnumValue("'landscape.man_made'")]
        LandscapeManMade,

        [ClientSideEnumValue("'landscape.natural'")]
        LandscapeNatural,

        [ClientSideEnumValue("'landscape.natural.landcover'")]
        LandscapeNaturalLandcover,

        [ClientSideEnumValue("'landscape.natural.terrain'")]
        LandscapeNaturalTerrain,

        [ClientSideEnumValue("'poi'")]
        Poi,

        [ClientSideEnumValue("'poi.attraction'")]
        PoiAttraction,

        [ClientSideEnumValue("'poi.business'")]
        PoiBusiness,

        [ClientSideEnumValue("'poi.government'")]
        PoiGovernment,

        [ClientSideEnumValue("'poi.medical'")]
        PoiMedical,

        [ClientSideEnumValue("'poi.park'")]
        PoiPark,

        [ClientSideEnumValue("'poi.place_of_worship'")]
        PoiPlaceOfWorship,

        [ClientSideEnumValue("'poi.school'")]
        PoiSchool,

        [ClientSideEnumValue("'poi.sports_complex'")]
        PoiSportComplex,

        [ClientSideEnumValue("'road'")]
        Road,

        [ClientSideEnumValue("'road.arterial'")]
        RoadArterial,

        [ClientSideEnumValue("'road.highway'")]
        RoadHighway,

        [ClientSideEnumValue("'road.highway.controlled_access'")]
        RoadHighwayControlledAccess,

        [ClientSideEnumValue("'road.local'")]
        RoadLocal,

        [ClientSideEnumValue("'transit'")]
        Transit,

        [ClientSideEnumValue("'transit.line'")]
        TransitLine,

        [ClientSideEnumValue("'transit.station'")]
        TransitStation,

        [ClientSideEnumValue("'transit.station.airport'")]
        TransitStationAirport,

        [ClientSideEnumValue("'transit.station.bus'")]
        TransitStationBus,

        [ClientSideEnumValue("'transit.station.rail'")]
        TransitStationRail,

        [ClientSideEnumValue("'water'")]
        Water,
    }
}
