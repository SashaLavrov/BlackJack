using BlackJack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface ICardService
    {
        CardDTO Get(int id);

        void AddCard(CardDTO card);

        bool EditCard(CardDTO card);

        bool RemoveCard(int cardId);

        IEnumerable<CardDTO> GetCards();
    }
}
