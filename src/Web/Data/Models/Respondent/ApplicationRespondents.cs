using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;
using System.Security.Cryptography;

namespace BlazorApp.Web.Data.Models
{
    public class ApplicationRespondents
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
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string DateOfBirth { get; set; }
    }

}
