using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Jmelosegui.Mvc.Googlemap
{
    public class LocationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Location));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //TODO: camelCase for javascript serialization
            var location = (Location)value;
            var jo = new JObject { { "lat", location.Latitude }, { "lng", location.Longitude } };
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            //TODO: camelCase for javascript serialization
            JObject jo = JObject.Load(reader);
            return new Location((double)jo["lat"], (double)jo["lng"]);
        }
    }
}