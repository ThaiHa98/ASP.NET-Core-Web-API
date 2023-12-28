using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Dto;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using ASP.NET_Core_Web_API.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountriesRepository _countriesRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountriesRepository countriesRepository, IMapper mapper)
        {
            _countriesRepository = countriesRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(Country))]
        public IActionResult GetCountries()
        {
            var countries = _mapper.Map<List<CountryDto>>(_countriesRepository.GetCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countries);
        }
        [HttpGet("countryId")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int id)
        {
            if (!_countriesRepository.CountryExists(id))
                return NotFound();
            var country = _mapper.Map<List<CountryDto>>(_countriesRepository.GetCountry(id));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(country);
        }
        [HttpGet("countryName")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryName(string Name)
        {
            var countryName = _mapper.Map<List<CountryDto>>(_countriesRepository.GetCountry(Name));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countryName);
        }
        [HttpGet("owners/{ownersId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetCountryOfAnOwners(int ownerId)
        {
            var countryOf = _mapper.Map<List<CountryDto>>(_countriesRepository.GetOwnersFromACountry(ownerId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(countryOf);
        }
    }
}
