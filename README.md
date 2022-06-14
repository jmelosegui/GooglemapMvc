[Googlemap control for Asp.Net MVC](http://www.jmelosegui.com/map/)
==============================
[![Build Status](https://dev.azure.com/elosegui/OSS/_apis/build/status/jmelosegui.GooglemapMvc?branchName=master)](https://dev.azure.com/elosegui/OSS/_build/latest?definitionId=7&branchName=master)
[![Join the chat at https://gitter.im/jmelosegui/GooglemapMvc](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/jmelosegui/GooglemapMvc?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)
[![NuGet](https://img.shields.io/nuget/v/Jmelosegui.Mvc.Googlemap.svg)](https://www.nuget.org/packages/Jmelosegui.Mvc.Googlemap/)
[![Donate](https://img.shields.io/badge/Donate-Paypal-ff69b4.svg)](https://www.paypal.me/jmelosegui)

Googlemap control for Asp.Net MVC wraps Google Maps APIs simplifying the use of Google Maps in ASP.NET Core Web Applications.

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
- Libraries
  - Places (Non mvc yet)
  - Drawing (Non mvc yet)

## Install

Inside Visual Studio create a new ASP.Net Core Web Application. Open the package manager console and install the Googlemap Mvc nuget package by typing the following command.

```powershell
PM> Install-Package Jmelosegui.Mvc.Googlemap
```

Once you have it go to the Pages->Index.cshtml and include the following
```html
<div class="row">
    <div class="col-md-12">
        @(Html.GoogleMap()
              .Name("map")
              .Height(500)
              .ApiKey("YourApiKeyHere")
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

## Contributing Prerequisites

#### Required

* [Build Tools for Visual Studio 2022](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio-2022) (automatically installed with Visual Studio 2015)

#### Better with

* [Visual Studio 2022](https://www.visualstudio.com/en-us)

## Self-service releases

As soon as a new change is pushed to this repo, a build is executed and an updated NuGet package
is published to this Package Feed:

    https://f.feedz.io/jmelosegui/oss/nuget/index.json

By adding this URL to your package sources you can immediately install the latest version
of the NuGet packages to your project without wating for your feature to be "officially" published to https://www.nuget.org/.
This can be done by adding a nuget.config file with the following content to the root of your project's repo:

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <packageSources>
        <clear />
        <add key="Jmelosegui.OSS" value="https://f.feedz.io/jmelosegui/oss/nuget/index.json" />
        <add key="NuGet.org" value="https://api.nuget.org/v3/index.json" />
    </packageSources>
</configuration>
```

You can then install the package while you have your new "Googlemap Mvc CI" package source selected:

```powershell
PM> Install-Package Jmelosegui.Mvc.Googlemap -Pre
```

## License

Googlemap control for Asp.Net MVC is released under the MIT (https://raw.githubusercontent.com/jmelosegui/GooglemapMvc/master/LICENSE.txt).

