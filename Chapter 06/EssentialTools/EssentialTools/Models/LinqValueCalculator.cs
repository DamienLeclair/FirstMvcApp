namespace EssentialTools.Models
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class LinqValueCalculator : IValueCalculator
    {
        static int counter;

        readonly IDiscountHelper discounter;

        public LinqValueCalculator(IDiscountHelper discounter)
        {
            this.discounter = discounter;
            Debug.WriteLine("Instance {0} created", ++counter);
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            var total = products.Sum(p => p.Price);

            return discounter.ApplyDiscount(total);
        }
    }
}