namespace ASP.NET_Core_Web_API.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Reviewer Reviewer { get; set; }
        public Staff Staffs { get; set; }
    }
}
