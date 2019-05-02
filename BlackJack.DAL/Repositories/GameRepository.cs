using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private ApplicationContext _db;

        public GameRepository(ApplicationContext context)
        {
            _db = context;
        }
        public int Create(Game item)
        {
            _db.Games.Add(item);
            _db.SaveChanges();
            return item.GameId;
        }

        public Game Get(int id) => _db.Games.Find(id);

        public IEnumerable<Game> GetAll() => _db.Games.ToList();

        public void Update(Game item)
        {
            var oldGame = _db.Games.Find(item.GameId);
            if (oldGame == null)
            {
                _db.Entry(oldGame).CurrentValues.SetValues(item);
                _db.SaveChanges();
            }
        }
    }
}
