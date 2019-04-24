using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Interfaces
{
    public interface ICardRepository
    {
        Card GetCard(int cardId);
    }
}
