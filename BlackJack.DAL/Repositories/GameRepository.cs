using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    class GameRepository : IRepository<Game>
    {
        private ApplicationContext _db;

        public GameRepository(ApplicationContext context)
        {
            _db = context;
        }
        public void Create(Game item)
        {
            _db.Games.Add(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Game game = _db.Games.Find(id);
            if (game != null)
            {
                _db.Games.Remove(game);
                _db.SaveChanges();
            }
        }
        public Game Get(int id) => _db.Games.Find(id);

        public IEnumerable<Game> GetAll() => _db.Games.ToList();

        public void Update(Game item)
        {
            var oldGame = _db.Games.Find(item.GameId);
            if (oldGame == null)
            _db.Entry(oldGame).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
