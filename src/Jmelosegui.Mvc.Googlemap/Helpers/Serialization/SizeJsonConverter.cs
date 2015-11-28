// Copyright (c) Juan M. Elosegui. All rights reserved.
// Licensed under the GPL v2 license. See LICENSE.txt file in the project root for full license information.

namespace Jmelosegui.Mvc.GoogleMap
{
    using System;
    using System.Drawing;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class SizeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Size);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // TODO: camelCase for javascript serialization
            var size = (Size)value;
            var jo = new JObject { { "width", size.Width }, { "height", size.Height } };
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // TODO: camelCase for javascript serialization
            JObject jo = JObject.Load(reader);
            return new Size((int)jo["width"], (int)jo["height"]);
        }
    }
}
