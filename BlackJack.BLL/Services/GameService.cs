using BlackJack.BLL.Interfaces;
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

        public GameService(IRepository<Round> dbRound,
            IRepository<Combination> dbCombination,
            IRepository<ComboCard> dbComboCard,
            ICardRepository dbCard,
            IUserRepository dbUser
            )
        {
            _dbRound = dbRound;
            _dbCombination = dbCombination;
            _dbComboCard = dbComboCard;
            _dbCard = dbCard;
            _dbUser = dbUser;
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

        public void Hit(int playerId, int roundId)
        {
            int combinatiomId = _dbCombination.GetAll().Where(x => x.RoundId == roundId && x.UserId == playerId).FirstOrDefault().CombinationId;

            GiveCard(combinatiomId, GetRandomCard().CardId);
        }

        private void GiveCardToBots()
        {

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
    }
}
