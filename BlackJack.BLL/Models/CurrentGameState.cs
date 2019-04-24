using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Models
{
    public class CurrentGameState
    {
        int gameId { get; set; }

        IEnumerable<int> PlayersId { get; set; }

        int currentRound { get; set; }
    }
}
