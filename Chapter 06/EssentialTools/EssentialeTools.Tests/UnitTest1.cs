using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialeTools.Tests
{
    using System;
    using EssentialTools.Models;

    [TestClass]
    public class UnitTest1
    {
        IDiscountHelper GetTestObject()
        {
            return new MinimumDiscountHelper();
        }

        [TestMethod]
        public void Discount_Above_100()
        {
            // arrange
            var target = GetTestObject();
            const decimal total = 200;

            // act
            var discountedTotal = target.ApplyDiscount(total);

            //assert
            Assert.AreEqual(total * 0.9M, discountedTotal);
        }

        [TestMethod]
        public void Discount_Between_10_And_100()
        {
            // arrange
            var target = GetTestObject();

            // act
            var tenDollarDiscount = target.ApplyDiscount(10);
            var hundredDollarDiscount = target.ApplyDiscount(100);
            var fiftyDollarDiscount = target.ApplyDiscount(50);

            //assert
            Assert.AreEqual(5, tenDollarDiscount);
            Assert.AreEqual(95, hundredDollarDiscount);
            Assert.AreEqual(45, fiftyDollarDiscount);
        }

        [TestMethod]
        public void Discount_Less_Than_10()
        {
            // arrange
            var target = GetTestObject();

            // act
            var discount5 = target.ApplyDiscount(5);
            var discount0 = target.ApplyDiscount(0);

            //assert
            Assert.AreEqual(5, discount5);
            Assert.AreEqual(0, discount0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Discount_Negative_Total()
        {
            // arrange
            var target = GetTestObject();

            // act
            target.ApplyDiscount(-1);
        }
    }
}
