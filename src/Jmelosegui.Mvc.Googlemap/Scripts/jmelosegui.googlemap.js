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

                    if (settings.success && !$.isEmptyObject(options)) settings.success(component);
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
                return new $jmelosegui.GoogleMap(element, options);
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
        this.gPolygon = null;
        //properties
        this.clickable = config.clickable;
        this.fillColor = config.fillColor;
        this.fillOpacity = config.fillOpacity;
        this.points = config.points;
        this.strokeColor = config.strokeColor;
        this.strokeOpacity = config.strokeOpacity;
        this.strokeWeight = config.strokeWeight;
        this.points = [];

        if (config.points) {
            for (var i = 0; i < config.points.length; i++) {
                this.points.push(new google.maps.LatLng(config.points[i].lat, config.points[i].lng));
            }
        }

    };

    $jmelosegui.GooglePolygon.prototype = {
        isLoaded: function () {
            return this.gPolygon !== null;
        },
        load: function () {
            var options = {
                paths: this.points,
                strokeColor: this.strokeColor,
                strokeOpacity: this.strokeOpacity,
                strokeWeight: this.strokeWeight,
                fillColor: this.fillColor,
                fillOpacity: this.fillOpacity,
                clickable: this.clickable
            };
            var polygon = new google.maps.Polygon(options);
            polygon.setMap(this.Map);
        }
    };

    // Circles
    $jmelosegui.GoogleCircle = function (map, config) {
        //init
        this.Map = map;
        this.gCircle = null;
        //properties
        this.clickable = config.clickable;
        this.fillColor = config.fillColor;
        this.fillOpacity = config.fillOpacity;
        this.points = config.points;
        this.strokeColor = config.strokeColor;
        this.strokeOpacity = config.strokeOpacity;
        this.strokeWeight = config.strokeWeight;
        this.center = config.center;
        this.radius = config.radius;
    };

    $jmelosegui.GoogleCircle.prototype = {
        isLoaded: function () {
            return this.GCircle !== null;
        },
        load: function () {
            var options = {
                center: new google.maps.LatLng(this.center.lat, this.center.lng),
                radius: this.radius,
                strokeColor: this.strokeColor,
                strokeOpacity: this.strokeOpacity,
                strokeWeight: this.strokeWeight,
                fillColor: this.fillColor,
                fillOpacity: this.fillOpacity,
                clickable: this.clickable
            };
            var circle = new google.maps.Circle(options);
            circle.setMap(this.Map);
        }
    };

    //Markers
    $jmelosegui.GoogleMarker = function (map, index, config) {
        // init
        this.gMarker = null;
        this.Map = map.GMap;
        this.parent = map;
        this.index = index;
        //properties
        this.id = config.id;
        this.latitude = config.lat;
        this.longitude = config.lng;
        this.address = config.address;
        this.title = config.title;
        this.icon = config.icon;
        this.clickable = (config.clickable !== undefined) ? config.clickable : true;
        this.draggable = config.draggable;
        this.window = config.window;
        this.zIndex = config.zIndex ? config.zIndex : 0;
        this.enableMarkersClustering = config.enableMarkersClustering ? config.enableMarkersClustering : false;
        this.markerEvents = config.markerEvents;
    };

    var infowindow;
    var markersCluster = {};
    $jmelosegui.GoogleMarker.prototype = {

        isLoaded: function () {
            return (this.gMarker !== null);
        },
        initialize: function () {
            //Work around to the issue https://code.google.com/p/gmaps-api-issues/issues/detail?id=7925
            if (this.window && this.clickable) {
                var openWindowEvent = 'click';
                if (this.window.openOnRightClick) {
                    openWindowEvent = 'rightclick';
                }
                google.maps.event.addListener(this.gMarker, openWindowEvent, $jmelosegui.delegate(this, this.openInfoWindow));
            }

            if (this.markerEvents) {
                this.attachMarkerEvents();
            }
        },
        attachMarkerEvents: function () {
            for (var i = 0; i < this.markerEvents.length; i++) {
                var eventName = Object.getOwnPropertyNames(this.markerEvents[i])[0];
                //Work around to the issue https://code.google.com/p/gmaps-api-issues/issues/detail?id=7925
                if (eventName === 'click' && !this.clickable) continue;
                this.markerEventsCallBack(this.id, this.gMarker, this.markerEvents[i][eventName], eventName);
            }
        },
        markerEventsCallBack: function (id, marker, handler, eventName) {
            google.maps.event.addListener(marker, eventName, function (e) {
                var args = { 'id': id, 'marker': marker, 'eventName': eventName };
                $.extend(args, e);
                handler(args);
            });
        },
        createImage: function (options) {
            var image = new google.maps.MarkerImage(options.path,
                new google.maps.Size(options.size.width, options.size.height),
                new google.maps.Point(options.point.x, options.point.y),
                new google.maps.Point(options.anchor.x, options.anchor.y));
            return image;
        },
        load: function (point) {
            this.latitude = point.lat();
            this.longitude = point.lng();
            var markerOptions = {
                position: new google.maps.LatLng(this.latitude, this.longitude),
                map: this.enableMarkersClustering ? null : this.Map,
                title: this.title,
                clickable: this.clickable,
                draggable: this.draggable,
                icon: this.icon ? this.createImage(this.icon) : null,
                zIndex: this.zIndex
            };
            // create
            this.gMarker = new google.maps.Marker(markerOptions);
            $.extend(this.gMarker, { address: this.address });
            if (this.parent.fitToMarkersBounds) {
                this.parent.bounds.extend(this.gMarker.position);
            }
            this.initialize();

            markersCluster[this.id] = this.gMarker;

        },
        openInfoWindow: function () {
            if (this.isLoaded()) {
                if (infowindow) {
                    infowindow.close();
                }
                var node = document.getElementById(this.window.content).cloneNode(true);
                infowindow = new google.maps.InfoWindow(this.window);
                infowindow.setContent(node.innerHTML);
                var windowsLoc;
                if (this.window.lat && this.window.lng) {
                    windowsLoc = new google.maps.LatLng(this.window.lat, this.window.lng);
                } else {
                    windowsLoc = this.gMarker.getPosition();
                }
                infowindow.setPosition(windowsLoc);
                infowindow.open(this.Map, this.gMarker);
            }
        }
    };

    //Image Map Types
    $jmelosegui.ImageMapType = function (map, config) {

        this.map = map;
        this.name = config.name;
        this.alt = config.altName;
        this.maxZoom = config.maxZoom;
        this.minZoom = config.minZoom;
        this.radius = config.radius;
        this.opacity = config.opacity;

        this.repeatHorizontally = config.repeatHorizontally;
        this.repeatVertically = config.repeatVertically;
        this.tileSize = new google.maps.Size(config.tileSize.width, config.tileSize.height);
        this.tileUrlPattern = config.tileUrlPattern;
    }

    $jmelosegui.ImageMapType.prototype = {
        getTileUrl: function (coord, zoom) {
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

        format: function (value) {
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
        this.radius = config.radius;
        this.opacity = config.opacity;

        this.styles = config.styles;
    }

    $jmelosegui.StyledMapType.prototype = {}

    // Layers
    // HeatMapLayer
    $jmelosegui.HeatMapLayer = function (map, config) {

        this.map = map;
        this.dissipating = (config.dissipating !== undefined) ? config.clickable : true;
        this.maxIntensity = config.maxIntensity;
        this.opacity = config.opacity;
        this.radius = config.radius;
        this.gradient = config.gradient;
        this.data = config.data;
    }

    $jmelosegui.HeatMapLayer.prototype = {}

    // KmlLayer
    $jmelosegui.KmlLayer = function (map, config) {

        this.map = map;
        this.clickable = config.clickable;
        this.preserveViewport = config.preserveViewport;
        this.screenOverlays = config.screenOverlays;
        this.suppressInfoWindows = config.suppressInfoWindows;
        this.zIndex = config.zIndex;
        this.url = config.url;
    }

    $jmelosegui.KmlLayer.prototype = {}

    $jmelosegui.GoogleMap = function (element, options) {

        this.element = element;

        if ($.isEmptyObject(options)) {
            return;
        }

        $.extend(this, options);

        this.clientId = options.clientId;
        this.disableDoubleClickZoom = options.disableDoubleClickZoom;
        this.enableMarkersClustering = options.enableMarkersClustering;
        this.markersFromAddress = options.markersFromAddress;
        this.fitToMarkersBounds = options.fitToMarkersBounds;
        this.markerClusteringOptions = options.markerClusteringOptions;
        this.height = options.height;
        this.width = options.width;
        this.latitude = options.center.latitude;
        this.longitude = options.center.longitude;
        this.useCurrentPosition = options.center.useCurrentPosition;
        this.address = options.center.address;
        this.zoom = (options.zoom !== undefined) ? options.zoom : 6;
        this.maxZoom = (options.maxZoom !== undefined) ? options.maxZoom : null;
        this.minZoom = (options.minZoom !== undefined) ? options.minZoom : null;
        this.mapTypeId = options.mapTypeId;
        this.mapTypeControlPosition = (options.mapTypeControlPosition !== undefined) ? options.mapTypeControlPosition : 'TOP_RIGHT';
        this.mapTypeControlStyle = options.mapTypeControlStyle;
        this.mapTypeControlVisible = (options.mapTypeControlVisible !== undefined) ? options.mapTypeControlVisible : true;

        this.panControlVisible = (options.panControlVisible !== undefined) ? options.panControlVisible : true;
        this.panControlPosition = (options.panControlPosition !== undefined) ? options.panControlPosition : 'TOP_LEFT';

        this.zoomControlVisible = (options.zoomControlVisible !== undefined) ? options.zoomControlVisible : true;
        this.zoomControlPosition = (options.zoomControlPosition !== undefined) ? options.zoomControlPosition : 'TOP_LEFT';
        this.zoomControlStyle = options.zoomControlStyle;

        this.streetViewControlVisible = (options.streetViewControlVisible !== undefined) ? options.streetViewControlVisible : true;
        this.streetViewControlPosition = (options.streetViewControlPosition !== undefined) ? options.streetViewControlPosition : 'TOP_LEFT';

        this.overviewMapControlVisible = (options.overviewMapControlVisible !== undefined) ? options.overviewMapControlVisible : false;
        this.overviewMapControlOpened = (options.overviewMapControlOpened !== undefined) ? options.overviewMapControlOpened : false;


        this.navigationControlPosition = (options.navigationControlPosition !== undefined) ? options.navigationControlPosition : 'TOP_LEFT';
        this.navigationControlType = options.navigationControlType;
        this.navigationControlVisible = (options.navigationControlVisible !== undefined) ? options.navigationControlVisible : true;

        this.scaleControlVisible = (options.scaleControlVisible !== undefined) ? options.scaleControlVisible : false;
        this.GMap = null;

        this.markers = eval(options.markers);
        this.circles = eval(options.circles);
        this.polygons = eval(options.polygons);
        this.imageMapTypes = eval(options.imageMapTypes);
        this.styledMapTypes = eval(options.styledMapTypes);
        this.layers = eval(options.layers);

        this.bounds = new google.maps.LatLngBounds();

        //Map Events
        this.events = [];

        if (options.bounds_changed !== undefined) {
            this.events.push({ 'bounds_changed': options.bounds_changed });
        }
        if (options.center_changed !== undefined) {
            this.events.push({ 'center_changed': options.center_changed });
        }
        if (options.click !== undefined) {
            this.events.push({ 'click': options.click });
        }
        if (options.dblclick !== undefined) {
            this.events.push({ 'dblclick': options.dblclick });
        }
        if (options.rightclick !== undefined) {
            this.events.push({ 'rightclick': options.rightclick });
        }
        if (options.drag !== undefined) {
            this.events.push({ 'drag': options.drag });
        }
        if (options.dragend !== undefined) {
            this.events.push({ 'dragend': options.dragend });
        }
        if (options.dragstart !== undefined) {
            this.events.push({ 'dragstart': options.dragstart });
        }
        if (options.heading_changed !== undefined) {
            this.events.push({ 'heading_changed': options.heading_changed });
        }
        if (options.idle !== undefined) {
            this.events.push({ 'idle': options.idle });
        }
        if (options.maptypeid_changed !== undefined) {
            this.events.push({ 'maptypeid_changed': options.maptypeid_changed });
        }
        if (options.projection_changed !== undefined) {
            this.events.push({ 'projection_changed': options.projection_changed });
        }
        if (options.resize !== undefined) {
            this.events.push({ 'resize': options.resize });
        }
        if (options.mousemove !== undefined) {
            this.events.push({ 'mousemove': options.mousemove });
        }
        if (options.mouseout !== undefined) {
            this.events.push({ 'mouseout': options.mouseout });
        }
        if (options.mouseover !== undefined) {
            this.events.push({ 'mouseover': options.mouseover });
        }
        if (options.tilesloaded !== undefined) {
            this.events.push({ 'tilesloaded': options.tilesloaded });
        }
        if (options.tilt_changed !== undefined) {
            this.events.push({ 'tilt_changed': options.tilt_changed });
        }
        if (options.zoom_changed !== undefined) {
            this.events.push({ 'zoom_changed': options.zoom_changed });
        }
        if (options.map_loaded !== undefined) {
            this.map_loaded = options.map_loaded;
        }
        if (options.markers_geocoding_completed !== undefined) {
            this.markers_geocoding_completed = options.markers_geocoding_completed;
        }
        if (options.markers_geocoding_progress !== undefined) {
            this.markers_geocoding_progress = options.markers_geocoding_progress;
        }

        //Marker Events
        this.markerEvents = [];

        if (options.markerEvents) {
            if (options.markerEvents.animation_changed !== undefined) {
                this.markerEvents.push({ 'animation_changed': options.markerEvents.animation_changed });
            }

            if (options.markerEvents.click !== undefined) {
                this.markerEvents.push({ 'click': options.markerEvents.click });
            }

            if (options.markerEvents.clickable_changed !== undefined) {
                this.markerEvents.push({ 'clickable_changed': options.markerEvents.clickable_changed });
            }

            if (options.markerEvents.cursor_changed !== undefined) {
                this.markerEvents.push({ 'cursor_changed': options.markerEvents.cursor_changed });
            }

            if (options.markerEvents.dragstart !== undefined) {
                this.markerEvents.push({ 'dragstart': options.markerEvents.dragstart });
            }

            if (options.markerEvents.drag !== undefined) {
                this.markerEvents.push({ 'drag': options.markerEvents.drag });
            }

            if (options.markerEvents.dragend !== undefined) {
                this.markerEvents.push({ 'dragend': options.markerEvents.dragend });
            }

            if (options.markerEvents.flat_changed !== undefined) {
                this.markerEvents.push({ 'flat_changed': options.markerEvents.flat_changed });
            }

            if (options.markerEvents.icon_changed !== undefined) {
                this.markerEvents.push({ 'icon_changed': options.markerEvents.icon_changed });
            }

            if (options.markerEvents.mousedown !== undefined) {
                this.markerEvents.push({ 'mousedown': options.markerEvents.mousedown });
            }

            if (options.markerEvents.mouseout !== undefined) {
                this.markerEvents.push({ 'mouseout': options.markerEvents.mouseout });
            }

            if (options.markerEvents.mouseover !== undefined) {
                this.markerEvents.push({ 'mouseover': options.markerEvents.mouseover });
            }

            if (options.markerEvents.mouseup !== undefined) {
                this.markerEvents.push({ 'mouseup': options.markerEvents.mouseup });
            }

            if (options.markerEvents.position_changed !== undefined) {
                this.markerEvents.push({ 'position_changed': options.markerEvents.position_changed });
            }

            if (options.markerEvents.rightclick !== undefined) {
                this.markerEvents.push({ 'rightclick': options.markerEvents.rightclick });
            }

            if (options.markerEvents.shape_changed !== undefined) {
                this.markerEvents.push({ 'shape_changed': options.markerEvents.shape_changed });
            }

            if (options.markerEvents.title_changed !== undefined) {
                this.markerEvents.push({ 'title_changed': options.markerEvents.title_changed });
            }

            if (options.markerEvents.visible_changed !== undefined) {
                this.markerEvents.push({ 'visible_changed': options.markerEvents.visible_changed });
            }

            if (options.markerEvents.zindex_changed !== undefined) {
                this.markerEvents.push({ 'zindex_changed': options.markerEvents.zindex_changed });
            }
        }

        $jmelosegui.bind(this, {
            load: this.onLoad
        });
    };
    var delay = 100;
    var markerIndex = 0;
    var loadGoogleMapScript = true;
    $jmelosegui.GoogleMap.prototype = {
        ajax: function (options) {
            var self = this;
            $.ajax({
                url: options.url,
                type: options.type,
                datatype: "html",
                data: $.extend(options.data, { __LoadGoogleMapScript__: loadGoogleMapScript }),
                success: function (data) {
                    $(self.element).html(data);
                    loadGoogleMapScript = false;
                    options.success(data);
                }
            });
        },
        initialize: function () {

            var innerOptions = {
                zoom: this.zoom,
                minZoom: this.minZoom,
                maxZoom: this.maxZoom,
                center: new google.maps.LatLng(this.latitude, this.longitude),
                disableDoubleClickZoom: this.disableDoubleClickZoom,
                draggable: this.draggable,
                mapTypeId: this.getMapTypeId(),
                mapTypeControl: this.mapTypeControlVisible,
                mapTypeControlOptions: {
                    style: this.getMapTypeControlStyle(),
                    position: this.getControlPosition(this.mapTypeControlPosition),
                },
                panControl: this.panControlVisible,
                panControlOptions: {
                    position: this.getControlPosition(this.panControlPosition)
                },
                zoomControl: this.zoomControlVisible,
                zoomControlOptions: {
                    position: this.getControlPosition(this.zoomControlPosition),
                    style: this.getZoomControlStyle()
                },
                overviewMapControl: this.overviewMapControlVisible,
                overviewMapControlOptions: {
                    opened: this.overviewMapControlOpened
                },
                streetViewControl: this.streetViewControlVisible,
                streetViewControlOptions: {
                    position: this.getControlPosition(this.streetViewControlPosition)
                },
                scaleControl: this.scaleControlVisible
            };
            var i;
            if (this.imageMapTypes) {
                innerOptions.mapTypeControlOptions.mapTypeIds = [];
                for (i = 0; i < this.imageMapTypes.length; i++) {
                    innerOptions.mapTypeControlOptions.mapTypeIds.push(this.imageMapTypes[i].name);
                }
            }

            if (this.styledMapTypes) {
                if (innerOptions.mapTypeControlOptions.mapTypeIds === undefined) {
                    innerOptions.mapTypeControlOptions.mapTypeIds = [];
                }
                for (i = 0; i < this.styledMapTypes.length; i++) {
                    innerOptions.mapTypeControlOptions.mapTypeIds.push(this.styledMapTypes[i].name);
                }
            }

            this.GMap = new google.maps.Map(this.getElement(), innerOptions);
        },
        getZoomControlStyle: function () {
            switch (this.zoomControlStyle) {
                case 'LARGE':
                    return google.maps.ZoomControlStyle.LARGE;
                case 'SMALL':
                    return google.maps.ZoomControlStyle.SMALL;
                default:
                    return google.maps.ZoomControlStyle.DEFAULT;
            }
        },
        getMapTypeControlStyle: function () {
            switch (this.mapTypeControlStyle) {
                case 'DROPDOWN_MENU':
                    return google.maps.MapTypeControlStyle.DROPDOWN_MENU;
                case 'HORIZONTAL_BAR':
                    return google.maps.MapTypeControlStyle.HORIZONTAL_BAR;
                default:
                    return google.maps.MapTypeControlStyle.DEFAULT;
            }
        },
        getMapTypeId: function () {
            switch (this.mapTypeId) {
                case 'HYBRID':
                    return google.maps.MapTypeId.HYBRID;
                case 'SATELLITE':
                    return google.maps.MapTypeId.SATELLITE;
                case 'TERRAIN':
                    return google.maps.MapTypeId.TERRAIN;
                case 'ROADMAP':
                    return google.maps.MapTypeId.ROADMAP;
                default:
                    return this.mapTypeId;
            }
        },
        getElement: function () {
            return document.getElementById(this.clientId);
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
        getAddress: function (config, next) {
            var geo = new google.maps.Geocoder();
            var map = this;
            geo.geocode({ address: config.address }, function (results, status) {
                var percentageProgress = Math.round(markerIndex / map.markers.length * 100);
                if (status === google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                    markerIndex--;
                    delay = delay + 10;
                } else {

                    if (status === google.maps.GeocoderStatus.OK) {
                        var p = results[0].geometry.location;
                        config.lat = p.lat();
                        config.lng = p.lng();
                        var marker = new $jmelosegui.GoogleMarker(map, markerIndex, config);
                        map.renderMarker(marker);

                    } else {
                        console.log('Error: Geocode was not successful for the following reason: ' + status);
                    }

                    if (map.markers_geocoding_progress !== undefined) {
                        var progressArgs = { 'map': map.GMap, value: percentageProgress, address: config.address, status: status };
                        map.markers_geocoding_progress(progressArgs);
                    }
                }
                next(map);
            });
        },
        refreshMap: function () {
            var options = {
                maxZoom: this.markerClusteringOptions.maxZoom,
                gridSize: this.markerClusteringOptions.gridSize,
                averageCenter: this.markerClusteringOptions.averageCenter,
                zoomOnClick: this.markerClusteringOptions.zoomOnClick,
                hideSingleGroupMarker: this.markerClusteringOptions.hideSingleGroupMarker,
                styles: this.markerClusteringOptions.customStyles
            };
            var markerArray = $.map(markersCluster, function (v) { return v; });
            new MarkerClusterer(this.GMap, markerArray, options);
        },
        renderCircle: function (c) {
            c.load();
        },
        renderMarker: function (m) {
            var markerCenter;
            if ((m.latitude) && (m.longitude)) {
                markerCenter = new google.maps.LatLng(m.latitude, m.longitude);
            }
            try {
                m.load(markerCenter, false);
            }
            catch (ex) { }
        },
        renderMarkers: function (map) {
            if (markerIndex < map.markers.length) {
                var config = map.markers[markerIndex];
                config.markerEvents = map.markerEvents;
                setTimeout(function () {
                    map.getAddress(config, map.renderMarkers);
                }, delay);
                markerIndex++;
            }
            else {
                if (map.fitToMarkersBounds) {
                    map.GMap.fitBounds(map.bounds);
                }
                if (map.markers_geocoding_completed !== undefined) {
                    var args = { 'map': map.GMap, 'markers': markersCluster };
                    map.markers_geocoding_completed(args);
                }
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
                if (this.map_loaded !== undefined) {
                    var args = { 'map': this.GMap, 'markers': markersCluster };
                    this.map_loaded(args);
                }
            }
            else {
                var self = this;

                if (this.useCurrentPosition && navigator.geolocation) {

                    navigator.geolocation.getCurrentPosition(function (position) {

                        self.latitude = position.coords.latitude;
                        self.longitude = position.coords.longitude;
                        self.load(new google.maps.LatLng(self.latitude, self.longitude));

                    }, function () {
                        console.log("Error: The Geolocation service failed.");
                        self.load(new google.maps.LatLng(this.latitude, this.longitude));
                    });
                } else if (this.address) {

                    var geocoder = new google.maps.Geocoder();

                    geocoder.geocode({ 'address': this.address }, function (results, status) {
                        if (status == google.maps.GeocoderStatus.OK) {
                            self.latitude = results[0].geometry.location.lat();
                            self.longitude = results[0].geometry.location.lng();
                            self.load(new google.maps.LatLng(self.latitude, self.longitude));
                        } else {
                            console.log('Error: Geocode was not successful for the following reason: ' + status);
                        }
                    });

                } else {
                    this.load(new google.maps.LatLng(this.latitude, this.longitude));
                }
            }
        },
        attachMapEvents: function () {
            for (var i = 0; i < this.events.length; i++) {
                var eventName = Object.getOwnPropertyNames(this.events[i])[0];
                this.mapEventsCallBack(this.GMap, this.events[i][eventName], eventName);
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
            if (this.markers) {
                if (this.markersFromAddress) {
                    this.renderMarkers(this);
                } else {
                    for (i = 0; i < this.markers.length; i++) {
                        var config = this.markers[i];

                        if (!config.lat) {
                            config.lat = this.GMap.center.lat();
                        }

                        if (!config.lng) {
                            config.lng = this.GMap.center.lng();
                        }

                        config.enableMarkersClustering = this.enableMarkersClustering;
                        config.markerEvents = this.markerEvents;
                        var marker = new $jmelosegui.GoogleMarker(this, i, config);
                        this.renderMarker(marker);
                    };
                    if (this.enableMarkersClustering === true) {
                        this.refreshMap();
                    }
                    if (this.fitToMarkersBounds) {
                        this.GMap.fitBounds(this.bounds);
                    }
                }
            }
            // polygons
            if (this.polygons) {
                for (i = 0; i < this.polygons.length; i++) {
                    var polygon = new $jmelosegui.GooglePolygon(this.GMap, this.polygons[i]);
                    this.renderPolygon(polygon);
                }
            }
            // circles
            if (this.circles) {
                for (i = 0; i < this.circles.length; i++) {
                    var circle = new $jmelosegui.GoogleCircle(this.GMap, this.circles[i]);
                    this.renderPolygon(circle);
                }
            }
            // mapTypes
            var mapType;
            if (this.imageMapTypes) {
                for (i = 0; i < this.imageMapTypes.length; i++) {
                    mapType = new $jmelosegui.ImageMapType(this.GMap, this.imageMapTypes[i]);
                    this.addImageMapType(this.GMap, mapType);
                }
            }

            if (this.styledMapTypes) {
                for (i = 0; i < this.styledMapTypes.length; i++) {
                    mapType = new $jmelosegui.StyledMapType(this.GMap, this.styledMapTypes[i]);
                    this.addStyledMapType(this.GMap, mapType);
                }
            }
            //layers
            if (this.layers) {
                for (i = 0; i < this.layers.length; i++) {
                    var layer = this.layers[i];
                    if (layer.name === 'heatmap') {
                        var heatmapLayer = new $jmelosegui.HeatMapLayer(this.GMap, layer.options);
                        this.addHeatMapLayer(this.GMap, heatmapLayer);
                    }
                    if (layer.name === 'kml') {
                        var kmlLayer = new $jmelosegui.KmlLayer(this.GMap, layer.options);
                        this.addKmlLayer(this.GMap, kmlLayer);
                    }
                    if (layer.name === 'traffic') {
                        this.addTrafficLayer(this.GMap);
                    }
                    if (layer.name === 'bicycling') {
                        this.addBicyclingLayer(this.GMap);
                    }
                    if (layer.name === 'transit') {
                        this.addTransitLayer(this.GMap);
                    }
                }
            }
            this.GMap.setMapTypeId(this.getMapTypeId());
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
        },
        // Heatmap
        addHeatMapLayer: function (map, options) {

            var data = [];
            for (var j = 0; j < options.data.length; j++) {
                data.push(new google.maps.LatLng(options.data[j].lat, options.data[j].lng));
            }

            var heatmap = new google.maps.visualization.HeatmapLayer({
                dissipating: options.dissipating,
                maxIntensity: options.maxIntensity,
                opacity: options.opacity,
                radius: options.radius,
                gradient: options.gradient,
                data: data
            });

            heatmap.setMap(map);
        },
        //Kml
        addKmlLayer: function (map, options) {

            var kmlLayer = new google.maps.KmlLayer(options);
            kmlLayer.setMap(map);
        },
        //Traffic
        addTrafficLayer: function (map) {
            var trafficLayer = new google.maps.TrafficLayer();
            trafficLayer.setMap(map);
        },
        //Bicycling
        addBicyclingLayer: function (map) {
            var bikeLayer = new google.maps.BicyclingLayer();
            bikeLayer.setMap(map);
        },
        //Transit
        addTransitLayer: function (map) {
            var transitLayer = new google.maps.TransitLayer();
            transitLayer.setMap(map);
        }
    };

})(jQuery);