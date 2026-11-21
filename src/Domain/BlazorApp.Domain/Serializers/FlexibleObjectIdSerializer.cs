using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace BlazorApp.Web.Data.Serializers
{
    /// <summary>
    /// Flexible serializer for MongoDB ObjectId that can read BsonType.ObjectId,
    /// BsonType.String (including Compass/Shell export strings like "ObjectId('...')"), or BsonType.Null.
    /// </summary>
    public class FlexibleObjectIdSerializer : SerializerBase<string?>
    {
        public override string? Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var bsonType = context.Reader.CurrentBsonType;
            switch (bsonType)
            {
                case BsonType.ObjectId:
                    return context.Reader.ReadObjectId().ToString();
                case BsonType.String:
                    var s = context.Reader.ReadString();
                    if ((s.StartsWith("ObjectId('") && s.EndsWith("')")) ||
                        (s.StartsWith("ObjectId(\"") && s.EndsWith("\")")))
                    {
                        return s.Substring(10, s.Length - 12);
                    }
                    return s;
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
            else if (ObjectId.TryParse(value, out var oid))
            {
                context.Writer.WriteObjectId(oid);
            }
            else
            {
                context.Writer.WriteString(value);
            }
        }
    }
}
