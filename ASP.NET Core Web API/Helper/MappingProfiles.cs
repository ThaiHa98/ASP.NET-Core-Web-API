using ASP.NET_Core_Web_API.Dto;
using ASP.NET_Core_Web_API.Models;
using AutoMapper;

namespace ASP.NET_Core_Web_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<Staff, StaffDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
        }
    }
}
