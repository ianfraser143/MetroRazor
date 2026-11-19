using BlazorApp.Web.Data.Models;

namespace BlazorApp.Web.Data.Models
{
    public class ApplicationAgencys
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public ApplicationBranchs Branchs { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string PrimaryNumber { get; set; }
        public string Website { get; set; }
        public string EmailAddres { get; set; }
    }

}
