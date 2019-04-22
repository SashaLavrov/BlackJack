using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class Combination
    {
        [Key]
        public int CombinationId { get; set; }

        public int RoundId { get; set; }
        public Round Round { get; set; }

        public int UserId { get; set; }
    }
}
