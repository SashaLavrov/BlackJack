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
    class RoundRepositoryDapper : IRepository<Round>
    {
        private string _connectionString = null;
        public RoundRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(Round item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Rounds (Roundnumber, GameId) VALUES(@Roundnumber, @GameId); " +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                int? combinationId = db.Query<int>(sqlQuery, item).FirstOrDefault();
                return item.GameId = combinationId.Value;
            }
        }

        public Round Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Round>("SELECT * FROM Rounds WHERE RoundId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Round> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Round>("SELECT * FROM Rounds");
            }
        }

        public void Update(Round item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Rounds SET Roundnumber = @Roundnumber, GameId = @GameId WHERE RoundId = @RoundId";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
