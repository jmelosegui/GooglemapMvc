using System;
using System.Drawing;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jmelosegui.Mvc.GoogleMap
{
    public class PointJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Point));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //TODO: camelCase for javascript serialization
            var point = (Point)value;
            var jo = new JObject { { "x", point.X }, { "y", point.Y } };
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //TODO: camelCase for javascript serialization
            JObject jo = JObject.Load(reader);
            return new Point((int)jo["x"], (int)jo["y"]);
        }
    }
}