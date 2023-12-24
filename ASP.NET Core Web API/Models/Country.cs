namespace ASP.NET_Core_Web_API.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Owner> Owners { get; set; }
    }
}
