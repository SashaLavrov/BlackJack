using BlackJack.BLL.DTO;
using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    class CardService : ICardService
    {
        private IRepository<Card> _db;
        public CardService(IRepository<Card> db)
        {
            _db = db;
        }
        public CardDTO Get(int id)
        {
            var res = _db.Get(id);
            return new CardDTO
            {
                CardId = res.CardId,
                Type = res.Type,
                Valye = res.Valye
            };
        }

    }
}
