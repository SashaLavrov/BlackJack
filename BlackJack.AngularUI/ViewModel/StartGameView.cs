using System.ComponentModel.DataAnnotations;

namespace BlackJack.AngularUI.ViewModel
{
    public class StartGameView
    {
        [Required]
        public int BotsCount { get; set; }
        [Required]
        public string PlayerName { get; set; }
    }
}
