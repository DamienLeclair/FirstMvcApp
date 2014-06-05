using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialeTools.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EssentialTools.Models;
    using Moq;

    [TestClass]
    public class UnitTest2
    {
        readonly Product[] products =
        {
            new Product { Name = "Kayak", Category = "Watersports", Price = 275M },
            new Product { Name = "Lifejacket", Category = "Watersports", Price = 48.95M },
            new Product { Name = "Soccer ball", Category = "Soccer", Price = 19.50M },
            new Product { Name = "Corner flag", Category = "Soccer", Price = 34.95M }
        };

        [TestMethod]
        public void Sum_Products_Correctly()
        {
            // arrange
            //var discounter = new MinimumDiscountHelper();
            //var target = new LinqValueCalculator(discounter);
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>()))
                .Returns<decimal>(total => total);
            var target = new LinqValueCalculator(mock.Object);

            // act
            var result = target.ValueProducts(products);

            // assert
            Assert.AreEqual(products.Sum(p => p.Price), result);
        }

        IEnumerable<Product> CreateProduct(decimal value)
        {
            return new[] { new Product { Price = value } };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Pass_Trough_Variable_Discounts()
        {
            // arrange
            var mock = new Mock<IDiscountHelper>();
            mock.Setup(m => m.ApplyDiscount(It.IsAny<decimal>())).Returns<decimal>(total => total);
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v == 0))).Throws<ArgumentOutOfRangeException>();
            mock.Setup(m => m.ApplyDiscount(It.Is<decimal>(v => v > 100))).Returns<decimal>(total => total * 0.9M);
            mock.Setup(m => m.ApplyDiscount(It.IsInRange(10, 100, Range.Exclusive))).Returns<decimal>(total => total - 5);
            var target = new LinqValueCalculator(mock.Object);

            // act
            var fiveDollarDiscount = target.ValueProducts(CreateProduct(5));
            var tenDollarDiscount = target.ValueProducts(CreateProduct(10));
            var fiftyDollarDiscount = target.ValueProducts(CreateProduct(50));
            var hundredDollarDiscount = target.ValueProducts(CreateProduct(100));
            var fiveHundredDollarDiscount = target.ValueProducts(CreateProduct(500));

            // assert
            Assert.AreEqual(5, fiveDollarDiscount);
            Assert.AreEqual(10, tenDollarDiscount);
            Assert.AreEqual(50, fiftyDollarDiscount);
            Assert.AreEqual(100, hundredDollarDiscount);
            Assert.AreEqual(500, fiveHundredDollarDiscount);

        }
    }
}
