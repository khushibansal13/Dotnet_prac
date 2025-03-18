using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncomApi.Services
{
    public class DatabaseConfig
    {
        private readonly IConfiguration _configuration;
        public DatabaseConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }
    }
}