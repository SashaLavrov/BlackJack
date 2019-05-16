using System.ComponentModel.DataAnnotations;

namespace BlackJack.AngularUI.ViewModel
{
    public class AuthorizationViewModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
