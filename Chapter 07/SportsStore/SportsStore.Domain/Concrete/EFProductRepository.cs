/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
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
    }
}
