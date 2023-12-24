using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Interfaces
{
    public interface IStaffRepository
    {
        ICollection<Staff> GetStaff();
        Staff GetStaff(int id);
        Staff GetStaff(string name);
        decimal GetStaffRating(int staffId);
        bool StaffExists(int staffId);
    }
}
