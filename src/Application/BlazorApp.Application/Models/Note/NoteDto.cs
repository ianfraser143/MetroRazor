namespace BlazorApp.Api.Models
{
    public class NoteDto
    {
        public string? Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public object? Col0 { get; set; }
        // Flattened sub‑objects (optional)
        public string? CategoryId { get; set; }
        public string? TypeId { get; set; }
        public string? BranchId { get; set; }
    }
}

