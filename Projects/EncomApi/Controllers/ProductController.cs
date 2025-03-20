using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Dtos.Product;
using EncomApi.Interfaces;
using EncomApi.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace EncomApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
       public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            var productDtos = products.Select(p => p.ToProductDto()).ToList();
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var productDto = product.ToProductDto();
            return Ok(productDto);
        }

        [HttpPost("add")]
        [EnableRateLimiting("productAdd")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto createProductDto)
        {
            var category = await _repository.GetCategoryByNameAsync(createProductDto.CategoryName);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            var product = createProductDto.ToProductFromCreate();
            product.CategoryId = category.Id;

            var createdProduct = await _repository.CreateProductAsync(product);
            var productWithCategory = await _repository.GetProductByIdAsync(createdProduct.Id);
            var productDto = productWithCategory.ToProductDto();
            return CreatedAtAction(nameof(GetProductById), new { id = productDto.Id }, productDto);
        }

        [HttpPut("{id}")]
        [EnableRateLimiting("productUpdate")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            var existingProduct = await _repository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            var category = await _repository.GetCategoryByNameAsync(updateProductDto.CategoryName);
            if (category == null)
            {
                return BadRequest("Category not found");
            }
            existingProduct.UpdateFromDto(updateProductDto);
            existingProduct.CategoryId = category.Id;

            await _repository.UpdateProductAsync(existingProduct);
            var updatedProduct = await _repository.GetProductByIdAsync(id);
            var productDto = updatedProduct.ToProductDto();
            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        [EnableRateLimiting("productDelete")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _repository.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("category/{categoryName}")]
        public async Task<IActionResult> GetProductsByCategory(string categoryName)
        {
            var products = await _repository.GetProductsByCategoryAsync(categoryName);
            if (products == null || !products.Any())
            {
                return NotFound($"No products found for category '{categoryName}'");
            }

            var productsWithEmptyCategory = products.Where(p => string.IsNullOrEmpty(p.Category?.Name)).ToList();
            if (productsWithEmptyCategory.Any())
            {
                foreach (var product in products)
                {
                    if (string.IsNullOrEmpty(product.Category?.Name))
                    {
                        var category = await _repository.GetCategoryByNameAsync(categoryName);
                        product.Category = category; 
                    }
                }
            }
            var productDtos = products.Select(p => p.ToProductDto()).ToList();
            return Ok(productDtos);
        }
        
    }
}