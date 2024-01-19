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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetCategories()
        {
            var category = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategories());
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }
        [HttpPost("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if(!_categoryRepository.CategoriesExists(categoryId))
                return NotFound();
            var category1 = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetCategory(categoryId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category1);
        }
        [HttpGet("staff/{categoryId}")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Category>))]
        [ProducesResponseType(400)]
        public IActionResult GetStaffByCategory(int categoryId)
        {
            var staffByCate = _mapper.Map<List<CategoryDto>>(_categoryRepository.GetStaffByCategory(categoryId));
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(staffByCate);
        }
        //[HttpGet()]
        //[ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        //[ProducesResponseType(400)]
        //public IActionResult GetString()
        //{
        //    return 
        //}
        
        [HttpGet("test")]
        public IActionResult GetAll()
        {
            return Ok("loi he thong");
        }

    }
}
