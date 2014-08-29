namespace SportsStore.UnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;

    [TestClass]
    public class NavControllerTests
    {
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1", Category = "Apples" }, 
                        new Product { ProductId = 2, Name = "P2", Category = "Apples" },
                        new Product { ProductId = 3, Name = "P3", Category = "Plums" }, 
                        new Product { ProductId = 4, Name = "P4", Category = "Oranges" }
                    });

            var controller = new NavController(mock.Object);

            // Act
            var results = ((IEnumerable<string>)controller.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(3, results.Length);
            Assert.AreEqual("Apples", results[0]);
            Assert.AreEqual("Oranges", results[1]);
            Assert.AreEqual("Plums", results[2]);
        }

        [TestMethod]
        public void Indicates_Selected_Category()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1", Category = "Apples" }, 
                        new Product { ProductId = 2, Name = "P2", Category = "Oranges" }
                    });

            var controller = new NavController(mock.Object);
            const string categoryToSelect = "Apples";

            // Act
            var selectedCategory = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assert
            Assert.AreEqual(categoryToSelect, selectedCategory);
        }
    }
}
