using BlackJack.BLL.Constants;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Services
{
    class GameService : IGameService
    {
        private IRepository<Round> _roundRepository;
        private IRepository<Combination> _combinationRepository;
        private IRepository<ComboCard> _comboCardRepository;
        private ICardRepository _cardRepository;
        private IUserRepository _userRepository;
        private IRepository<Game> _gameRepository;

        public GameService(IRepository<Round> roundRepository,
            IRepository<Combination> combinationRepository,
            IRepository<ComboCard> comboCardRepository,
            ICardRepository cardRepository,
            IRepository<Game> gameRepository,
            IUserRepository userRepository)
        {
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _combinationRepository = combinationRepository;
            _comboCardRepository = comboCardRepository;
            _cardRepository = cardRepository;
            _userRepository = userRepository;
        }
        public IEnumerable<GameView> GetAllGames()
        {
            var allGames = _gameRepository.GetAll();
            List<GameView> games = new List<GameView>();

            foreach (var i in allGames)
            {
                games.Add(new GameView
                {
                    GameId = i.GameId,
                    GameDate = i.GameDate
                });
            }
            return games;
        }
        public IEnumerable<User> GetAllPlayerFromGame(int gameId)
        {
            var rounds = _roundRepository.GetAll().Where(x => x.GameId == gameId);
            int lastRoundId = rounds.Where(x => x.RoundNumber == rounds.Max(y => y.RoundNumber))
                .FirstOrDefault().RoundId;
            var combinations = _combinationRepository.GetAll()
                .Where(x => x.RoundId == lastRoundId);

            List<User> players = new List<User>();

            foreach (var i in combinations)
            {
                players.Add(_userRepository.Get(i.UserId));
            }
            return players;
        }

        public void StartNewRound()
        {
            var lastGame = LastGame();
            var players = GetAllPlayerFromGame(lastGame.GameId);
            var lastRound = GetLastRoundFromGame(lastGame.GameId);
            int nextRoundNum = lastRound.RoundNumber + 1;
            int nextRoundId = _roundRepository.Create(new Round { GameId = lastGame.GameId, RoundNumber = nextRoundNum });

            GiveInitialCards(nextRoundId, players);
        }

        private void GiveInitialCards(int roundId, IEnumerable<User> players)
        {
            foreach (var i in players)
            {
                _combinationRepository.Create(new Combination
                {
                    RoundId = roundId,
                    UserId = i.UserId
                });
            }
            Hit();
            Hit();
        }

        public Round GetLastRoundFromGame(int gameId)
        {
            var rounds = _roundRepository.GetAll()
                .Where(x => x.GameId == gameId);

            var lastRound = rounds.Where(x => x.RoundNumber == rounds.Max(y => y.RoundNumber))
                .FirstOrDefault();

            return lastRound;
        }

        public IEnumerable<Card> GetPlayersCardInRound(int playerId, int roundId)
        {
            int combinationId = _combinationRepository.GetAll().Where(x => x.RoundId == roundId && x.UserId == playerId)
                .FirstOrDefault().CombinationId;
            var tempRes = _comboCardRepository.GetAll();
            var comboCard = tempRes.Where(x => x.CombinationId == combinationId).ToList();

            List<Card> Cards = new List<Card>();

            foreach (var i in comboCard)
            {
                Cards.Add(_cardRepository.GetCard(i.CardId));
            }
            return Cards;
        }

        public void Hit()
        {
            var lastGameId = LastGame().GameId;
            var players = GetAllPlayerFromGame(lastGameId);
            var player = players.Where(x => !x.IsBot && x.Nickname != "Dealer").FirstOrDefault();
            var roundId = GetLastRoundFromGame(lastGameId).RoundId;

            int combinatiomId = _combinationRepository.GetAll()
                .Where(x => x.RoundId == roundId && x.UserId == player.UserId)
                .FirstOrDefault().CombinationId;

            var cards = GetPlayersCardInRound(player.UserId, roundId);
            int currentSum = SumOfCards(cards);

            if (currentSum < ConstantsValue.MaxSum)
            {
                GiveCard(combinatiomId, GetRandomCard().CardId);
            }

            GiveCardToBots();
        }

        public int SumOfCards(IEnumerable<Card> cards)
        {
            int currentSum = cards.Sum(x => x.Value);

            if (cards.Where(x => x.Type == "ace").Count() < 0 && currentSum < 21)
            {
                return currentSum;
            }

            currentSum = 0;
            foreach (var i in cards)
            {
                if (i.Type == "ace")
                {
                    currentSum++;
                }
                else
                {
                    currentSum += i.Value;
                }
            }
            return currentSum;
        }

        public void FinishRound()
        {
            bool marker = true;

            while (marker)
            {
                marker = GiveCardToBots();
            }
        }

        private bool GiveCardToBots()
        {
            bool marker = false;
            int lastGame = LastGame().GameId;
            var players = GetAllPlayerFromGame(lastGame);
            int lastRound = GetLastRoundFromGame(lastGame).RoundId;

            foreach (var i in players)
            {
                bool temp = (i.IsBot || i.Nickname == "Dealer");

                if (temp && IsCheckNeedsCard(i.UserId, lastRound))
                {
                    GiveCard(GetCombination(i.UserId, lastRound).CombinationId, GetRandomCard().CardId);
                    if (IsCheckNeedsCard(i.UserId, lastRound))
                    {
                        marker = true;
                    }
                }
            }
            return marker;
        }

        private Combination GetCombination(int userId, int roundId)
        {
            return _combinationRepository.GetAll().Where(x => x.UserId == userId && x.RoundId == roundId).FirstOrDefault();
        }

        public Card GetRandomCard()
        {
            Random random = new Random();
            int cardId = random.Next(ConstantsValue.FirstCardId, ConstantsValue.LastCardId);
            return _cardRepository.GetCard(cardId);
        }

        private int GiveCard(int combinationId, int cardId)
        {
            return _comboCardRepository.Create(new ComboCard { CombinationId = combinationId, CardId = cardId });
        }

        private bool IsCheckNeedsCard(int playerId, int roundId)
        {
            var cards = GetPlayersCardInRound(playerId, roundId);
            int currenSum = SumOfCards(cards);
            return currenSum < ConstantsValue.MaxTotalSum;
        }

        private Game LastGame()
        {
            var lastGame = _gameRepository.GetAll().Where(x => x.GameDate == _gameRepository.GetAll().Max(d => d.GameDate)).FirstOrDefault();
            return lastGame;
        }
    }
}
