using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJack.WEB.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
    }
}
