using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.Models
{
    public class StartGameView
    {
        [Required]
        public int BotsCount { get; set; }
        [Required]
        public string PlayerName { get; set; }
    }
}
