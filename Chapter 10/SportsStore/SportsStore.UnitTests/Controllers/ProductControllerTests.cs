using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportsStore.UnitTests
{
    using System.Linq;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;
    using SportsStore.WebUI.Models;

    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1" }, 
                        new Product { ProductId = 2, Name = "P2" },
                        new Product { ProductId = 3, Name = "P3" }, 
                        new Product { ProductId = 4, Name = "P4" },
                        new Product { ProductId = 5, Name = "P5" }
                    });

            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            var products = result.Products.ToArray();
            Assert.IsTrue(products.Length == 2);
            Assert.AreEqual("P4", products[0].Name);
            Assert.AreEqual("P5", products[1].Name);
        }

        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1" }, 
                        new Product { ProductId = 2, Name = "P2" },
                        new Product { ProductId = 3, Name = "P3" }, 
                        new Product { ProductId = 4, Name = "P4" },
                        new Product { ProductId = 5, Name = "P5" }
                    });
            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var result = (ProductsListViewModel)controller.List(null, 2).Model;

            // Assert
            var pagingInfo = result.PagingInfo;
            Assert.AreEqual(2, pagingInfo.CurrentPage);
            Assert.AreEqual(3, pagingInfo.ItemsPerPage);
            Assert.AreEqual(5, pagingInfo.TotalItems);
            Assert.AreEqual(2, pagingInfo.TotalPages);
        }

        [TestMethod]
        public void Can_Filter_Products()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1", Category = "Cat1" }, 
                        new Product { ProductId = 2, Name = "P2", Category = "Cat2" },
                        new Product { ProductId = 3, Name = "P3", Category = "Cat1" }, 
                        new Product { ProductId = 4, Name = "P4", Category = "Cat2" },
                        new Product { ProductId = 5, Name = "P5", Category = "Cat3" }
                    });
            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var result = (ProductsListViewModel)controller.List("Cat2").Model;

            // Assert
            var products = result.Products.ToArray();
            Assert.AreEqual(2, products.Length);
            Assert.IsTrue(products[0].Name == "P2" && products[0].Category == "Cat2");
            Assert.IsTrue(products[1].Name == "P4" && products[1].Category == "Cat2");
        }

        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            // Arrange
            var mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new[]
                    {
                        new Product { ProductId = 1, Name = "P1", Category = "Cat1" }, 
                        new Product { ProductId = 2, Name = "P2", Category = "Cat2" },
                        new Product { ProductId = 3, Name = "P3", Category = "Cat1" }, 
                        new Product { ProductId = 4, Name = "P4", Category = "Cat2" },
                        new Product { ProductId = 5, Name = "P5", Category = "Cat3" }
                    });
            var controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            var res1 = ((ProductsListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            var res2 = ((ProductsListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            var res3 = ((ProductsListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            var resAll = ((ProductsListViewModel)controller.List().Model).PagingInfo.TotalItems;

            // Assert
            Assert.AreEqual(2, res1);
            Assert.AreEqual(2, res2);
            Assert.AreEqual(1, res3);
            Assert.AreEqual(5, resAll);
        }
    }
}
