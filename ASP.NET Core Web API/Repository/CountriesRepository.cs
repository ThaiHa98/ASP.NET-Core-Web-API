using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Repository
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly DataDBContext _dbContext;
        public CountriesRepository(DataDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CountryExists(int id)
        {
            return _dbContext.Countries.Any(c => c.Id == id);
        }

        public ICollection<Country> GetCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public Country GetCountry(int id)
        {
            return _dbContext.Countries.Where(x => x.Id == id).FirstOrDefault();
        }

        public Country GetCountry(string Name)
        {
            return _dbContext.Countries.Where(x => x.Name == Name).FirstOrDefault();
        }

        public Country GetOwnersByCountry(int ownerid)
        {
            return _dbContext.Owners.Where(x => x.Id == ownerid).Select(c => c.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int ownerid)
        {
            return _dbContext.Owners.Where(x => x.Id == ownerid).ToList();
        }
    }
}
