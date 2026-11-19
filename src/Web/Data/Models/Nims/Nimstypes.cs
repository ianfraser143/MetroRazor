#nullable enable
using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp.Web.Data.Models
{
    [BsonIgnoreExtraElements]
    public class Nimstypes
    {
        [BsonId]
        [BsonSerializer(typeof(FlexibleObjectIdSerializer))]
        public string? _id { get; set; }

        [BsonIgnore]
        public string? Id
        {
            get => _id;
            set => _id = value;
        }

        public bool IsActive { get; set; }

        [BsonSerializer(typeof(FlexibleDateTimeSerializer))]
        public DateTime? CreateDate { get; set; }

        [BsonSerializer(typeof(FlexibleDateTimeSerializer))]
        public DateTime? ModifiedDate { get; set; }

        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
    }
}

