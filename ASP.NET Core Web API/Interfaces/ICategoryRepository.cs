using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Staff> GetStaffByCategory(int categoryid);
        bool CategoriesExists(int id);
        
    }
}
