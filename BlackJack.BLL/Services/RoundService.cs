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
    public class RoundService : IRoundService
    {
        private IRepository<Round> _db;
        public RoundService(IRepository<Round> db)
        {
            _db = db;
        }

        public void AddRound(RoundDTO round)
        {
            if (round != null)
            {
                Round temp = new Round
                {
                    GameId = round.GameId,
                    RoundId = round.RoundId
                };
                _db.Create(temp);
                _db.Save();
            }
        }

        public bool EditRound(RoundDTO round)
        {
            if (round == null)
            {
                return false;
            }
            Round temp = new Round
            {
                GameId = round.GameId,
                RoundId = round.RoundId
            };
            _db.Update(temp);
            _db.Save();
            return true;
        }

        public RoundDTO Get(int id)
        {
            var res = _db.Get(id);
            return new RoundDTO
            {
                GameId = res.GameId,
                RoundId = res.RoundId
            };
        }

        public IEnumerable<RoundDTO> GetRounds()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Round, RoundDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Round>, List<RoundDTO>>(_db.GetAll());
        }

        public bool RemoveRound(int roundId)
        {
            if (_db.Get(roundId) == null)
            {
                return false;
            }
            _db.Delete(roundId);
            _db.Save();
            return true;
        }
    }
}
