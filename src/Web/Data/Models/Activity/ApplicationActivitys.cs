using BlazorApp.Web.Data.Models;


namespace BlazorApp.Web.Data.Models
{
    public class ApplicationActivitys
    {
        public string _id { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Description { get; set; }
        public ApplicationAgencys Agencys { get; set; }
        public ApplicationStatusOptions StatusOptions { get; set; }
    }

}
