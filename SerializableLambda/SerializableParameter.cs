using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SerializableLambda
{
    [JsonConverter(typeof(SerializableParameterConverter))]
    internal class SerializableParameter
    {
        public object Value { get; }
        public Type Type { get; }

        public SerializableParameter(object value)
        {
            this.Value = value;
            this.Type = value.GetType();
        }
    }

    internal class SerializableParameterConverter : JsonConverter<SerializableParameter>
    {
        public override SerializableParameter ReadJson(JsonReader reader, Type objectType, SerializableParameter existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                var obj = JObject.Load(reader);

                var type = Type.GetType(obj.Value<string>("Type"), true);

                var value = typeof(JToken)
                    .GetMethod(nameof(JToken.Value), new Type[] { typeof(string) })
                    .MakeGenericMethod(type)
                    .Invoke(obj, new object[] { "Value" });

                return new SerializableParameter(value);
            }

            return null;

        }

        public override void WriteJson(JsonWriter writer, SerializableParameter value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new { value.Value, value.Type });
        }
    }
}
