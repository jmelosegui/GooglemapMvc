(function ($) { 
    "use strict";

    var $jmelosegui = $.jmelosegui = {

        create: function (query, settings) {
            var name = settings.name;
            var options = $.extend({}, $.fn[name].defaults, settings.options);

            return query.each(function () {
                var $$ = $(this);
                options = $.meta ? $.extend({}, options, $$.data()) : options;

                if (!$$.data(name)) {
                    var component = settings.init(this, options);

                    $$.data(name, component);

                    $jmelosegui.trigger(this, 'load');

                    if (settings.success) settings.success(component);
                }
            });
        },

        bind: function (context, events) {
            var $element = $(context.element ? context.element : context);
            $.each(events, function (eventName) {
                if ($.isFunction(this)) $element.bind(eventName, this);
            });
        },

        delegate: function (context, handler) {
            return function (e) {
                handler.apply(context, [e, this]);
            };
        },

        trigger: function (element, eventName, e) {
            e = $.extend(e || {}, new $.Event(eventName));
            e.stopPropagation();
            $(element).trigger(e);
            return e.isDefaultPrevented();
        },

    };

    // jQuery extender
    $.fn.GoogleMap = function (options) {
        return $jmelosegui.create(this, {
            name: 'GoogleMap',
            init: function (element, options) {
                return new $jmelosegui.map(element, options);
            },
            options: options,
            success: function (map) {
                map.load();
            }
        });

    };

    //Polygons
    $jmelosegui.GooglePolygon = function (map, config) {
        //init
        this.Map = map;
        this.GPolygon = null;
        //properties
        this.Clickable = config.Clickable;
        this.FillColor = config.FillColor;
        this.FillOpacity = config.FillOpacity;
        this.Points = config.Points;
        this.StrokeColor = config.StrokeColor;
        this.StrokeOpacity = config.StrokeOpacity;
        this.StrokeWeight = config.StrokeWeight;
        this.Points = [];

        if (config.Points) {
            for (var i = 0; i < config.Points.length; i++) {
                this.Points.push(new google.maps.LatLng(config.Points[i].Latitude, config.Points[i].Longitude));
            }
        }

    };

    $jmelosegui.GooglePolygon.prototype = {
        isLoaded: function () {
            return this.GPolygon !== null;
        },
        load: function () {
            var options = {
                paths: this.Points,
                strokeColor: this.StrokeColor,
                strokeOpacity: this.StrokeOpacity,
                strokeWeight: this.StrokeWeight,
                fillColor: this.FillColor,
                fillOpacity: this.FillOpacity
            };
            var polygon = new google.maps.Polygon(options);
            polygon.setMap(this.Map);
        }
    };

    // Circles
    $jmelosegui.GoogleCircle = function (map, config) {
        //init
        this.Map = map;
        this.GCircle = null;
        //properties
        this.Clickable = config.Clickable;
        this.FillColor = config.FillColor;
        this.FillOpacity = config.FillOpacity;
        this.Points = config.Points;
        this.StrokeColor = config.StrokeColor;
        this.StrokeOpacity = config.StrokeOpacity;
        this.StrokeWeight = config.StrokeWeight;
        this.Center = config.Center;
        this.Radius = config.Radius;
    };

    $jmelosegui.GoogleCircle.prototype = {
        isLoaded: function () {
            return this.GCircle !== null;
        },
        load: function () {
            var options = {
                center: new google.maps.LatLng(this.Center.Latitude, this.Center.Longitude),
                radius: this.Radius,
                strokeColor: this.StrokeColor,
                strokeOpacity: this.StrokeOpacity,
                strokeWeight: this.StrokeWeight,
                fillColor: this.FillColor,
                fillOpacity: this.FillOpacity
            };
            var circle = new google.maps.Circle(options);
            circle.setMap(this.Map);
        }
    };

    //Markers
    $jmelosegui.GoogleMarker = function (map, index, config) {
        // init
        this.GMarker = null;
        this.Map = map;
        this.Index = index;
        //properties
        this.Latitude = config.Latitude;
        this.Longitude = config.Longitude;
        this.Title = config.Title;
        this.Icon = config.Icon;
        this.Clickable = config.Clickable;
        this.Draggable = config.Draggable;
        this.Window = config.Window;
        this.CreateNewWindow = config.CreateNewWindow;
        this.EnableMarkersClustering = config.EnableMarkersClustering;
    };

    var infowindow;
    var markersCluster = [];
    $jmelosegui.GoogleMarker.prototype = {

        isLoaded: function () {
            return (this.GMarker !== null);
        },
        initialize: function () {
            if (this.Window) {
                google.maps.event.addListener(this.GMarker, 'click', $jmelosegui.delegate(this, this.openInfoWindow));
            }
        },
        createImage: function (options) {
            var image = new google.maps.MarkerImage(options.Path,
                new google.maps.Size(options.Size.Width, options.Size.Height),
                new google.maps.Point(options.Point.X, options.Point.Y),
                new google.maps.Point(options.Anchor.X, options.Anchor.Y));
            return image;
        },
        load: function (point) {
            this.Latitude = point.lat();
            this.Longitude = point.lng();
            var markerOptions = {
                position: new google.maps.LatLng(this.Latitude, this.Longitude),
                map: this.EnableMarkersClustering ? null : this.Map,
                title: this.Title,
                clickable: this.Clickable,
                draggable: this.Draggable,
                icon: this.Icon ? this.createImage(this.Icon) : null
            };
            // create
            this.GMarker = new google.maps.Marker(markerOptions);
            this.initialize();
            if (this.EnableMarkersClustering === true) {
                markersCluster.push(this.GMarker);
            }
        },
        openInfoWindow: function () {
            if (this.isLoaded()) {
                if (infowindow) {
                    infowindow.close();
                }
                var node = document.getElementById(this.Window.Content).cloneNode(true);
                infowindow = new google.maps.InfoWindow();
                infowindow.setContent(node.innerHTML);
                infowindow.open(this.Map, this.GMarker);
            }
        }
    };

    //Image Map Types
    $jmelosegui.ImageMapType = function(map, config) {

        this.map = map;
        this.name = config.name;
        this.alt = config.altName;
        this.maxZoom = config.maxZoom;
        this.minZoom = config.minZoom;
        this.radius = config.Radius;
        this.opacity = config.opacity;

        this.repeatHorizontally = config.repeatHorizontally;
        this.repeatVertically = config.repeatVertically;
        this.tileSize = new google.maps.Size(config.tileSize.Width, config.tileSize.Height);
        this.tileUrlPattern = config.tileUrlPattern;
    }

    $jmelosegui.ImageMapType.prototype = {
        getTileUrl: function(coord, zoom) {
            var normalizedCoord = this.getNormalizedCoord(coord, zoom);

            if (!normalizedCoord) {
                return null;
            }

            var imageUrl = this.format(this.tileUrlPattern, coord.x, coord.y, zoom, this.tileSize.width, this.tileSize.height);
            console.log(imageUrl);
            return imageUrl;

        },
        
        getNormalizedCoord: function getNormalizedCoord(coord, zoom) {
            var y = coord.y;
            var x = coord.x;
            var tileRange = 1 << zoom;

            if (y < 0 || y >= tileRange) {
                if (this.repeatVertically) {
                    y = (y % tileRange + tileRange) % tileRange;
                } else {
                    return null;
                }
            }

            if (x < 0 || x >= tileRange) {
                if (this.repeatHorizontally) {
                    x = (x % tileRange + tileRange) % tileRange;
                } else {
                    return null;
                }
            }

            return {
                x: x,
                y: y
            };
        },

        format: function(value) {
            var args = Array.prototype.slice.call(arguments, 1);
            return value.replace(/{(\d+)}/g, function (match, number) {
                return typeof args[number] != 'undefined'
                  ? args[number] 
                  : match
                ;
            });
        }
    }

    // Styled Map Types
    $jmelosegui.StyledMapType = function (map, config) {

        this.map = map;
        this.name = config.name;
        this.alt = config.altName;
        this.maxZoom = config.maxZoom;
        this.minZoom = config.minZoom;
        this.radius = config.Radius;
        this.opacity = config.opacity;

        this.styles = config.styles;

    }

    $jmelosegui.StyledMapType.prototype = {}

    $jmelosegui.map = function (element, options) {

        this.element = element;
        $.extend(this, options);

        this.ClientID = options.ClientID;
        this.Address = options.Address;
        this.DisableDoubleClickZoom = options.DisableDoubleClickZoom;
        this.EnableMarkersClustering = options.EnableMarkersClustering;
        this.MarkerClusteringOptions = options.MarkerClusteringOptions;
        this.Height = options.Height;
        this.Width = options.Width;
        this.Latitude = options.Latitude;
        this.Longitude = options.Longitude;
        this.Zoom = (options.Zoom !== undefined) ? options.Zoom : 6;
        this.MaxZoom = (options.MaxZoom !== undefined) ? options.MaxZoom : null;
        this.MinZoom = (options.MinZoom !== undefined) ? options.MinZoom : null;
        this.MapTypeId = options.MapTypeId;
        this.MapTypeControlPosition = (options.MapTypeControlPosition !== undefined) ? options.MapTypeControlPosition : 'TOP_RIGHT';
        this.MapTypeControlStyle = options.MapTypeControlStyle;
        this.MapTypeControlVisible = (options.MapTypeControlVisible !== undefined) ? options.MapTypeControlVisible : true;
        
        this.PanControlVisible = (options.PanControlVisible !== undefined) ? options.PanControlVisible : true;
        this.PanControlPosition = (options.PanControlPosition !== undefined) ? options.PanControlPosition : 'TOP_LEFT';

        this.ZoomControlVisible = (options.ZoomControlVisible !== undefined) ? options.ZoomControlVisible : true;
        this.ZoomControlPosition = (options.ZoomControlPosition !== undefined) ? options.ZoomControlPosition : 'TOP_LEFT';
        this.ZoomControlStyle = options.ZoomControlStyle;

        this.StreetViewControlVisible = (options.StreetViewControlVisible !== undefined) ? options.StreetViewControlVisible : true;
        this.StreetViewControlPosition = (options.StreetViewControlPosition !== undefined) ? options.StreetViewControlPosition : 'TOP_LEFT';

        this.OverviewMapControlVisible = (options.OverviewMapControlVisible !== undefined) ? options.OverviewMapControlVisible : true;
        this.OverviewMapControlOpened = (options.OverviewMapControlOpened !== undefined) ? options.OverviewMapControlOpened : false;


        this.NavigationControlPosition = (options.NavigationControlPosition !== undefined) ? options.NavigationControlPosition : 'TOP_LEFT';
        this.NavigationControlType = options.NavigationControlType;
        this.NavigationControlVisible = (options.NavigationControlVisible !== undefined) ? options.NavigationControlVisible : true;

        this.ScaleControlVisible = (options.ScaleControlVisible !== undefined) ? options.ScaleControlVisible : false;
        this.GMap = null;

        this.Markers = eval(options.Markers);
        this.Circles = eval(options.Circles);
        this.Polygons = eval(options.Polygons);
        this.ImageMapTypes = eval(options.ImageMapTypes);
        this.StyledMapTypes = eval(options.StyledMapTypes);

        this.Events = [];

        if (options.bounds_changed !== undefined) {
            this.Events.push({ 'bounds_changed': options.bounds_changed });
        }
        if (options.center_changed !== undefined) {
            this.Events.push({ 'center_changed': options.center_changed });
        }
        if (options.click !== undefined) {
            this.Events.push({ 'click': options.click });
        }
        if (options.dblclick !== undefined) {
            this.Events.push({ 'dblclick': options.dblclick });
        }
        if (options.rightclick !== undefined) {
            this.Events.push({ 'rightclick': options.rightclick });
        }
        if (options.drag !== undefined) {
            this.Events.push({ 'drag': options.drag });
        }
        if (options.dragend !== undefined) {
            this.Events.push({ 'dragend': options.dragend });
        }
        if (options.dragstart !== undefined) {
            this.Events.push({ 'dragstart': options.dragstart });
        }
        if (options.heading_changed !== undefined) {
            this.Events.push({ 'heading_changed': options.heading_changed });
        }
        if (options.idle !== undefined) {
            this.Events.push({ 'idle': options.idle });
        }
        if (options.maptypeid_changed !== undefined) {
            this.Events.push({ 'maptypeid_changed': options.maptypeid_changed });
        }
        if (options.projection_changed !== undefined) {
            this.Events.push({ 'projection_changed': options.projection_changed });
        }
        if (options.resize !== undefined) {
            this.Events.push({ 'resize': options.resize });
        }
        if (options.mousemove !== undefined) {
            this.Events.push({ 'mousemove': options.mousemove });
        }
        if (options.mouseout !== undefined) {
            this.Events.push({ 'mouseout': options.mouseout });
        }
        if (options.mouseover !== undefined) {
            this.Events.push({ 'mouseover': options.mouseover });
        }
        if (options.tilesloaded !== undefined) {
            this.Events.push({ 'tilesloaded': options.tilesloaded });
        }
        if (options.tilt_changed !== undefined) {
            this.Events.push({ 'tilt_changed': options.tilt_changed });
        }
        if (options.zoom_changed !== undefined) {
            this.Events.push({ 'zoom_changed': options.zoom_changed });
        }

        $jmelosegui.bind(this, {
            load: this.onLoad
        });
    };

    $jmelosegui.map.prototype = {
        initialize: function () {

            var innerOptions = {
                zoom: this.Zoom,
                minZoom: this.MinZoom,
                maxZoom: this.MaxZoom,
                center: new google.maps.LatLng(this.Latitude, this.Longitude),
                disableDoubleClickZoom: this.DisableDoubleClickZoom,
                draggable: this.Draggable,
                mapTypeId: this.getMapTypeId(),
                mapTypeControl: this.MapTypeControlVisible,
                mapTypeControlOptions: {
                    style: this.getMapTypeControlStyle(),
                    position: this.getControlPosition(this.MapTypeControlPosition),
                },
                panControl: this.PanControlVisible,
                panControlOptions: {
                    position: this.getControlPosition(this.PanControlPosition)
                },
                zoomControl: this.ZoomControlVisible,
                zoomControlOptions: {
                    position: this.getControlPosition(this.ZoomControlPosition),
                    style: this.getZoomControlStyle()
                },
                overviewMapControl: this.OverviewMapControlVisible,
                overviewMapControlOptions: {
                    opened: this.OverviewMapControlOpened
                },
                streetViewControl: this.StreetViewControlVisible,
                streetViewControlOptions: {
                    position: this.getControlPosition(this.StreetViewControlPosition)
                },
                scaleControl: this.ScaleControlVisible
            };
            var i;
            if (this.ImageMapTypes) {
                innerOptions.mapTypeControlOptions.mapTypeIds = [];
                for (i = 0; i < this.ImageMapTypes.length; i++) {
                    innerOptions.mapTypeControlOptions.mapTypeIds.push(this.ImageMapTypes[i].name);
                }
            }

            if (this.StyledMapTypes) {
                if (innerOptions.mapTypeControlOptions.mapTypeIds === undefined) {
                    innerOptions.mapTypeControlOptions.mapTypeIds = [];
                }
                for (i = 0; i < this.StyledMapTypes.length; i++) {
                    innerOptions.mapTypeControlOptions.mapTypeIds.push(this.StyledMapTypes[i].name);
                }
            }

            this.GMap = new google.maps.Map(this.getElement(), innerOptions);
        },
        getZoomControlStyle: function () {
            switch (this.ZoomControlStyle) {
                case 'LARGE':
                    return google.maps.ZoomControlStyle.LARGE;
                case 'SMALL':
                    return google.maps.ZoomControlStyle.SMALL;
                default:
                    return google.maps.ZoomControlStyle.DEFAULT;
            }
        },
        getMapTypeControlStyle: function () {
            switch (this.MapTypeControlStyle) {
                case 'DROPDOWN_MENU':
                    return google.maps.MapTypeControlStyle.DROPDOWN_MENU;
                case 'HORIZONTAL_BAR':
                    return google.maps.MapTypeControlStyle.HORIZONTAL_BAR;
                default:
                    return google.maps.MapTypeControlStyle.DEFAULT;
            }
        },
        getMapTypeId: function () {
            switch (this.MapTypeId) {
                case 'HYBRID':
                    return google.maps.MapTypeId.HYBRID;
                case 'SATELLITE':
                    return google.maps.MapTypeId.SATELLITE;
                case 'TERRAIN':
                    return google.maps.MapTypeId.TERRAIN;
                case 'ROADMAP':
                    return google.maps.MapTypeId.ROADMAP;
                default:
                    return this.MapTypeId;
            }
        },
        getElement: function () {
            return document.getElementById(this.ClientID);
        },
        getControlPosition: function (position) {
            switch (position) {
                case 'TOP_CENTER':
                    return google.maps.ControlPosition.TOP_CENTER;
                case 'TOP_LEFT':
                    return google.maps.ControlPosition.TOP_LEFT;
                case 'LEFT_TOP':
                    return google.maps.ControlPosition.LEFT_TOP;
                case 'BOTTOM_CENTER':
                    return google.maps.ControlPosition.BOTTOM_CENTER;
                case 'BOTTOM_LEFT':
                    return google.maps.ControlPosition.BOTTOM_LEFT;
                case 'BOTTOM_RIGHT':
                    return google.maps.ControlPosition.BOTTOM_RIGHT;
                case 'LEFT_BOTTOM':
                    return google.maps.ControlPosition.LEFT_BOTTOM;
                case 'RIGHT_BOTTOM':
                    return google.maps.ControlPosition.RIGHT_BOTTOM;
                case 'LEFT_CENTER':
                    return google.maps.ControlPosition.LEFT_CENTER;
                case 'RIGHT_CENTER':
                    return google.maps.ControlPosition.RIGHT_CENTER;
                case 'TOP_RIGHT':
                    return google.maps.ControlPosition.TOP_RIGHT;
                case 'RIGHT_TOP':
                    return google.maps.ControlPosition.RIGHT_TOP;
            }
        },
        refreshMap: function () {
            var options = {
                maxZoom: this.MarkerClusteringOptions.MaxZoom,
                gridSize: this.MarkerClusteringOptions.GridSize,
                averageCenter: this.MarkerClusteringOptions.AverageCenter,
                zoomOnClick: this.MarkerClusteringOptions.ZoomOnClick,
                hideSingleGroupMarker: this.MarkerClusteringOptions.HideSingleGroupMarker,
                styles: this.MarkerClusteringOptions.CustomStyles
            };
            new MarkerClusterer(this.GMap, markersCluster, options);
        },
        renderCircle: function (c) {
            c.load();
        },
        renderMarker: function (m) {

            if ((m.Latitude != 0) && (m.Longitude != 0)) {

                try {
                    m.load(new google.maps.LatLng(m.Latitude, m.Longitude), false);
                }
                catch (ex) { }
            }
        },
        renderPolygon: function (p) {
            p.load();
        },
        load: function (point) {
            if (point) {
                this.initialize();
                this.render();
                this.attachMapEvents();
            }
            else {
                if ((this.Latitude !== undefined) && (this.Longitude !== undefined))
                    this.load(new google.maps.LatLng(this.Latitude, this.Longitude));
            }
        },
        attachMapEvents: function () {
            for (var i = 0; i < this.Events.length; i++) {
                var eventName = Object.getOwnPropertyNames(this.Events[i])[0];
                this.mapEventsCallBack(this.GMap, this.Events[i][eventName], eventName);
            }
        },
        mapEventsCallBack: function (map, handler, eventName) {
            google.maps.event.addListener(map, eventName, function (e) {
                var args = { 'map': map, 'eventName': eventName };
                $.extend(args, e);
                handler(args);
            });
        },
        render: function () {
            // markers
            var i;
            if (this.Markers) {
                for (i = 0; i < this.Markers.length; i++) {
                    var config = this.Markers[i];
                    config.EnableMarkersClustering = this.EnableMarkersClustering;
                    var marker = new $jmelosegui.GoogleMarker(this.GMap, i, config);
                    this.renderMarker(marker);
                };
                if (this.EnableMarkersClustering === true) {
                    this.refreshMap();
                }
            }
            // polygons
            if (this.Polygons) {
                for (i = 0; i < this.Polygons.length; i++) {
                    var polygon = new $jmelosegui.GooglePolygon(this.GMap, this.Polygons[i]);
                    this.renderPolygon(polygon);
                }
            }
            // circles
            if (this.Circles) {
                for (i = 0; i < this.Circles.length; i++) {
                    var circle = new $jmelosegui.GoogleCircle(this.GMap, this.Circles[i]);
                    this.renderPolygon(circle);
                }
            }
            // mapTypes
            var mapType;
            if (this.ImageMapTypes) {
                for (i = 0; i < this.ImageMapTypes.length; i++) {
                    mapType = new $jmelosegui.ImageMapType(this.GMap, this.ImageMapTypes[i]);
                    this.addImageMapType(this.GMap, mapType);
                }
            }

            if (this.StyledMapTypes) {
                for (i = 0; i < this.StyledMapTypes.length; i++) {
                    mapType = new $jmelosegui.StyledMapType(this.GMap, this.StyledMapTypes[i]);
                    this.addStyledMapType(this.GMap, mapType);
                }
            }
            this.GMap.setMapTypeId(this.getMapTypeId());
        },
        // Items --------------------------------------------------------------------------------------
        // Marker
        addMarker: function (config, render) {
            if (!this.Markers) this.Markers = new Array();
            var marker = new $jmelosegui.GoogleMarker(this, this.Markers.length, config);
            this.Markers.push(marker);
            if (render) this.renderMarker(marker);
        },
        // Image MapTypes
        addImageMapType: function (map, mapType) {
            var gImageMapType = new google.maps.ImageMapType(mapType);
            map.mapTypes.set(mapType.name, gImageMapType);
        },
        // Styled MapTypes
        addStyledMapType: function (map, mapType) {
            var gStyledMapType = new google.maps.StyledMapType(mapType.styles, mapType);
            map.mapTypes.set(mapType.name, gStyledMapType);
    }
    };

})(jQuery);