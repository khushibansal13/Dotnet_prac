using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Controllers;
using EncomApi.Interfaces;
using EncomApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace EncomApi.Tests.Controllers
{
    [TestFixture]
    public class CategoryControllerTests
    {
        private CategoryController _categoryController;
        private Mock<ICategoryRepository> _categoryRepository;
        [SetUp]
        public void Setup()
        {
            _categoryRepository = new Mock<ICategoryRepository>();
            _categoryController = new CategoryController(_categoryRepository.Object);
        }

        [Test]
        public async Task GetCategoryList_ReturnsCategoryNames()
        {
            // Arrange
            var categories = new List<Category>
    {
        new Category { Id = 1, Name = "Category1" },
        new Category { Id = 2, Name = "Category2" },
        new Category { Id = 3, Name = "Category3" }
    };

            _categoryRepository.Setup(m => m.GetAllCategoriesAsync())
                .ReturnsAsync(categories);

            // Act
            var result = await _categoryController.GetCategoryList();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            var okResult = result as OkObjectResult;
            Assert.That(okResult?.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.InstanceOf<List<string>>());
            var categoryNames = okResult.Value as List<string>;
            Assert.That(categoryNames, Has.Count.EqualTo(3));
            Assert.That(categoryNames, Is.EqualTo(new List<string> { "Category1", "Category2", "Category3" }));
        }
    }
}