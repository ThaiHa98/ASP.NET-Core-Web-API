using ASP.NET_Core_Web_API.Models;

namespace ASP.NET_Core_Web_API.Interfaces
{
    public interface ICountriesRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int id);
        Country GetCountry(string Name);
        Country GetOwnersByCountry(int ownerid);
        ICollection<Owner> GetOwnersFromACountry(int ownerid);
        bool CountryExists (int id);
    }
}
