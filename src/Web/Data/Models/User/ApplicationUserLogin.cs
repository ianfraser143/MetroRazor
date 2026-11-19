#nullable enable
namespace BlazorApp.Web.Data.Models
{
    public class ApplicationUserLogin
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
        public string? ProviderDisplayName { get; set; }
    }
}

