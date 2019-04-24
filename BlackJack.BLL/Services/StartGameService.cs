using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class StartGameService : IStartGameService
    {
        private IRepository<Game> _dbGame;
        private IRepository<Round> _dbRound;
        private IRepository<Combination> _dbCombination;
        private IRepository<ComboCard> _dbComboCard;
        private IRepository<Card> _dbCard;

        public StartGameService(IRepository<Game> dbGame,
            IRepository<Round> dbRound,
            IRepository<Combination> dbCombination,
            IRepository<ComboCard> dbComboCard,
            IRepository<Card> dbCard)
        {
            _dbGame = dbGame;
            _dbRound = dbRound;
            _dbCombination = dbCombination;
            _dbComboCard = dbComboCard;
            _dbCard = dbCard;
        }

        public void StartNewGame(int botsCount, string userId)
        {
            InitialCombination(StartFirsRound(StartGame()), userId);
        }

        private int StartGame()
        {
            var game = new Game { GameDate = DateTime.Now };
            int gameId = _dbGame.Create(game);
            return gameId;
        }
        private int StartFirsRound(int gameId)
        {
            var firstRound = new Round { GameId = gameId };
            int roundId = _dbRound.Create(firstRound);
            return roundId;
        }

        private void InitialCombination(int roundId, string userId)
        {
            var combination = new Combination { RoundId = roundId, UserId = userId };
            int combinationId = _dbCombination.Create(combination);
            GetCard(combinationId);
            GetCard(combinationId);
        }

        private void GetCard(int combinationId)
        {
            var comboCard = new ComboCard
            {
                CardId = GetRandomCard().CardId,
                CombinationId = combinationId
            };
            _dbComboCard.Create(comboCard);
        }

        private Card GetRandomCard()
        {
            Random random = new Random();
            var cardId = random.Next(2, 53);
            var randomCard = _dbCard.Get(cardId);
            return randomCard;
        }
    }
}
