using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.DAL.Entities
{
    class Game
    {
        [Key]
        public int GameId { get; set; }
        public DateTime GameDate { get; set; }
        public IEnumerable<Round> Rounds { get; set; }
    }
}
