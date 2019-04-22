using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }

        public IEnumerable<Combination> Combinations { get; set; }
    }
}
