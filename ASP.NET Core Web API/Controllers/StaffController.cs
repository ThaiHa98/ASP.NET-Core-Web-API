using ASP.NET_Core_Web_API.Data;
using ASP.NET_Core_Web_API.Dto;
using ASP.NET_Core_Web_API.Interfaces;
using ASP.NET_Core_Web_API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly DataDBContext _dbContext;
        private readonly IStaffRepository _staffRepository;
        private readonly IMapper _mapper;
        public StaffController(IStaffRepository staffRepository, DataDBContext dataDBContext,IMapper mapper)
        {
            _dbContext = dataDBContext;
            _staffRepository = staffRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Staff>))]
        public IActionResult GetStaffs()
        {
            var staff = _mapper.Map<List<StaffDto>>(_staffRepository.GetStaff());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(staff);
        }

        [HttpGet("{staffId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetStaff(int staffId)
        {
            if (!_staffRepository.StaffExists(staffId))
                return NotFound();
            var staff = _mapper.Map<StaffDto>(_staffRepository.GetStaff(staffId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(staff);
        }

        [HttpGet("{staffId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetStaffRating(int staffId) 
        {
            if(!_staffRepository.StaffExists(staffId))
                return NotFound();
            var rating = _staffRepository.GetStaffRating(staffId);
            if(!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
    }
}
