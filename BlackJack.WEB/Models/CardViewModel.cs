using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.Models
{
    public class CardViewModel
    {
        public int CardId { get; set; }

        public int Value { get; set; }

        public string Type { get; set; }

        public string Suit { get; set; }
    }
}
