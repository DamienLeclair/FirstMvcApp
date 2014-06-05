namespace SportsStore.Domain.Entities
{
    using System.Collections.Generic;
    using System.Linq;

    public class Cart
    {
        readonly List<CartLine> lineCollection = new List<CartLine>();

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

        public void AddItem(Product product, int quantity)
        {
            var existingLine = lineCollection.FirstOrDefault(x => x.Product.ProductId == product.ProductId);

            if (existingLine == null)
            {
                lineCollection.Add(new CartLine{Product = product, Quantity = quantity});
            }
            else
            {
                existingLine.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(x => x.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
    }
}
