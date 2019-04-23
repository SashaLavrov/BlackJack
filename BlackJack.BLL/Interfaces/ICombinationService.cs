using BlackJack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface ICombinationService
    {
        CombinationDTO Get(int id);

        void AddCombination(CombinationDTO combination);

        bool EditCombination(CombinationDTO combination);

        bool RemoveCombination(int combinationId);

        IEnumerable<CombinationDTO> GetCombinations();
    }
}
