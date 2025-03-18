using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncomApi.Dtos.Product
{
    public class CreateProductDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal DiscountPercentage { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string CategoryName { get; set; } = string.Empty;
    }
}