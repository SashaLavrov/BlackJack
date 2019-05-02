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
    class CombinationRepositoryDapper : IRepository<Combination>
    {
        private string _connectionString = null;
        public CombinationRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(Combination item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Combinations (RoundId, UserId) VALUES(@RoundId, @UserId); SELECT CAST(SCOPE_IDENTITY() as int)";
                int? combinationId = db.Query<int>(sqlQuery, item).FirstOrDefault();
                return item.CombinationId = combinationId.Value;
            }
        }

        public Combination Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Combination>("SELECT * FROM Combinations WHERE CombinationId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Combination> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Combination>("SELECT * FROM Combinations");
            }
        }

        public void Update(Combination item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Combinations SET RoundId = @RoundId, UserId = @UserId WHERE CombinationId = @CombinationId";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
