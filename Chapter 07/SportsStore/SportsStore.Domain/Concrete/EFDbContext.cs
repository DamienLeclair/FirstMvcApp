/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace SportsStore.Domain.Concrete
{
    using System.Data.Entity;
    using SportsStore.Domain.Entities;

    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
