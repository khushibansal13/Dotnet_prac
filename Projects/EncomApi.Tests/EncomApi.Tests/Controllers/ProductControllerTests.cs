using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Repositories;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using EncomApi.Models;
using EncomApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using EncomApi.Dtos.Product;
using EncomApi.Interfaces;
using EncomApi.Mappers;

namespace EncomApi.Tests.Controllers
{
    [TestFixture]
    public class ProductControllerTests
    {
        private ProductController _controller;
        private Mock<IProductRepository> _repositoryMock;
        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IProductRepository>();
            _controller = new ProductController(_repositoryMock.Object);
        }

        [Test]
        public async Task GetProducts_ReturnListofProducts()
        {
            // Arrange
            var products = new List<Product>
    {
        new Product
        {
            Id = 1,
            Title = "Product1",
            Description = "A high-quality product",
            Price = 99.99m,
            Stock = 50,
            AvailabilityStatus = "In Stock",
            CategoryId = 1,
            Category = new Category { Id = 1, Name = "Category1" },
            Reviews = new List<Review> { new Review { ReviewerName = "John Doe", Comment = "Great product!" } },
            Dimensions = new Dimensions { Width = 10.0m, Height = 5.0m, Depth = 3.0m }
        }
    };
            _repositoryMock.Setup(m => m.GetAllProductsAsync()).ReturnsAsync(products);

            // Act
            var result = await _controller.GetProducts();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.InstanceOf<List<ProductDto>>());
            var returnedDtos = okResult.Value as List<ProductDto>;
            Assert.That(returnedDtos, Is.Not.Null);
            Assert.That(returnedDtos.Count, Is.EqualTo(products.Count));
            Assert.That(returnedDtos.First().Title, Is.EqualTo(products[0].Title));
            Assert.That(returnedDtos.First().Price, Is.EqualTo(products[0].Price));
            Assert.That(returnedDtos.First().Stock, Is.EqualTo(products[0].Stock));
            Assert.That(returnedDtos.First().Brand, Is.EqualTo(products[0].Brand));
            Assert.That(returnedDtos.First().AvailabilityStatus, Is.EqualTo(products[0].AvailabilityStatus));
        }

        [Test]
        public async Task GetProductById_ReturnProductById()
        {
            // Arrange
            var product = new Product
            {
                Id = 1,
                Title = "Product1",
                Description = "A high-quality product",
                Price = 99.99m,
                Stock = 50,
                AvailabilityStatus = "In Stock",
                CategoryId = 1,
                Category = new Category { Id = 1, Name = "Category1" },
                Reviews = new List<Review> { new Review { ReviewerName = "John Doe", Comment = "Great product!" } },
                Dimensions = new Dimensions { Width = 10.0m, Height = 5.0m, Depth = 3.0m }
            };
            _repositoryMock.Setup(m => m.GetProductByIdAsync(It.Is<int>(id => id == 1))).ReturnsAsync(product);
            // Act
            var result = await _controller.GetProductById(1);
            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.InstanceOf<ProductDto>());
            var returnedDto = okResult.Value as ProductDto;
            Assert.That(returnedDto, Is.Not.Null);
            Assert.That(returnedDto.Title, Is.EqualTo(product.Title));
            Assert.That(returnedDto.Price, Is.EqualTo(product.Price));
            Assert.That(returnedDto.Stock, Is.EqualTo(product.Stock));
            Assert.That(returnedDto.Brand, Is.EqualTo(product.Brand));
            Assert.That(returnedDto.AvailabilityStatus, Is.EqualTo(product.AvailabilityStatus));
            Assert.That(returnedDto.CategoryId, Is.EqualTo(product.Category.Id));
            Assert.That(returnedDto.CategoryName, Is.EqualTo(product.Category.Name));
        }

        [Test]
        public async Task CreateProduct_ReturnCreatedProduct()
        {
            // Arrange
            var createProductDto = new CreateProductDto
            {
                Title = "Product1",
                Description = "A high-quality product",
                Price = 99.99m,
                Stock = 50,
                DiscountPercentage = 10.0m,
                Tags = new List<string> { "Tag1", "Tag2" },
                CategoryName = "Category1",
            };

            var createdProduct = createProductDto.ToProductFromCreate();
            createdProduct.Id = 1;
            createdProduct.CategoryId = 1;
            createdProduct.Category = new Category { Id = 1, Name = "Category1" };
            createdProduct.AvailabilityStatus = "In Stock";

            _repositoryMock.Setup(m => m.GetCategoryByNameAsync("Category1"))
                .ReturnsAsync(new Category { Id = 1, Name = "Category1" });
            _repositoryMock.Setup(m => m.CreateProductAsync(It.Is<Product>(p =>
                p.Title == createProductDto.Title &&
                p.CategoryId == 1)))
                .ReturnsAsync(new Product { Id = 1, CategoryId = 1 });
            _repositoryMock.Setup(m => m.GetProductByIdAsync(1))
                .ReturnsAsync(createdProduct);

            // Act
            var result = await _controller.CreateProduct(createProductDto);

            // Assert
            Assert.That(result, Is.InstanceOf<CreatedAtActionResult>());
            var createdResult = result as CreatedAtActionResult;
            Assert.That(createdResult?.StatusCode, Is.EqualTo(201));
            Assert.That(createdResult.Value, Is.InstanceOf<ProductDto>());
            var returnedDto = createdResult.Value as ProductDto;
            Assert.That(returnedDto, Is.Not.Null);
            Assert.That(returnedDto.Id, Is.EqualTo(1));
            Assert.That(returnedDto.Title, Is.EqualTo(createProductDto.Title));
            Assert.That(returnedDto.Price, Is.EqualTo(createProductDto.Price));
            Assert.That(returnedDto.Stock, Is.EqualTo(createProductDto.Stock));
            Assert.That(returnedDto.DiscountPercentage, Is.EqualTo(createProductDto.DiscountPercentage));
            Assert.That(returnedDto.Tags, Is.EqualTo(createProductDto.Tags));
            Assert.That(returnedDto.CategoryName, Is.EqualTo(createProductDto.CategoryName));
        }

        [Test]
        public async Task UpdateProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            var updateProductDto = new UpdateProductDto
            {
                Title = "Updated Product",
                Description = "Updated description",
                Price = 149.99m,
                Stock = 75,
                CategoryName = "Category1"
            };

            var existingProduct = new Product
            {
                Id = 1,
                Title = "Original Product",
                Description = "Original description",
                Price = 99.99m,
                Stock = 50,
                CategoryId = 2,
                Category = new Category { Id = 2, Name = "Category2" },
                AvailabilityStatus = "In Stock"
            };

            var updatedProduct = new Product
            {
                Id = 1,
                Title = updateProductDto.Title,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                Stock = updateProductDto.Stock,
                CategoryId = 1,
                Category = new Category { Id = 1, Name = "Category1" },
                AvailabilityStatus = "In Stock"
            };

            _repositoryMock.SetupSequence(m => m.GetProductByIdAsync(1))
                .ReturnsAsync(existingProduct)
                .ReturnsAsync(updatedProduct);
            _repositoryMock.Setup(m => m.GetCategoryByNameAsync("Category1"))
                .ReturnsAsync(new Category { Id = 1, Name = "Category1" });
            _repositoryMock.Setup(m => m.UpdateProductAsync(It.Is<Product>(p =>
                p.Id == 1 &&
                p.Title == updateProductDto.Title &&
                p.Description == updateProductDto.Description &&
                p.Price == updateProductDto.Price &&
                p.Stock == updateProductDto.Stock &&
                p.CategoryId == 1)))
                .Returns(Task.FromResult<Product>(null));

            // Act
            var result = await _controller.UpdateProduct(1, updateProductDto);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.InstanceOf<ProductDto>());
            var returnedDto = okResult.Value as ProductDto;
            Assert.That(returnedDto, Is.Not.Null);
            Assert.That(returnedDto.Id, Is.EqualTo(1));
            Assert.That(returnedDto.Title, Is.EqualTo(updateProductDto.Title));
            Assert.That(returnedDto.Description, Is.EqualTo(updateProductDto.Description));
            Assert.That(returnedDto.Price, Is.EqualTo(updateProductDto.Price));
            Assert.That(returnedDto.Stock, Is.EqualTo(updateProductDto.Stock));
            Assert.That(returnedDto.CategoryName, Is.EqualTo(updateProductDto.CategoryName));
        }

        [Test]
        public async Task DeleteProduct_ReturnsNoContent()
        {
            // Arrange
            _repositoryMock.Setup(m => m.GetProductByIdAsync(1)).ReturnsAsync(new Product { Id = 1 });
            _repositoryMock.Setup(m => m.DeleteProductAsync(1)).Returns(Task.FromResult(true));
            // Act
            var result = await _controller.DeleteProduct(1);
            // Assert
            Assert.That(result, Is.InstanceOf<NoContentResult>());
            var noContentResult = result as NoContentResult;
            Assert.That(noContentResult?.StatusCode, Is.EqualTo(204));
        }


    }
}