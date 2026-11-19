using BlazorApp.Web.Data.Models;

namespace BlazorApp.Web.Data.Models
{
    public class ApplicationBuildings
    {
        public string _id { get; set; }
        public bool IsActive { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string Height { get; set; }
        public string Owner { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public string SquareFeet { get; set; }
        public ApplicationBuildingTypes BuildingTypes { get; set; }
    }

}
