using BlackJack.BLL.Models;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameService
    {
        IEnumerable<User> GetAllPlayerFromGame(int gameId);
        Round GetLastRoundFromGame(int gameId);
        IEnumerable<Card> GetPlayersCardInRound(int playerId, int roundId);
        void Hit();
        void FinishRound();
        void StartNewRound();
        IEnumerable<GameView> GetAllGames();
        Card GetRandomCard();
    }
}
