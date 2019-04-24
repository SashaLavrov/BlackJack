using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.BLL.Services
{
    public class StartGameService : IStartGameService
    {
        private IRepository<Game> _dbGame;
        private IRepository<Round> _dbRound;
        private IRepository<Combination> _dbCombination;
        private IRepository<ComboCard> _dbComboCard;
        private ICardRepository _dbCard;
        private IUserRepository _dbUser;

        public StartGameService(IRepository<Game> dbGame,
            IRepository<Round> dbRound,
            IRepository<Combination> dbCombination,
            IRepository<ComboCard> dbComboCard,
            ICardRepository dbCard,
            IUserRepository dbUser)
        {
            _dbGame = dbGame;
            _dbRound = dbRound;
            _dbCombination = dbCombination;
            _dbComboCard = dbComboCard;
            _dbCard = dbCard;
            _dbUser = dbUser;
        }

        public /*CurrentGameState*/void StartNewGame(int botsCount, int userId)
        {
            int gameId = InitialGame();

            AddBotToGame(gameId, botsCount);

            int combinationId = InitialCombination(InitialRound(gameId), userId);
            GiveCard(combinationId, GetRandomCard().CardId);
            GiveCard(combinationId, GetRandomCard().CardId);

            
        }

        private void AddBotToGame(int gameId, int botsCount)
        {
            int maxBotCount = 8;

            if(botsCount > maxBotCount)
            {
                botsCount = maxBotCount;
            }
            else if(botsCount < 0)
            {
                botsCount = 0;
            }

        }

        private int InitialPlayer(string playerName)
        {
            var player = _dbUser.GetAll().Where(x => x.Nickname == playerName && x.IsBot == false).FirstOrDefault();

            if (player == null)
            {
                return _dbUser.Create(playerName);
            }
            else
            {
                return player.UserId;
            }
        }

        private int InitialGame()
        {
            return _dbGame.Create(new Game { GameDate = DateTime.Now });
        }

        private int InitialRound(int gameId)
        {
            return _dbRound.Create(new Round { GameId = gameId });
        }

        private Card GetRandomCard()
        {
            Random random = new Random();
            int cardId = random.Next(2, 53);
            return _dbCard.GetCard(cardId);
        }

        private int InitialCombination(int roundId, int playerId)
        {
            return _dbCombination.Create(new Combination { RoundId = roundId, UserId = playerId });
        }

        private int GiveCard(int combinationId, int cardId)
        {
            return _dbComboCard.Create(new ComboCard { CombinationId = combinationId, CardId = cardId });
        }
    }
}
