using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataDBContext _dbContext;
        public StaffRepository(DataDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Staff> GetStaff()
        {
            return _dbContext.Staffs.OrderBy(x => x.Id).ToList();
        }

        public Staff GetStaff(int id)
        {
            return _dbContext.Staffs.Where(p => p.Id == id).FirstOrDefault();
        }

        public Staff GetStaff(string name)
        {
            return _dbContext.Staffs.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetStaffRating(int staffId)
        {
            var review = _dbContext.Reviews.Where(p => p.Staff.Id == staffId);
            if(review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
        }

        public bool StaffExists(int staffId)
        {
            return _dbContext.Staffs.Any(p => p.Id == staffId);
        }
    }
}
