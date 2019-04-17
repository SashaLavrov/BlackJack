using BlackJack.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.Interfaces
{
    interface ICardService
    {
        CardDTO Get(int id);
    }
}
