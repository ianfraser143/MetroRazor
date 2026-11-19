#nullable enable
namespace BlazorApp.Web.Data.Models
{
    public class ApplicationRoleClaim
    {
        public int Id { get; set; }
        public string RoleId { get; set; } = string.Empty;
        public string? ClaimType { get; set; }
        public string? ClaimValue { get; set; }
    }
}

