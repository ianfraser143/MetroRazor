using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BlazorApp.Web.Data.Serializers
{
    /// <summary>
    /// Flexible serializer for DateTime? that can read BsonType.DateTime,
    /// BsonType.String (ISO strings or Shell "ISODate('...')"), or BsonType.Null.
    /// </summary>
    public class FlexibleDateTimeSerializer : SerializerBase<DateTime?>
    {
        public override DateTime? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonType = context.Reader.CurrentBsonType;
            switch (bsonType)
            {
                case BsonType.DateTime:
                    var ms = context.Reader.ReadDateTime();
                    return DateTimeOffset.FromUnixTimeMilliseconds(ms).UtcDateTime;
                case BsonType.String:
                    var s = context.Reader.ReadString();
                    if ((s.StartsWith("ISODate('") && s.EndsWith("')")) ||
                        (s.StartsWith("ISODate(\"") && s.EndsWith("\")")))
                    {
                        s = s.Substring(9, s.Length - 11);
                    }
                    if (DateTime.TryParse(s, null, System.Globalization.DateTimeStyles.RoundtripKind, out var dt))
                    {
                        return dt.ToUniversalTime();
                    }
                    return null;
                case BsonType.Null:
                    context.Reader.ReadNull();
                    return null;
                default:
                    context.Reader.SkipValue();
                    return null;
            }
        }

        public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime? value)
        {
            if (value.HasValue)
            {
                var ms = new DateTimeOffset(value.Value.ToUniversalTime()).ToUnixTimeMilliseconds();
                context.Writer.WriteDateTime(ms);
            }
            else
            {
                context.Writer.WriteNull();
            }
        }
    }
}
