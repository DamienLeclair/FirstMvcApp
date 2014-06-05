/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace EssentialTools.Models
{
    using System.Collections.Generic;

    public interface IValueCalculator
    {
        decimal ValueProducts(IEnumerable<Product> products);
    }
}
