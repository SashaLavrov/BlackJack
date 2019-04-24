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
    public class ComboCardService : IComboCardService
    {
        private IRepository<ComboCard> _db;
        public ComboCardService(IRepository<ComboCard> db)
        {
            _db = db;
        }

        public void AddComboCard(ComboCardDTO comboCard)
        {
            if (comboCard != null)
            {
                ComboCard temp = new ComboCard
                {
                    CardId = comboCard.CardId,
                    CombinationId = comboCard.CombinationId
                };
                _db.Create(temp);
            }
        }

        public IEnumerable<ComboCardDTO> ComboCards()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<ComboCard, ComboCardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<ComboCard>, List<ComboCardDTO>>(_db.GetAll());
        }

        public bool EditComboCard(ComboCardDTO comboCard)
        {
            if (comboCard == null)
            {
                return false;
            }
            ComboCard temp = new ComboCard
            {
                CardId = comboCard.CardId,
                CombinationId = comboCard.CombinationId,
                ComboCardId = comboCard.ComboCardId
            };
            _db.Update(temp);
            return true;
        }

        public ComboCardDTO Get(int id)
        {
            var res = _db.Get(id);
            return new ComboCardDTO
            {
                CardId = res.CardId,
                CombinationId = res.CombinationId,
                ComboCardId = res.ComboCardId
            };
        }

        public bool RemoveComboCard(int comboCardId)
        {
            if (_db.Get(comboCardId) == null)
            {
                return false;
            }
            _db.Delete(comboCardId);
            return true;
        }
    }
}
