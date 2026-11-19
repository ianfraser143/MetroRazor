namespace BlazorApp.Web.Data.Models
{
    public class ApplicationRooms
    {
        public string _id { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string DisplayName { get; set; }
        public string SquareFeet { get; set; }
        public string Description { get; set; }
        public string BuildingID { get; set; }
        public string FloorID { get; set; }
    }

}
