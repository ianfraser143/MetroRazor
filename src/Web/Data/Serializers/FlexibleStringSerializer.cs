using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BlazorApp.Web.Data.Serializers
{
    /// <summary>
    /// Flexible serializer for string? that can read BsonType.String, BsonType.Int32, BsonType.Int64, Shell "NumberInt('...')", or BsonType.Null.
    /// </summary>
    public class FlexibleStringSerializer : SerializerBase<string?>
    {
        public override string? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonType = context.Reader.CurrentBsonType;
            switch (bsonType)
            {
                case BsonType.String:
                    var s = context.Reader.ReadString();
                    if ((s.StartsWith("NumberInt('") && s.EndsWith("')")) ||
                        (s.StartsWith("NumberInt(\"") && s.EndsWith("\")")))
                    {
                        return s.Substring(11, s.Length - 13);
                    }
                    return s;
                case BsonType.Int32:
                    return context.Reader.ReadInt32().ToString();
                case BsonType.Int64:
                    return context.Reader.ReadInt64().ToString();
                case BsonType.Double:
                    return context.Reader.ReadDouble().ToString();
                case BsonType.Null:
                    context.Reader.ReadNull();
                    return null;
                default:
                    context.Reader.SkipValue();
                    return null;
            }
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string? value)
        {
            if (string.IsNullOrEmpty(value))
            {
                context.Writer.WriteNull();
            }
            else if (int.TryParse(value, out var intVal))
            {
                context.Writer.WriteInt32(intVal);
            }
            else
            {
                context.Writer.WriteString(value);
            }
        }
    }
}
