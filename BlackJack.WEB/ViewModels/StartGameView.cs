using System.ComponentModel.DataAnnotations;

namespace BlackJack.WEB.ViewModels
{
    public class StartGameView
    {
        [Required]
        public int BotsCount { get; set; }
        [Required]
        public string PlayerName { get; set; }
    }
}
