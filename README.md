[Googlemap control for Asp.Net MVC](http://www.jmelosegui.com/map/)
==============================
[![Build status](https://ci.appveyor.com/api/projects/status/github/jmelosegui/googlemapmvc?branch=dev&svg=true)](https://ci.appveyor.com/project/jmelosegui/googlemapmvc) [![Join the chat at https://gitter.im/jmelosegui/GooglemapMvc](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/jmelosegui/GooglemapMvc?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/dt/Jmelosegui.Mvc.Googlemap.svg)]()
[![NuGet](https://img.shields.io/nuget/v/Jmelosegui.Mvc.Googlemap.svg)]()

Googlemap control for Asp.Net MVC wraps Google Maps APIs simplifying the use of Google Maps in ASP.NET MVC applications.

## Features

- Specific Api Version
- UI Controls
- Map Language
- Multiple Maps
- Client Events
- PartialView with Ajax
- Map Types
  - Styled Map Type
  - [Image Map Type (Game of Thrones)](http://www.jmelosegui.com/map/MapType/ImageMapType)
- Markers
  - Custom Icons
  - Info Windows
  - Clustering
  - Databinding
  - Client Events
  - Geocoding
  - FitToMarkersBounds
  - External Reference
- Shapes
  - Polyline
  - Polygons
  - Circles
  - Databinding
- Services
  - Geolocation
  - Geocoding
- Layers
  - Heatmap
  - Kml
  - Traffic
  - Transit
  - Bicycling

## Install

Inside Visual Studio create a new AspNet Mvc Application. Open the package manager console and install the Googlemap Mvc nuget package by typing the following command.

##### PM> Install-Package Jmelosegui.Mvc.Googlemap

Once you have it go to the Views->Home->Index.cshtml and include the following
```html
<div class="row">
    <div class="col-md-12">
        @(Html.GoogleMap()
              .Name("map")
              .Height(500)
          )
    </div>
</div>
```
and at the end of that page add the following

```aspnetmvc
@section scripts
{
    @(Html.GoogleMap().ScriptRegistrar())
}
```
Don't forget to add the namespace to the very top of your page

```
@using Jmelosegui.Mvc.GoogleMap
```

Now hit F5 and you should see the map rendering on the page 
 
## Links

[Nuget Package](https://www.nuget.org/packages/Jmelosegui.Mvc.Googlemap/)<br/>
[Online Demo](http://www.jmelosegui.com/map/)<br/>

## License

Googlemap control for Asp.Net MVC is released under the [GNU GENERAL PUBLIC LICENSE](https://raw.githubusercontent.com/jmelosegui/GooglemapMvc/master/LICENSE) Version 2.

