using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameStateService
    {
        IEnumerable<CurrentPlayerStateView> CurrentGameState();
        IEnumerable<IEnumerable<CurrentPlayerStateView>> GameState(int gameId);
    }
}
