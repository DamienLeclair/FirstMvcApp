/*
 * This file is part of the Satimo Software Framework
 *
 * Copyright © Satimo 2014 All Rights Reserved, http://satimo.fr/
 */
namespace SportsStore.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
