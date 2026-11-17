#nullable enable
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace BlazorApp.Web.Data
{
    public class ApplicationDbContext
    {
        private readonly IMongoDatabase _database;

        public ApplicationDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<ApplicationUser> Users => _database.GetCollection<ApplicationUser>("Users");
        public IMongoCollection<ApplicationRole> Roles => _database.GetCollection<ApplicationRole>("Roles");
        public IMongoCollection<ApplicationUserRole> UserRoles => _database.GetCollection<ApplicationUserRole>("UserRoles");
        public IMongoCollection<ApplicationUserLogin> UserLogins => _database.GetCollection<ApplicationUserLogin>("UserLogins");
        public IMongoCollection<ApplicationUserPasskey> UserPasskeys => _database.GetCollection<ApplicationUserPasskey>("UserPasskeys");
        public IMongoCollection<ApplicationUserClaim> UserClaims => _database.GetCollection<ApplicationUserClaim>("UserClaims");
        public IMongoCollection<ApplicationRoleClaim> RoleClaims => _database.GetCollection<ApplicationRoleClaim>("RoleClaims");
        public IMongoCollection<ApplicationUserToken> UserTokens => _database.GetCollection<ApplicationUserToken>("UserTokens");

        public IMongoCollection<ApplicationNims> Nims => _database.GetCollection<ApplicationNims>("NIMS");
        //public IMongoCollection<ApplicationNims> NimsRecondSet => Nims;
        //public IMongoCollection<ApplicationNims> NimsRecordSet => Nims;

        public async Task<List<ApplicationNims>> GetNimsRecordsAsync(CancellationToken cancellationToken = default)
        {
            var x1 = FilterDefinition<ApplicationNims>.Empty;

            var x2 = await Nims.Find(FilterDefinition<ApplicationNims>.Empty).ToListAsync(cancellationToken);
            return await Nims.Find(FilterDefinition<ApplicationNims>.Empty).ToListAsync(cancellationToken);
        }

        public async Task SeedSampleNimsIfEmptyAsync(CancellationToken cancellationToken = default)
        {
            var count = await Nims.CountDocumentsAsync(FilterDefinition<ApplicationNims>.Empty, cancellationToken: cancellationToken);
            if (count == 0)
            {
                await Nims.InsertOneAsync(CreateSampleNims(), cancellationToken: cancellationToken);
            }
        }

        public static ApplicationNims CreateSampleNims()
        {
            return new ApplicationNims
            {
                _id = "4d0d4c238b4901a698857538",
                IsActive = true,
                CreateDate = DateTime.Parse("2023-02-18T03:09:07.000Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                ModifiedDate = DateTime.Parse("2023-02-18T03:09:07.000Z", null, System.Globalization.DateTimeStyles.RoundtripKind),
                Code = "1151",
                Description = "Escort",
                Priority = "5",
                Col0 = null,
                NIMSCategorys = new Nimscategorys
                {
                    _id = "6674b614133de934fd16bda0",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                },
                NIMSTypes = new Nimstypes
                {
                    _id = "6674b614133de934fd16bd9e",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                },
                Branchs = new Branchs
                {
                    _id = "6674b614133de934fd16bd9f",
                    IsActive = false,
                    CreateDate = DateTime.MinValue,
                    ModifiedDate = DateTime.MinValue
                }
            };
        }
    }

    public class ApplicationRole
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? ConcurrencyStamp { get; set; }
    }

    public class ApplicationUserRole
    {
        public string UserId { get; set; } = string.Empty;
        public string RoleId { get; set; } = string.Empty;
    }

    public class ApplicationUserLogin
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? ProviderDisplayName { get; set; }
    }

    public class ApplicationUserPasskey
    {
        public string UserId { get; set; } = string.Empty;
        public byte[] CredentialId { get; set; } = [];
        public byte[] PublicKey { get; set; } = [];
        public DateTimeOffset CreatedAt { get; set; }
        public uint SignCount { get; set; }
        public string[] Transports { get; set; } = [];
        public bool IsUserVerified { get; set; }
        public bool IsBackupEligible { get; set; }
        public bool IsBackedUp { get; set; }
        public byte[] AttestationObject { get; set; } = [];
        public byte[] ClientDataJson { get; set; } = [];
        public string? Name { get; set; }
    }

    public class ApplicationUserClaim
    {
        public string UserId { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

    public class ApplicationRoleClaim
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }

    public class ApplicationUserToken
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
    }

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

        public Branchs? Branchs { get; set; }
    }

    [BsonIgnoreExtraElements]
    public class Nimscategorys
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

    [BsonIgnoreExtraElements]
    public class Branchs
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

    /// <summary>
    /// Flexible serializer for string? that can read BsonType.String,
    /// BsonType.Int32, BsonType.Int64, Shell "NumberInt('...')", or BsonType.Null.
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
