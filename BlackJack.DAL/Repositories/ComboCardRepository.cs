using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class ComboCardRepository : IRepository<ComboCard>
    {
        private ApplicationContext _db;

        public ComboCardRepository(ApplicationContext context)
        {
            _db = context;
        }

        public void Create(ComboCard item)
        {
            _db.ComboCards.Add(item);
        }

        public void Delete(int id)
        {
            ComboCard comboCard = _db.ComboCards.Find(id);
            if (comboCard != null)
            {
                _db.ComboCards.Remove(comboCard);
            }
        }
        public ComboCard Get(int id) => _db.ComboCards.Find(id);

        public IEnumerable<ComboCard> GetAll() => _db.ComboCards.ToList();

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(ComboCard item)
        {
            var oldComboCard = _db.ComboCards.Find(item.ComboCardId);
            if (oldComboCard == null)
            {
                _db.Entry(oldComboCard).CurrentValues.SetValues(item);
            }     
        }
    }
}
