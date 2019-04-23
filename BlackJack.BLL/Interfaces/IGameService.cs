using BlackJack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IGameService
    {
        GameDTO Get(int id);

        void AddGame(GameDTO game);

        bool EditGame(GameDTO game);

        bool RemoveGame(int gameId);

        IEnumerable<GameDTO> GetGames();
    }
}
