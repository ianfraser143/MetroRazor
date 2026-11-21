using BlazorApp.Web.Data.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazorApp.Web.Data.Models
{
    public class Buildings
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

        public string Address { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Height { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string SquareFeet { get; set; }
        public BuildingTypes BuildingTypes { get; set; }
    }

}

