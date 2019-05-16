using Microsoft.AspNetCore.Identity;

namespace BlackJack.Authorization.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
    }
}
