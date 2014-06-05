/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace SportsStore.Domain.Abstract
{
    using System.Collections.Generic;
    using SportsStore.Domain.Entities;

    public interface IProductsRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
