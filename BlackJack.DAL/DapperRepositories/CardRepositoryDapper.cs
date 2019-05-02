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
    class CardRepositoryDapper : ICardRepository
    {
        private string _connectionString = null;
        public CardRepositoryDapper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Card GetCard(int cardId)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Card>("SELECT * FROM Cards WHERE CardId = @cardId", new { cardId }).FirstOrDefault();
            }
        }
    }
}
