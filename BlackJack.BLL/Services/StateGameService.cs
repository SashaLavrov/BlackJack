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
    class StateGameService : IStateGameService
    {
        private IGameService _gameService;

        public StateGameService(IGameService gameService)
        {
            _gameService = gameService;
        }
        
        public IEnumerable<CurrentGameStateView> CurrentGameState(int gameId)
        {
            return GetAllPlayersFromGame(gameId);
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
    }
}
