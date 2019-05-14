using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class Card
    {
        public Card(int cardId, int val, string type, string suit)
        {
            CardId = cardId;
            Value = val;
            Type = type;
            Suit = suit;
        }

        public Card() { }

        [Key]
        public int CardId { get; set; }

        public int Value { get; set; }

        public string Type { get; set; }

        public string Suit { get; set; }

        public IEnumerable<ComboCard> ComboCards { get; set; }
    }
}
