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
    class GameRepositoryDapper : IRepository<Game>
    {
        private string _connectionString = null;

        public GameRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public int Create(Game item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Games (GameDate) VALUES(@GameDate); " +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                int? combinationId = db.Query<int>(sqlQuery, item).FirstOrDefault();
                return item.GameId = combinationId.Value;
            }
        }

        public Game Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Game>("SELECT * FROM Games WHERE GameId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Game> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Game>("SELECT * FROM Games");
            }
        }

        public void Update(Game item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Games SET GameDate = @GameDate WHERE GameId = @GameId";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
