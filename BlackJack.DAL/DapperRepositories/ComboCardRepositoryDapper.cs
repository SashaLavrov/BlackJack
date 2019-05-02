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
    class ComboCardRepositoryDapper : IRepository<ComboCard>
    {
        private string _connectionString = null;
        public ComboCardRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Create(ComboCard item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO ComboCards (CombinationId, CardId) VALUES(@CombinationId, @CardId); " +
                    "SELECT CAST(SCOPE_IDENTITY() as int)";
                int? combinationId = db.Query<int>(sqlQuery, item).FirstOrDefault();
                return item.CombinationId = combinationId.Value;
            }
        }

        public ComboCard Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ComboCard>("SELECT * FROM ComboCards WHERE ComboCardsId = @id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<ComboCard> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<ComboCard>("SELECT * FROM ComboCards");
            }
        }

        public void Update(ComboCard item)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE ComboCards SET CombinationId = @CombinationId, CardId = @CardId WHERE ComboCardsId = @ComboCardsId";
                db.Execute(sqlQuery, item);
            }
        }
    }
}
