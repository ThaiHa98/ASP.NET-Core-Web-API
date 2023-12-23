namespace ASP.NET_Core_Web_API.Models
{
    public class StaffOwner
    {
        public int StaffId { get; set; }
        public int OwnerId { get; set; }
        public Staff Staff { get; set; }
        public Owner Owner { get; set; }
    }
}
