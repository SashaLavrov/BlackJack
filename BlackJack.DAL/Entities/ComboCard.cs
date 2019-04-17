using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.DAL.Entities
{
    class ComboCard
    {
        [Key]
        public int ComboCardId { get; set; }

        public int CombinationId { get; set; }
        public Combination Combination { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
