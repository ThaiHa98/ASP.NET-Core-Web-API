namespace ASP.NET_Core_Web_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<StaffCategory> StaffCategories { get; set; }
    }
}
