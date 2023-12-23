namespace ASP.NET_Core_Web_API.Models
{
    public class Staff
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection <Review> Reviews { get; set; }
        public ICollection<StaffOwner> StaffOwners { get; set; }
        public ICollection<StaffCategory> staffCategories { get; set; }
    }
}
