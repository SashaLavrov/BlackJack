using BlackJack.BLL.Interfaces;
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
        private IRepository<Game> _gameRepository;
        private IRepository<Round> _roundRepository;
        private IRepository<Combination> _combinationRepository;
        private IRepository<ComboCard> _comboCardRepository;
        private ICardRepository _cardRepository;
        private IUserRepository _userRepository;

        public StartGameService(IRepository<Game> gameRepository,
            IRepository<Round> roundRepository,
            IRepository<Combination> combinationRepository,
            IRepository<ComboCard> comboCardRepository,
            ICardRepository cardRepository,
            IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _combinationRepository = combinationRepository;
            _comboCardRepository = comboCardRepository;
            _cardRepository = cardRepository;
            _userRepository = userRepository;
        }

        public int StartNewGame(int botsCount, string userName)
        {
            int gameId = InitializationGame();
            int roundId = InitializationRound(gameId);

            AddBotsToGame(botsCount, roundId);
            AddDealer(roundId);
            InitializationPlayerState(InitializationPlayer(userName), roundId);

            return gameId;
        }
        private void AddDealer(int roundId)
        {
            int dealerId = 1;
            InitializationPlayerState(dealerId, roundId);
        }
        private void InitializationPlayerState(int userId, int roundId)
        {
            int combinationId = InitializationCombination(roundId, userId);

            List<Card> card = new List<Card>();

            var randomCard = GetRandomCard();
            card.Add(randomCard);
            GiveCard(combinationId, randomCard.CardId);

            randomCard = GetRandomCard();
            card.Add(randomCard);
            GiveCard(combinationId, GetRandomCard().CardId);
        }

        private IEnumerable<User> AddBotsToGame(int botsCount, int roundId)
        {
            int maxBotCount = 6;

            if (botsCount > maxBotCount)
            {
                botsCount = maxBotCount;
            }
            else if(botsCount < 0)
            {
                botsCount = 0;
            }

            List<User> bots = _userRepository.GetAll().Where(x => x.IsBot).ToList();

            for (int i = 0; i < botsCount; i++)
            {
                InitializationPlayerState(bots[i].UserId, roundId);
            }

            return bots;
        }

        private int InitializationPlayer(string playerName)
        {
            var player = _userRepository.GetAll().Where(x => x.Nickname == playerName && x.IsBot == false).FirstOrDefault();

            if (player == null)
            {
                return _userRepository.Create(playerName);
            }
            else
            {
                return player.UserId;
            }
        }

        private int InitializationGame()
        {
            return _gameRepository.Create(new Game { GameDate = DateTime.Now });
        }

        private int InitializationRound(int gameId)
        {
            return _roundRepository.Create(new Round { GameId = gameId});
        }

        private Card GetRandomCard()
        {
            Random random = new Random();
            int cardId = random.Next(2, 53);
            return _cardRepository.GetCard(cardId);
        }

        private int InitializationCombination(int roundId, int playerId)
        {
            return _combinationRepository.Create(new Combination { RoundId = roundId, UserId = playerId });
        }

        private int GiveCard(int combinationId, int cardId)
        {
            return _comboCardRepository.Create(new ComboCard { CombinationId = combinationId, CardId = cardId });
        }
    }
}
