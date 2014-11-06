namespace SportsStore.Domain.Abstract
{
    using System.Collections.Generic;
    using SportsStore.Domain.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }

        void SaveProduct(Product product);
    }
}
