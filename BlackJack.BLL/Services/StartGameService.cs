using BlackJack.BLL.Constants;
using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private IGameService _gameService;

        public StartGameService(IRepository<Game> gameRepository,
            IRepository<Round> roundRepository,
            IRepository<Combination> combinationRepository,
            IRepository<ComboCard> comboCardRepository,
            ICardRepository cardRepository,
            IUserRepository userRepository,
            IGameService gameService)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _combinationRepository = combinationRepository;
            _comboCardRepository = comboCardRepository;
            _cardRepository = cardRepository;
            _userRepository = userRepository;
            _gameService = gameService;
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
            InitializationPlayerState(ConstantsValue.DealerId, roundId);
        }
        private void InitializationPlayerState(int userId, int roundId)
        {
            int combinationId = InitializationCombination(roundId, userId);

            var randomCard = _gameService.GetRandomCard();
            GiveCard(combinationId, randomCard.CardId);

            randomCard = _gameService.GetRandomCard();
            GiveCard(combinationId, randomCard.CardId);
        }

        private IEnumerable<User> AddBotsToGame(int botsCount, int roundId)
        {
            if (botsCount > ConstantsValue.MaxBotCount)
            {
                botsCount = ConstantsValue.MaxBotCount;
            }
            else if (botsCount < ConstantsValue.MinBotCount)
            {
                botsCount = ConstantsValue.MinBotCount;
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

            return player == null ? _userRepository.Create(playerName) : player.UserId;
        }

        private int InitializationGame()
        {
            return _gameRepository.Create(new Game { GameDate = DateTime.Now });
        }

        private int InitializationRound(int gameId)
        {
            return _roundRepository.Create(new Round { GameId = gameId });
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
