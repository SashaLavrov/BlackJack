using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : ICardRepository
    {
        private ApplicationContext _db;

        public CardRepository(ApplicationContext context)
        {
            _db = context;
        }

        public Card GetCard(int cardId)
        {
            return _db.Cards.Where(x => x.CardId == cardId).FirstOrDefault();
        }
    }
}
