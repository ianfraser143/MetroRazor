using BlazorApp.Web.Data.Models;
using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;

namespace BlazorApp.Web.Data.Models
{
    public class ApplicationAgencys
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
        public string Name { get; set; }
        public bool IsActive { get; set; }

        [BsonSerializer(typeof(FlexibleDateTimeSerializer))]
        public DateTime? CreateDate { get; set; }

        [BsonSerializer(typeof(FlexibleDateTimeSerializer))]
        public DateTime? ModifiedDate { get; set; }

        public ApplicationBranchs Branchs { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string PrimaryNumber { get; set; }
        public string Website { get; set; }
        public string EmailAddres { get; set; }
    }

}
