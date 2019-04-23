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
    public class CombinationService : ICombinationService
    {
        private IRepository<Combination> _db;

        public CombinationService(IRepository<Combination> db)
        {
            _db = db;
        }
        public void AddCombination(CombinationDTO combination)
        {
            if (combination != null)
            {
                Combination temp = new Combination
                {
                    RoundId = combination.RoundId,
                    UserId = combination.UserId
                };
                _db.Create(temp);
                _db.Save();
            }
        }

        public bool EditCombination(CombinationDTO combination)
        {
            if (combination == null)
            {
                return false;
            }
            Combination temp = new Combination
            {
                CombinationId = combination.CombinationId,
                RoundId = combination.RoundId,
                UserId = combination.UserId
            };
            _db.Update(temp);
            _db.Save();
            return true;
        }

        public CombinationDTO Get(int id)
        {
            var res = _db.Get(id);
            return new CombinationDTO
            {
                CombinationId = res.CombinationId,
                RoundId = res.RoundId,
                UserId = res.UserId
            };
        }

        public IEnumerable<CombinationDTO> GetCombinations()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Combination, CombinationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Combination>, List<CombinationDTO>>(_db.GetAll());
        }

        public bool RemoveCombination(int combinationId)
        {
            if (_db.Get(combinationId) == null)
            {
                return false;
            }
            _db.Delete(combinationId);
            _db.Save();
            return true;
        }
    }
}
