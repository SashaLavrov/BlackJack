using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    interface IGameService
    {
        IEnumerable<User> GetAllPlayerFromGame(int gameId);

        Round GetLastRoundFromGame(int gameId);

        IEnumerable<Card> GetPlayersCardInRound(int playerId, int roundId);

        void Hit(int playerId, int roundId);
    }
}
