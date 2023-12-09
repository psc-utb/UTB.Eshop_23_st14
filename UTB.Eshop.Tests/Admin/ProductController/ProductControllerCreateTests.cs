using System;
using System.Diagnostics;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Moq;
using UTB.Eshop.Application.Abstraction;
using UTB.Eshop.Domain.Entities;
using UTB.Eshop.Infrastructure.Database;
using UTB.Eshop.Web.Areas.Admin.Controllers;

namespace UTB.Eshop.Tests.Admin.ProductController
{
    public class ProductControllerCreateTests
    {
        [Fact]
        public async Task Create_success()
        {
            //Arrange
            DatabaseFake.Products.Clear();
            Mock<IProductAppService> productServiceMock = new Mock<IProductAppService>();
            productServiceMock.Setup(productService => productService.Create(It.IsAny<Product>()))
                                        .Returns<Product>(product => Task.Run(() => { DatabaseFake.Products.Add(product); }));

            var product = GetProduct();

            var productController = new Web.Areas.Admin.Controllers.ProductController(productServiceMock.Object);


            //Act
            var actionResult = await productController.Create(product);


            //Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(actionResult);
            Assert.NotNull(redirectToActionResult.ActionName);
            Assert.Equal(nameof(Web.Areas.Admin.Controllers.ProductController.Index), redirectToActionResult.ActionName);

            Assert.NotEmpty(DatabaseFake.Products);
            Assert.Single(DatabaseFake.Products);
        }

        Product GetProduct()
        {
            return new Product()
            {
                Id = 1,
                Name = "Produkt",
                Price = 1.0,
                Description = String.Empty,
                ImageSrc = "/superimage.jpeg",
                Image = new Mock<IFormFile>().Object
            };
        }
    }
}

