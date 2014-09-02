/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace SportsStore.UnitTests.Controllers
{
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
    }
}
