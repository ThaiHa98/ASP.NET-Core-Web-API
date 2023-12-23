namespace ASP.NET_Core_Web_API.Models
{
    public class Reviewer
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Review> Reviews { get; set;}
    }
}
