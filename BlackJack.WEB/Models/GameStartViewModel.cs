using BlackJack.BLL.DTO;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.Models
{
    public class GameStartViewModel
    {
        IEnumerable<CardDTO> InitilCards { get; set; }
        
    }
}
