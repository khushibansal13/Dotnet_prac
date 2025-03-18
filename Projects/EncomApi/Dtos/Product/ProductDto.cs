using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EncomApi.Models;

namespace EncomApi.Dtos.Product
{
    public class ProductDto
    {
       public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal Rating { get; set; }
        public int Stock { get; set; }
        public List<string> Tags { get; set; } = new List<string>(); 
        public string Brand { get; set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public decimal Weight { get; set; }
        public Dimensions Dimensions { get; set; } 
        public string WarrantyInformation { get; set; } = string.Empty;
        public string ShippingInformation { get; set; } = string.Empty;
        public string AvailabilityStatus { get; set; } = string.Empty;
        public List<Review> Reviews { get; set; } = new List<Review>(); 
        public string ReturnPolicy { get; set; } = string.Empty;
        public int MinimumOrderQuantity { get; set; }
        public List<string> Images { get; set; } = new List<string>(); 
        public string Thumbnail { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}