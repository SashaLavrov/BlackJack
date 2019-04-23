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
    public class CardService : ICardService
    {
        private IRepository<Card> _db;
        public CardService(IRepository<Card> db)
        {
            _db = db;
        }

        public void AddCard(CardDTO card)
        {
            if (card != null)
            {
                Card temp = new Card
                {
                    Type = card.Type,
                    Value = card.Value,
                    Suit = card.Suit
                };
                _db.Create(temp);
                _db.Save();
            }
        }

        public bool EditCard(CardDTO card)
        {
            if (card == null)
            {
                return false;
            }
            Card temp = new Card
            {
                CardId = card.CardId,
                Type = card.Type,
                Value = card.Value,
                Suit = card.Suit
            };
            _db.Update(temp);
            _db.Save();
            return true;
        }

        public CardDTO Get(int id)
        {
            var res = _db.Get(id);
            return new CardDTO
            {
                CardId = res.CardId,
                Type = res.Type,
                Value = res.Value,
                Suit = res.Suit
            };
        }

        public IEnumerable<CardDTO> GetCards()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Card>, List<CardDTO>>(_db.GetAll());
        }

        public bool RemoveCard(int cardId)
        {
            if (_db.Get(cardId) == null)
            {
                return false;
            }
            _db.Delete(cardId);
            _db.Save();
            return true;
        }
    }
}
