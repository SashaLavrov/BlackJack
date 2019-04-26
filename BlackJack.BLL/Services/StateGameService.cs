using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.BLL.Services
{
    class StateGameService : IStateGameService
    {
        private IGameService _gameService;
        private IRepository<Game> _gameRepository;
        private IRepository<Round> _roundRepository;
        public StateGameService(IGameService gameService, IRepository<Game> gameRepository, IRepository<Round> roundRepository)
        {
            _gameService = gameService;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
        }
        
        public IEnumerable<CurrentGameStateView> CurrentGameState()
        {
            var lastGame = _gameRepository.GetAll().Where(x => x.GameDate == _gameRepository.GetAll().Max(d => d.GameDate)).FirstOrDefault();
            if (lastGame != null)
            {
                return GetAllPlayersFromGame(lastGame.GameId);
            }
            return null;
        }

        private IEnumerable<CurrentGameStateView> GetAllPlayersFromGame(int gameId)
        {
            int lastRoundId = _gameService.GetLastRoundFromGame(gameId).RoundId;

            var players = _gameService.GetAllPlayerFromGame(gameId);

            List<CurrentGameStateView> result = new List<CurrentGameStateView>();

            foreach (var i in players)
            {
                var playerCards = GetPlayrsCard(i.UserId, lastRoundId);

                CurrentGameStateView item = new CurrentGameStateView
                {
                    IsBot = i.IsBot,
                    PlayerId = i.UserId,
                    PlayerName = i.Nickname,
                    Cards = playerCards,
                };

                result.Add(item);
            }
            return result;
        }
        private IEnumerable<CardCurentGameStateViewItem> GetPlayrsCard(int playerId ,int roundId)
        {
            var cards = _gameService.GetPlayersCardInRound(playerId, roundId);

            List<CardCurentGameStateViewItem> Cards = new List<CardCurentGameStateViewItem>();

            foreach(var i in cards)
            {
                Cards.Add(new CardCurentGameStateViewItem {
                    CardId = i.CardId,
                    Suit = i.Suit,
                    Type = i.Type,
                    Value = i.Value
                });
            }
            return Cards;
        }

        public IEnumerable<CurrentGameStateView> GameState(int gameId)
        {
            return GetHistoryGames(gameId);
        }

        private IEnumerable<CurrentGameStateView> GetHistoryGames(int gameId)
        {
            var rounds = _roundRepository.GetAll().Where(x => x.GameId == gameId).ToList();

            var players = _gameService.GetAllPlayerFromGame(gameId);

            List<CurrentGameStateView> result = new List<CurrentGameStateView>();

            foreach (var r in rounds)
            {
                foreach (var i in players)
                {
                    var playerCards = GetPlayrsCard(i.UserId, r.RoundId);

                    CurrentGameStateView item = new CurrentGameStateView
                    {
                        IsBot = i.IsBot,
                        PlayerId = i.UserId,
                        PlayerName = i.Nickname,
                        Cards = playerCards,
                    };

                    result.Add(item);
                }
            }
            return result;
        }
    }
}
