using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncomApi.Models
{
    public class MyRateLimitOptions
    {
        public int PermitLimit { get; set; } // Global limit for all endpoints
        public int Window { get; set; } // Global window in seconds
        public int QueueLimit { get; set; } // Global queue limit
        public int ProductAddPermitLimit { get; set; } // For POST /api/products/add
        public int ProductAddWindow { get; set; }
        public int ProductAddQueueLimit { get; set; }
        public int ProductUpdatePermitLimit { get; set; } // For PUT /api/products/{id}
        public int ProductUpdateWindow { get; set; }
        public int ProductUpdateQueueLimit { get; set; }
        public int ProductDeletePermitLimit { get; set; } // For DELETE /api/products/{id}
        public int ProductDeleteWindow { get; set; }
        public int ProductDeleteQueueLimit { get; set; }
    }
}