#nullable enable
namespace BlazorApp.Web.Data.Models
{
    public class ApplicationUserClaim
    {
        public string UserId { get; set; } = string.Empty;
        public int Id { get; set; }
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}

