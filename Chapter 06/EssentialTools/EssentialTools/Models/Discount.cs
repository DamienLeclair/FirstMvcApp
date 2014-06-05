using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal total);
    }

    public class DefaultDiscountHelper : IDiscountHelper
    {
        decimal discountSize;

        public DefaultDiscountHelper(decimal discountSize)
        {
            this.discountSize = discountSize;
        }

        public decimal DiscountSize
        {
            get { return discountSize; }
            set { discountSize = value; }
        }

        public decimal ApplyDiscount(decimal total)
        {
            return (total - (DiscountSize / 100m * total));
        }
    }
}