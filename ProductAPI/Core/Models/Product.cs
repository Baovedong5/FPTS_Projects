﻿namespace ProductAPI.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int AvailableQuantity { get; set; }
    }
}
