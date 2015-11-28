// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;

    public class MapTypeBuilder<TMapType>
        where TMapType : MapTypeBase
    {
        public MapTypeBuilder(TMapType mapType)
        {
            this.MapType = mapType;
        }

        protected MapTypeBuilder(MapTypeBuilder<TMapType> builder)
            : this(PassThroughNonNull(builder).MapType)
        {
        }

        protected TMapType MapType { get; private set; }

        public MapTypeBuilder<TMapType> MapTypeAltName(string value)
        {
            this.MapType.MapTypeAltName = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MaxZoom(int value)
        {
            this.MapType.MaxZoom = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MinZoom(int value)
        {
            this.MapType.MinZoom = value;
            return this;
        }

        public MapTypeBuilder<TMapType> MapTypeName(string name)
        {
            this.MapType.MapTypeName = name;
            return this;
        }

        public MapTypeBuilder<TMapType> Opacity(int value)
        {
            this.MapType.Opacity = value;
            return this;
        }

        public MapTypeBuilder<TMapType> Radius(int value)
        {
            this.MapType.Radius = value;
            return this;
        }

        private static MapTypeBuilder<TMapType> PassThroughNonNull(MapTypeBuilder<TMapType> builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            return builder;
        }
    }
}