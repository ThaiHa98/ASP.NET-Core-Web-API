namespace ASP.NET_Core_Web_API.Models
{
    public class StaffCategory
    {
        public int StaffId { get; set; }
        public int CategoryId { get; set; }
        public Staff Staff { get; set; }
        public Category Category { get; set; }
    }
}
