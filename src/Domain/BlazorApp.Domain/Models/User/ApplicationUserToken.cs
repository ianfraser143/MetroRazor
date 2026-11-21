#nullable enable
namespace BlazorApp.Web.Data.Models
{
    public class ApplicationUserToken
    {
        public string UserId { get; set; } = string.Empty;
        public string LoginProvider { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Value { get; set; }
    }
}


