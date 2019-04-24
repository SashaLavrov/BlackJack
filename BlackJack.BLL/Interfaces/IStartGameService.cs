using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IStartGameService
    {
        void StartNewGame(int botsCount, string userId);
    }
}
