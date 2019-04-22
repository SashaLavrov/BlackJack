using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class Round
    {
        [Key]
        public int RoundId { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public IEnumerable<Combination> Combinations { get; set; }
    }
}
