using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EncomApi.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace EncomApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/categoryList")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            var categoryDtos = categories.Select(c => c.Name).ToList();
            return Ok(categoryDtos);
        }
        
    }
}