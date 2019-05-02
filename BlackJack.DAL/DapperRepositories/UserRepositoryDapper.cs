using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.DapperRepositories
{
    class UserRepositoryDapper : IUserRepository
    {
        private string _connectionString = null;
        public UserRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(string name)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                User user = new User
                {
                    IsBot = false,
                    Nickname = name
                };
                var sqlQuery = "INSERT INTO Users (Nickname, IsBot) VALUES(@Nickname, @IsBot); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                return user.UserId = userId.Value;
            }
        }

        public User Get(int userId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE UserId = @userId", new { userId }).FirstOrDefault();
            }
        }

        public User Get(string userName)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE UserName = @userName", new { userName }).FirstOrDefault();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<User>("SELECT * FROM Users");
            }
        }
    }
}
