#nullable enable
namespace BlazorApp.Web.Data.Models
{
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
}


