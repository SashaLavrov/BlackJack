using BlackJack.BLL.DTO;
using BlackJack.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    public interface IComboCardService
    {
        ComboCardDTO Get(int id);

        void AddComboCard(ComboCardDTO comboCard);

        bool EditComboCard(ComboCardDTO comboCard);

        bool RemoveComboCard(int comboCardId);

        IEnumerable<ComboCardDTO> ComboCards();
    }
}
