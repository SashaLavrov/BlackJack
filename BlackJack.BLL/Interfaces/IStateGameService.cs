using BlackJack.BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IStateGameService
    {
        IEnumerable<CurrentGameStateView> CurrentGameState(int gameId);
    }
}
