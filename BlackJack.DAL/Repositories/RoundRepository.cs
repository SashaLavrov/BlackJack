using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class RoundRepository : IRepository<Round>
    {
        private ApplicationContext _db;

        public RoundRepository(ApplicationContext context)
        {
            _db = context;
        }
        public void Create(Round item)
        {
            _db.Rounds.Add(item);
        }

        public void Delete(int id)
        {
            Round round = _db.Rounds.Find(id);
            if (round != null)
            {
                _db.Rounds.Remove(round);
            }
        }
        public Round Get(int id) => _db.Rounds.Find(id);

        public IEnumerable<Round> GetAll() => _db.Rounds.ToList();

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Round item)
        {
            var oldRound = _db.Rounds.Find(item.RoundId);
            if (oldRound == null)
            {
                _db.Entry(oldRound).CurrentValues.SetValues(item);
            }
        }
    }
}
