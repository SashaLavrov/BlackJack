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
    class GameService : IGameService
    {
        private IRepository<Round> _dbRound;
        private IRepository<Combination> _dbCombination;
        private IRepository<ComboCard> _dbComboCard;
        private ICardRepository _dbCard;
        private IUserRepository _dbUser;
        private IRepository<Game> _dbGame;

        public GameService(IRepository<Round> dbRound,
            IRepository<Combination> dbCombination,
            IRepository<ComboCard> dbComboCard,
            ICardRepository dbCard,
            IRepository<Game> dbGame,
            IUserRepository dbUser
            )
        {
            _dbGame = dbGame;
            _dbRound = dbRound;
            _dbCombination = dbCombination;
            _dbComboCard = dbComboCard;
            _dbCard = dbCard;
            _dbUser = dbUser;
        }
        public IEnumerable<GameView> GetAllGames()
        {
            var allGame = _dbGame.GetAll();

            List<GameView> games = new List<GameView>();

            foreach (var i in allGame)
            {
                games.Add(new GameView {
                    GameId = i.GameId,
                    GameDate = i.GameDate
                });
            }

            return games;
        }
        public IEnumerable<User> GetAllPlayerFromGame(int gameId)
        {
            var rounds = _dbRound.GetAll().Where(x => x.GameId == gameId);
            int lastRoundId = rounds.Where(x => x.RoundNumber == rounds.Max(y => y.RoundNumber)).FirstOrDefault().RoundId;
            var combinations = _dbCombination.GetAll().Where(x => x.RoundId == lastRoundId);

            List<User> players = new List<User>();

            foreach (var i in combinations)
            {
                players.Add(_dbUser.Get(i.UserId)); 
            }
            return players;
        }

        public void StartNewRound()
        {
            var lastGame = LastGame();
            var players = GetAllPlayerFromGame(lastGame.GameId);
            var lastRound = GetLastRoundFromGame(lastGame.GameId);
            int nextRoundNum = lastRound.RoundNumber +1;
            int nextRoundId = _dbRound.Create(new Round { GameId = lastGame.GameId, RoundNumber = nextRoundNum });

            GiveInitialCards(nextRoundId, players);
        }

        private void GiveInitialCards(int roundId, IEnumerable<User> players)
        {
            foreach (var i in players)
            {
                _dbCombination.Create(new Combination {
                    RoundId = roundId,
                    UserId = i.UserId
                });
            }
            Hit(); Hit();
        }

        public Round GetLastRoundFromGame(int gameId)
        {
            var rounds = _dbRound.GetAll().Where(x => x.GameId == gameId);
            var lastRound = rounds.Where(x => x.RoundNumber == rounds.Max(y => y.RoundNumber)).FirstOrDefault();

            return lastRound;
        }

        public IEnumerable<Card> GetPlayersCardInRound(int playerId, int roundId)
        {
            int combinationId = _dbCombination.GetAll().Where(x => x.RoundId == roundId && x.UserId == playerId).FirstOrDefault().CombinationId;
            var tempRes = _dbComboCard.GetAll();
            var comboCard = tempRes.Where(x => x.CombinationId == combinationId).ToList();

            List<Card> Cards = new List<Card>();

            foreach (var i in comboCard)
            {
                Cards.Add(_dbCard.GetCard(i.CardId));
            }
            return Cards;
        }

        public void Hit()
        {
            var lastGame = LastGame().GameId;
            var players = GetAllPlayerFromGame(lastGame);
            var player = players.Where(x => !x.IsBot && x.Nickname != "Dealer").FirstOrDefault();
            var roundId = GetLastRoundFromGame(lastGame).RoundId;

            int combinatiomId = _dbCombination.GetAll().Where(x => x.RoundId == roundId && x.UserId == player.UserId).FirstOrDefault().CombinationId;

            var cards = GetPlayersCardInRound(player.UserId, roundId);
            int currenSum = cards.Sum(x => x.Value);

            if (currenSum < 21)
            {
                GiveCard(combinatiomId, GetRandomCard().CardId);
            }

            GiveCardToBots();
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
            var lastGame = LastGame().GameId;
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
            return _dbCombination.GetAll().Where(x => x.UserId == userId && x.RoundId == roundId).FirstOrDefault();
        }

        private Card GetRandomCard()
        {
            Random random = new Random();
            int cardId = random.Next(2, 53);
            return _dbCard.GetCard(cardId);
        }

        private int GiveCard(int combinationId, int cardId)
        {
            return _dbComboCard.Create(new ComboCard { CombinationId = combinationId, CardId = cardId });
        }

        private bool IsCheckNeedsCard(int playerId, int roundId)
        {
            int maxTotalSum = 17;
            var cards = GetPlayersCardInRound(playerId, roundId);
            int currenSum = cards.Sum(x => x.Value);
            if(currenSum < maxTotalSum)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Game LastGame()
        {
            var lastGame = _dbGame.GetAll().Where(x => x.GameDate == _dbGame.GetAll().Max(d => d.GameDate)).FirstOrDefault();
            return lastGame;
        }
    }
}
