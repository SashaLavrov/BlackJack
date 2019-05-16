using AutoMapper;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.BLL.Services
{
    class GameStateService : IGameStateService
    {
        private IGameService _gameService;
        private IRepository<Game> _gameRepository;
        private IRepository<Round> _roundRepository;
        private IMapper _mapper;
        public GameStateService(IGameService gameService, IRepository<Game> gameRepository, IRepository<Round> roundRepository, IMapper mapper)
        {
            _gameService = gameService;
            _gameRepository = gameRepository;
            _roundRepository = roundRepository;
            _mapper = mapper;
        }

        public IEnumerable<CurrentPlayerStateView> CurrentGameState()
        {
            var lastGame = _gameRepository.GetAll().Where(x => x.GameDate == _gameRepository.GetAll().Max(d => d.GameDate)).FirstOrDefault();
            if (lastGame != null)
            {
                return GetAllPlayersFromGame(lastGame.GameId);
            }
            return null;
        }

        private IEnumerable<CurrentPlayerStateView> GetAllPlayersFromGame(int gameId)
        {
            int lastRoundId = _gameService.GetLastRoundFromGame(gameId).RoundId;

            var players = _gameService.GetAllPlayerFromGame(gameId);

            List<CurrentPlayerStateView> result = new List<CurrentPlayerStateView>();

            foreach (var i in players)
            {
                var playerCards = GetPlayrsCard(i.UserId, lastRoundId);
                int playerTotalCount = _gameService.SumOfCards(GetPlayrCards(i.UserId, lastRoundId));

                CurrentPlayerStateView item = new CurrentPlayerStateView
                {
                    IsBot = i.IsBot,
                    PlayerId = i.UserId,
                    PlayerName = i.Nickname,
                    Cards = playerCards,
                    TotalCount = playerTotalCount,
                };

                result.Add(item);
            }
            return result;
        }

        private IEnumerable<CurrentCardPlayerStateViewItem> GetPlayrsCard(int playerId, int roundId)
        {
            var cards = _gameService.GetPlayersCardInRound(playerId, roundId);
            List<CurrentCardPlayerStateViewItem> Cards = new List<CurrentCardPlayerStateViewItem>();

            foreach (var i in cards)
            {
                Cards.Add(_mapper.Map<CurrentCardPlayerStateViewItem>(i));
            }
            return Cards;
        }

        private IEnumerable<Card> GetPlayrCards(int playerId, int roundId)
        {
            return _gameService.GetPlayersCardInRound(playerId, roundId);
        }

        public IEnumerable<IEnumerable<CurrentPlayerStateView>> GameState(int gameId)
        {
            return GetHistoryGames(gameId);
        }

        private IEnumerable<IEnumerable<CurrentPlayerStateView>> GetHistoryGames(int gameId)
        {
            var rounds = _roundRepository.GetAll().Where(x => x.GameId == gameId).ToList();
            var players = _gameService.GetAllPlayerFromGame(gameId);
            List<List<CurrentPlayerStateView>> res = new List<List<CurrentPlayerStateView>>();
            foreach (var r in rounds)
            {
                List<CurrentPlayerStateView> result = new List<CurrentPlayerStateView>();
                foreach (var p in players)
                {
                    var playerCards = GetPlayrsCard(p.UserId, r.RoundId);

                    CurrentPlayerStateView item = new CurrentPlayerStateView
                    {
                        RoundNumber = r.RoundNumber,
                        IsBot = p.IsBot,
                        PlayerId = p.UserId,
                        PlayerName = p.Nickname,
                        Cards = playerCards,
                        TotalCount = _gameService.SumOfCards(_gameService.GetPlayersCardInRound(p.UserId, r.RoundId))
                    };
                    result.Add(item);
                }
                res.Add(result);
            }
            return res;
        }
    }
}
    

