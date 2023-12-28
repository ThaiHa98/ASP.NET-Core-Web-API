using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataDBContext _dbContext;
        public CategoryRepository(DataDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CategoriesExists(int id)
        {
            return _dbContext.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        public ICollection<Staff> GetStaffByCategory(int categoryid)
        {
            return _dbContext.StaffCategories.Where(x => x.CategoryId == categoryid).Select(x => x.Staff).ToList();
        }
    }
}
