using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.BLL.DTO
{
    public class CardDTO
    {
        public int CardId { get; set; }

        public int Value { get; set; }

        public string Type { get; set; }

        public string Suit { get; set; }
    }
}
