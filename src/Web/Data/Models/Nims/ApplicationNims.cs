#nullable enable
using BlazorApp.Web.Data.Models;
using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp.Web.Data.Models
{
    [BsonIgnoreExtraElements]
    public class ApplicationNims
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

        public Nimscategorys? NIMSCategorys { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }

        [BsonIgnoreIfNull]
        public object? Col0 { get; set; }

        [BsonSerializer(typeof(FlexibleStringSerializer))]
        public string? Priority { get; set; }

        [BsonIgnore]
        public int? PriorityValue => int.TryParse(Priority, out var p) ? p : null;

        public Nimstypes? NIMSTypes { get; set; }
        public ApplicationBranchs? Branchs { get; set; }
    }
}

