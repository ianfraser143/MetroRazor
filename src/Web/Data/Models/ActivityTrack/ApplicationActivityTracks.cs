using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;

namespace BlazorApp.Web.Data.Models
{
    public class ApplicationActivityTracks
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

        public string ParentID { get; set; }
        public string RefID { get; set; }
        public string RefType { get; set; }
    }

}
