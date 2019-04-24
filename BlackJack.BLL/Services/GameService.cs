using AutoMapper;
using BlackJack.BLL.DTO;
using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class GameService : IGameService
    {
        private  IRepository<Game> _db;

        public GameService(IRepository<Game> db, IRepository<Round> dbRound)
        {
            _db = db;
    }
        public void AddGame(GameDTO game)
        {
            if (game != null)
            {
                Game temp = new Game
                {
                    GameDate = DateTime.Now,
                };
                _db.Create(temp);
            }
        }

        public bool EditGame(GameDTO game)
        {
            if (game == null)
            {
                return false;
            }
            Game temp = new Game
            {
                GameId = game.GameId,
                GameDate = game.GameDate
            };
            _db.Update(temp);
            return true;
        }

        public GameDTO Get(int id)
        {
            var res = _db.Get(id);
            return new GameDTO
            {
                GameDate = res.GameDate,
                GameId = res.GameId
            };
        }

        public IEnumerable<GameDTO> GetGames()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Game>, List<GameDTO>>(_db.GetAll());
        }

        public bool RemoveGame(int gameId)
        {
            if (_db.Get(gameId) == null)
            {
                return false;
            }
            _db.Delete(gameId);
            return true;
        }
    }
}
