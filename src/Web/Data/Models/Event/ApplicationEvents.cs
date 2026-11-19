namespace BlazorApp.Web.Data.Models
{
    public class ApplicationEvents
    {
        public string _id { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string IncidentID { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
    }

}
