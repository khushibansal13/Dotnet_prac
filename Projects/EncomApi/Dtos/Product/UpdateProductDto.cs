using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncomApi.Dtos.Product
{
    public class UpdateProductDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}