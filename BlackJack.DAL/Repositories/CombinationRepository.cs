using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class CombinationRepository : IRepository<Combination>
    {
        private ApplicationContext _db;

        public CombinationRepository(ApplicationContext context)
        {
            _db = context;
        }

        public int Create(Combination item)
        {
            _db.Combinations.Add(item);
            _db.SaveChanges();
            return item.CombinationId;
        }

        public void Delete(int id)
        {
            Combination combination = _db.Combinations.Find(id);
            if (combination != null)
            {
                _db.Combinations.Remove(combination);
                _db.SaveChanges();
            }
        }
        public Combination Get(int id) => _db.Combinations.Find(id);

        public IEnumerable<Combination> GetAll() => _db.Combinations.ToList();

        public void Update(Combination item)
        {
            var oldCombination = _db.Combinations.Find(item.CombinationId);
            if (oldCombination == null)
            {
                _db.Entry(oldCombination).CurrentValues.SetValues(item);
                _db.SaveChanges();
            }
        }
    }
}
