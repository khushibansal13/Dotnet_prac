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
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(DatabaseConfig dbConfig)
        {
            _connectionString = dbConfig.GetConnectionString();
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT * FROM Users WHERE Email = @Email";
            var user = await connection.QueryFirstOrDefaultAsync<User>(sql, new{
                Email = email
            });
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public async Task<User> RegisterUserAsync(User user, string password)
        {
            using var connection = new MySqlConnection(_connectionString);

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);

            var sql = @"
                INSERT INTO Users (Username, Email, PasswordHash, ProfilePictureUrl, CreatedAt)
                VALUES (@Username, @Email, @PasswordHash, @ProfilePictureUrl, @CreatedAt);
                SELECT LAST_INSERT_ID();";

            var id = await connection.QuerySingleAsync<int>(sql, new{
                user.Username,
                user.Email,
                user.PasswordHash,
                user.ProfilePictureUrl,
                CreatedAt = DateTime.UtcNow
            });
            user.Id = id;
            return user;
        }

        public bool VerifyPassword(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        }
    }
}