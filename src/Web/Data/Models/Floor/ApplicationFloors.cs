namespace BlazorApp.Web.Data.Models
{
    public class ApplicationFloors
    {
        public string _id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string BuildingID { get; set; }
        public string FloorNumber { get; set; }
    }

}
