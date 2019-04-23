using BlackJack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IRoundService
    {
        RoundDTO Get(int id);

        void AddRound(RoundDTO round);

        bool EditRound(RoundDTO round);

        bool RemoveRound(int roundId);

        IEnumerable<RoundDTO> GetRounds();
    }
}
