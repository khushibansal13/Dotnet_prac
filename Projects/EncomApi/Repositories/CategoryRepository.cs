using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using EncomApi.Interfaces;
using EncomApi.Models;
using EncomApi.Services;
using MySql.Data.MySqlClient;

namespace EncomApi.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(DatabaseConfig dbConfig)
        {
            _connectionString = dbConfig.GetConnectionString();
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT Id, Name FROM Categories";
            var categories = await connection.QueryAsync<Category>(sql);
            return categories.AsList();
        }
    }
}