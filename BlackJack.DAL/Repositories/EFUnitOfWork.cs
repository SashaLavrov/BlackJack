using BlackJack.DAL.DataEF;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Repositories
{
    class EFUnitOfWork// : IUnitOfWork
    {
        private ApplicationContext _db;
        private GameRepository _gameRepository;
        private RoundRepository _roundRepository;
        private CombinationRepository _CombinationRepository;
        private ComboCardRepository _comboCardRepository;
        private CardRepository _cardRepository;
    }
}
