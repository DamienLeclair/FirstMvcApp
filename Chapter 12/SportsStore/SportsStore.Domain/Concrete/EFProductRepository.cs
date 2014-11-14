namespace SportsStore.Domain.Concrete
{
    using System.Collections.Generic;
    using SportsStore.Domain.Abstract;
    using SportsStore.Domain.Entities;

    public class EFProductRepository : IProductsRepository
    {
        readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                var dbEntry = context.Products.Find(product.ProductId);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                    dbEntry.ImageData = product.ImageData;
                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var dbEntry = context.Products.Find(productId);
            
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }

            return dbEntry;
        }
    }
}
