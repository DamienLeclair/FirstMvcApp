using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SportsStore.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using Moq;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;
    using SportsStore.WebUI.Controllers;
    using SportsStore.WebUI.HtmlHelpers;
    using SportsStore.WebUI.Models;

    [TestClass]
    public class UnitTest1
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
            var result = (ProductListViewModel)controller.List(2).Model;

            // Assert
            var products = result.Products.ToArray();
            Assert.IsTrue(products.Length == 2);
            Assert.AreEqual("P4", products[0].Name);
            Assert.AreEqual("P5", products[1].Name);
        }

        //[TestMethod]
        //public void Can_Generate_Page_Links()
        //{
        //    // Arrange
        //    HtmlHelper myHelper = null;
        //    var pagingInfo = new PagingInfo { CurrentPage = 2, ItemsPerPage = 10, TotalItems = 28 };
        //    Func<int, string> pageUrlDelegate = i => "Page" + i;

        //    // Act
        //    var result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

        //    // Assert
        //    Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
        //        + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
        //        + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
        //        result.ToString());
        //}

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
            var result = (ProductListViewModel)controller.List(2).Model;

            // Assert
            var pagingInfo = result.PagingInfo;
            Assert.AreEqual(2, pagingInfo.CurrentPage);
            Assert.AreEqual(3, pagingInfo.ItemsPerPage);
            Assert.AreEqual(5, pagingInfo.TotalItems);
            Assert.AreEqual(2, pagingInfo.TotalPages);
        }
    }
}
