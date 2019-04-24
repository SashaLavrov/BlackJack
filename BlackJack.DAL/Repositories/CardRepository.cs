using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class CardRepository : IRepository<Card>
    {
        private ApplicationContext _db;

        public CardRepository(ApplicationContext context)
        {
            _db = context;
        }

        public int Create(Card item)
        {
            _db.Cards.Add(item);
            _db.SaveChanges();
            return item.CardId;
        }

        public void Delete(int id)
        {
            Card card = _db.Cards.Find(id);
            if (card != null)
            {
                _db.Cards.Remove(card);
                _db.SaveChanges();
            }
        }
        public Card Get(int id) => _db.Cards.Find(id);

        public IEnumerable<Card> GetAll() => _db.Cards.ToList();

        public void Update(Card item)
        {
            var oldCard = _db.Cards.Find(item.CardId);
            if (oldCard == null)
            {
                _db.Entry(oldCard).CurrentValues.SetValues(item);
                _db.SaveChanges();
            }
        }
    }
}
