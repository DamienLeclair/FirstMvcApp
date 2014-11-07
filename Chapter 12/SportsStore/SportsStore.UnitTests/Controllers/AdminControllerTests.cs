/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace SportsStore.UnitTests.Controllers
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;

    [TestClass]
    public class AdminControllerTests
    {
        [TestMethod]
        public void Index_Contains_All_Products()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1" }, 
                        new Product { ProductId = 2, Name = "P2" },
                        new Product { ProductId = 3, Name = "P3" }
                    });

            var target = new AdminController(mock.Object);

            // Act
            var result = (Product[])target.Index().ViewData.Model;

            //Assert
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("P1", result[0].Name);
            Assert.AreEqual("P2", result[1].Name);
            Assert.AreEqual("P3", result[2].Name);
        }

        [TestMethod]
        public void Can_Edit_Product()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1" }, 
                        new Product { ProductId = 2, Name = "P2" },
                        new Product { ProductId = 3, Name = "P3" }
                    });

            var target = new AdminController(mock.Object);

            // Act
            var p1 = target.Edit(1).ViewData.Model as Product;
            var p2 = target.Edit(2).ViewData.Model as Product;
            var p3 = target.Edit(3).ViewData.Model as Product;

            //Assert
            Assert.IsNotNull(p1);
            Assert.IsNotNull(p2);
            Assert.IsNotNull(p3);
            Assert.AreEqual(1, p1.ProductId);
            Assert.AreEqual(2, p2.ProductId);
            Assert.AreEqual(3, p3.ProductId);
        }

        [TestMethod]
        public void Cannot_Edit_NoneExisting_Product()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1" }, 
                        new Product { ProductId = 2, Name = "P2" },
                        new Product { ProductId = 3, Name = "P3" }
                    });

            var target = new AdminController(mock.Object);

            // Act
            var p4 = target.Edit(4).ViewData.Model as Product;

            //Assert
            Assert.IsNull(p4);
        }

        [TestMethod]
        public void Can_Save_Valid_Changes()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            var target = new AdminController(mock.Object);
            var product = new Product { Name = "Test" };

            // Act
            var result = target.Edit(product);

            //Assert
            mock.Verify(m => m.SaveProduct(product));
            Assert.IsNotInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Changes()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            var target = new AdminController(mock.Object);
            var product = new Product { Name = "Test" };
            target.ModelState.AddModelError("error", "error");

            // Act
            var result = target.Edit(product);

            //Assert
            mock.Verify(m => m.SaveProduct(It.IsAny<Product>()), Times.Never);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Can_Delete_Valid_Product()
        {
            // Arrange
            var product = new Product { ProductId = 2 };
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(new[] { new Product { ProductId = 1 }, product, new Product { ProductId = 3 } });
            var target = new AdminController(mock.Object);

            // Act
            var result = target.Delete(product.ProductId);

            // Assert
            mock.Verify(m => m.DeleteProduct(product.ProductId));
        }
    }
}
