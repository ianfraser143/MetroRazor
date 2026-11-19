namespace BlazorApp.Web.Data.Models
{
    public class ApplicationActivityTracks
    {
        public string _id { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string ParentID { get; set; }
        public string RefID { get; set; }
        public string RefType { get; set; }
    }

}
