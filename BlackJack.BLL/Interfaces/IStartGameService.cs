using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IStartGameService
    {
        int StartNewGame(int botsCount, string userName);
    }
}
